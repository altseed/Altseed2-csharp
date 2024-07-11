using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Altseed2
{
    /// <summary>
    /// 大量描画を行うノード
    /// </summary>
    [Serializable]
    public class TileMapNode : TransformNode, IDrawn, ICullableDrawn
    {
        private readonly MapChipList chips;
        private readonly RenderedPolygon renderedPolygon;
        private bool requireUpdateVertexes = true;

        /// <summary>
        /// 格納されている<see cref="MapChip"/>を取得します。
        /// </summary>
        public ReadOnlyCollection<MapChip> Chips => _chips ??= new ReadOnlyCollection<MapChip>(chips);
        [NonSerialized]
        private ReadOnlyCollection<MapChip> _chips;

        /// <summary>
        /// <see cref="TileMapNode"/>の新しいインスタンスを生成します。
        /// </summary>
        /// <exception cref="InvalidOperationException">Graphics昨日が初期化されていない</exception>
        public TileMapNode()
        {
            if (!Engine.Config.EnabledCoreModules.HasFlag(CoreModules.Graphics)) throw new InvalidOperationException("Graphics機能が初期化されていません。");
            chips = new MapChipList();
            renderedPolygon = RenderedPolygon.Create();
        }

        #region IDrawn
        Rendered ICullableDrawn.Rendered => renderedPolygon;

        void IDrawn.Draw()
        {
            Engine.Renderer.DrawPolygon(renderedPolygon);
        }

        int ICullableDrawn.CullingId => renderedPolygon.Id;

        /// <summary>
        /// カメラグループを取得または設定します。
        /// </summary>
        public ulong CameraGroup
        {
            get => _CameraGroup;
            set
            {
                if (_CameraGroup == value) return;
                var old = _CameraGroup;
                _CameraGroup = value;

                if (IsRegistered)
                    Engine.UpdateDrawnCameraGroup(this, old);
            }
        }
        private ulong _CameraGroup;

        /// <summary>
        /// 描画時の重ね順を取得または設定します。
        /// </summary>
        public int ZOrder
        {
            get => _ZOrder;
            set
            {
                if (value == _ZOrder) return;

                var old = _ZOrder;
                _ZOrder = value;

                if (IsRegistered)
                    Engine.UpdateDrawnZOrder(this, old);
            }
        }
        private int _ZOrder;

        /// <summary>
        /// このノードを描画するかどうかを取得または設定します。
        /// </summary>
        public bool IsDrawn
        {
            get => _IsDrawn; set
            {
                if (_IsDrawn == value) return;
                _IsDrawn = value;
                this.UpdateIsDrawnActuallyOfDescendants();

            }
        }
        private bool _IsDrawn = true;

        /// <summary>
        /// 先祖の<see cref="IsDrawn"/>を考慮して、このノードを描画するかどうかを取得します。
        /// </summary>
        public bool IsDrawnActually => (this as ICullableDrawn).IsDrawnActually;
        bool ICullableDrawn.IsDrawnActually { get; set; } = true;
        #endregion

        #region Node
        internal override void Registered()
        {
            base.Registered();
            Engine.RegisterDrawn(this);
            Engine.CullingSystem.Register(renderedPolygon);
        }

        internal override void Unregistered()
        {
            base.Unregistered();
            Engine.UnregisterDrawn(this);
            Engine.CullingSystem.Unregister(renderedPolygon);
        }

        internal override void Update()
        {
            if (requireUpdateVertexes)
            {
                UpdateVertexes();
                requireUpdateVertexes = false;
            }

            base.Update();
        }
        #endregion

        #region RenderedPolygon
        /// <summary>
        /// アルファブレンドを取得または設定します。
        /// </summary>
        public AlphaBlend AlphaBlend
        {
            get => renderedPolygon.AlphaBlend;
            set
            {
                if (renderedPolygon.AlphaBlend == value) return;
                renderedPolygon.AlphaBlend = value;
            }
        }

        /// <summary>
        /// 使用するマテリアルを取得または設定します。
        /// </summary>
        public Material Material
        {
            get => renderedPolygon.Material;
            set
            {
                if (renderedPolygon.Material == value) return;
                renderedPolygon.Material = value;
            }
        }

        /// <summary>
        /// 使用するテクスチャを取得または設定します。
        /// </summary>
        public TextureBase Texture
        {
            get => renderedPolygon.Texture;
            set
            {
                if (renderedPolygon.Texture == value) return;
                renderedPolygon.Texture = value;
                renderedPolygon.Src = new RectF(default, value?.Size ?? new Vector2I(1, 1));
                foreach (var chip in chips) chip.Src = new RectF(default, value?.Size ?? new Vector2I(1, 1));
            }
        }

        /// <inheritdoc/>
        public sealed override Matrix44F InheritedTransform
        {
            get => base.InheritedTransform;
            private protected set
            {
                base.InheritedTransform = value;
                AbsoluteTransform = value * Matrix44F.GetTranslation2D(-CenterPosition);
                renderedPolygon.Transform = AbsoluteTransform;
            }
        }
        #endregion

        /// <inheritdoc/>
        public sealed override Vector2F ContentSize
        {
            get
            {
                MathHelper.GetMinMax(out var min, out var max, renderedPolygon.Vertexes);
                return max - min;
            }
        }

        /// <summary>
        /// <see cref="MapChip"/>を登録します。
        /// </summary>
        /// <param name="chip">登録する<see cref="MapChip"/>のインスタンス</param>
        /// <exception cref="ArgumentNullException"><paramref name="chip"/>がnull</exception>
        /// <returns><paramref name="chip"/>を追加出来たらtrue，それ以外でそれ以外でfalse</returns>
        public bool AddMapChip(MapChip chip)
        {
            if (!chips.Add(chip)) return false;
            chip.Owner = this;
            chip.OnAdded();
            requireUpdateVertexes = true;
            return true;
        }

        /// <summary>
        /// 登録されている<see cref="MapChip"/>を全て削除します。
        /// </summary>
        public void ClearMapChips()
        {
            for (int i = 0; i < chips.Count; i++) chips[i].Owner = null;
            chips.Clear();
            requireUpdateVertexes = true;
        }

        /// <summary>
        /// <see cref="MapChip"/>を削除します。
        /// </summary>
        /// <param name="chip">削除する<see cref="MapChip"/>のインスタンス</param>
        /// <exception cref="ArgumentNullException"><paramref name="chip"/>がnull</exception>
        /// <returns><paramref name="chip"/>を削除出来たらtrue，それ以外でそれ以外でfalse</returns>
        public bool RemoveChip(MapChip chip)
        {
            if (!chips.Remove(chip)) return false;
            chip.Owner = null;
            requireUpdateVertexes = true;
            return true;
        }

        /// <summary>
        /// 頂点の更新をリクエストします。
        /// </summary>
        internal void RequestUpdateVertexes()
        {
            requireUpdateVertexes = true;
        }

        private void UpdateVertexes()
        {
            chips.SortIfRequired();

            var size = Texture?.Size ?? new Vector2I(1, 1);
            var vertexes = new Vertex[4 * chips.Count];
            var basicVertexes = new[]
            {
                new Vector3F(0f, 0f, 0.5f),
                new Vector3F(size.X, 0f, 0.5f),
                new Vector3F(size.X, size.Y, 0.5f),
                new Vector3F(0f, size.Y, 0.5f),
            };

            var buffers = new int[chips.Count * 6];

            for (int i = 0; i < chips.Count; i++)
            {
                var chip = chips[i];
                var uv0 = chip.Src.Position / size;
                var uvSize = chip.Src.Size / size;

                var i4 = i * 4;
                vertexes[i4] = new Vertex(chip.Transform.Transform3D(basicVertexes[0]), chip.Color, uv0, default);
                vertexes[i4 + 1] = new Vertex(chip.Transform.Transform3D(basicVertexes[1]), chip.Color, new Vector2F(uv0.X + uvSize.X, uv0.Y), default);
                vertexes[i4 + 2] = new Vertex(chip.Transform.Transform3D(basicVertexes[2]), chip.Color, uv0 + uvSize, default);
                vertexes[i4 + 3] = new Vertex(chip.Transform.Transform3D(basicVertexes[3]), chip.Color, new Vector2F(uv0.X, uv0.Y + uvSize.Y), default);

                for (int j = 0; j < 2; j++)
                {
                    buffers[i * 6 + j * 3] = i4;
                    buffers[i * 6 + j * 3 + 1] = i4 + j + 1;
                    buffers[i * 6 + j * 3 + 2] = i4 + j + 2;
                }
            }

            renderedPolygon.Vertexes.FromSpan(vertexes);
            renderedPolygon.Vertexes = renderedPolygon.Vertexes;

            renderedPolygon.Buffers.FromSpan(buffers);
            renderedPolygon.Buffers = renderedPolygon.Buffers;
        }
    }

    /// <summary>
    /// 大量描画に使用するマップチップ
    /// </summary>
    [Serializable]
    public sealed class MapChip
    {
        private bool requireCalcTransform = true;

        internal MapChipList List { get; set; }

        internal TileMapNode Owner { get; set; }

        /// <summary>
        /// 回転角度を取得または設定します。
        /// </summary>
        public float Angle
        {
            get => _angle;
            set
            {
                if (_angle == value) return;
                _angle = value;
                requireCalcTransform = true;
                Owner?.RequestUpdateVertexes();
            }
        }
        private float _angle;

        /// <summary>
        /// 中心座標を取得または設定します。
        /// </summary>
        public Vector2F CenterPosition
        {
            get => _centerPosition;
            set
            {
                if (_centerPosition == value) return;
                _centerPosition = value;
                requireCalcTransform = true;
                Owner?.RequestUpdateVertexes();
            }
        }
        private Vector2F _centerPosition;

        /// <summary>
        /// 色を取得または設定します。
        /// </summary>
        public Color Color
        {
            get => _color;
            set
            {
                if (_color == value) return;
                _color = value;
                Owner?.RequestUpdateVertexes();
            }
        }
        private Color _color = new Color(255, 255, 255);

        /// <summary>
        /// 左右を反転するかどうかを取得または設定します。
        /// </summary>
        public bool HorizontalFlip
        {
            get => _horizontalFlip;
            set
            {
                if (_horizontalFlip == value) return;
                _horizontalFlip = value;
                requireCalcTransform = true;
                Owner?.RequestUpdateVertexes();
            }
        }
        private bool _horizontalFlip = false;

        /// <summary>
        /// 座標を取得または設定します。
        /// </summary>
        public Vector2F Position
        {
            get => _position;
            set
            {
                if (_position == value) return;
                _position = value;
                requireCalcTransform = true;
                Owner?.RequestUpdateVertexes();
            }
        }
        private Vector2F _position;

        /// <summary>
        /// 拡大率を取得または設定します。
        /// </summary>
        public Vector2F Scale
        {
            get => _scale;
            set
            {
                if (_scale == value) return;
                _scale = value;
                requireCalcTransform = true;
                Owner?.RequestUpdateVertexes();
            }
        }
        private Vector2F _scale = Vector2F.One;

        /// <summary>
        /// テクスチャの描画範囲を取得または設定します。
        /// </summary>
        public RectF Src
        {
            get => _src;
            set
            {
                if (_src == value) return;
                _src = value;
                Owner?.RequestUpdateVertexes();
            }
        }
        private RectF _src;

        /// <summary>
        /// 変形行列を取得します。
        /// </summary>
        internal Matrix44F Transform
        {
            get
            {
                if (requireCalcTransform)
                {
                    var scale = Scale;
                    if (HorizontalFlip) scale.X *= -1;
                    if (VerticalFlip) scale.Y *= -1;
                    _transform = MathHelper.CalcTransform(Position, MathHelper.DegreeToRadian(Angle), scale) * Matrix44F.GetTranslation2D(-CenterPosition);
                    requireCalcTransform = false;
                }
                return _transform;
            }
        }
        private Matrix44F _transform = Matrix44F.Identity;

        /// <summary>
        /// 上下を反転するかどうかを取得または設定します。
        /// </summary>
        public bool VerticalFlip
        {
            get => _verticalFlip;
            set
            {
                if (_verticalFlip == value) return;
                _verticalFlip = value;
                requireCalcTransform = true;
                Owner?.RequestUpdateVertexes();
            }
        }
        private bool _verticalFlip = false;

        /// <summary>
        /// 重ね順を取得または設定します。
        /// </summary>
        public int ZOrder
        {
            get => _zOrder;
            set
            {
                if (_zOrder == value) return;
                _zOrder = value;
                List?.RequestSort();
                Owner?.RequestUpdateVertexes();
            }
        }
        private int _zOrder;

        /// <summary>
        /// <see cref="MapChip"/>の新しいインスタンスを生成します。
        /// </summary>
        public MapChip() { }

        internal void OnAdded()
        {
            Src = new RectF(default, Owner.Texture?.Size ?? new Vector2I(1, 1));
        }
    }

    /// <summary>
    /// <see cref="MapChip"/>を格納するコレクション
    /// </summary>
    [Serializable]
    internal sealed class MapChipList : IList<MapChip>, IReadOnlyList<MapChip>
    {
        private static readonly MapChipComparer comparer = new MapChipComparer();
        private MapChip[] items;
        private bool requireSorted;
        private int version;

        /// <summary>
        /// 格納されている要素数を取得します。
        /// </summary>
        public int Count { get; private set; }

        bool ICollection<MapChip>.IsReadOnly => false;

        /// <summary>
        /// <see cref="MapChipList"/>の新しいインスタンスを生成します。
        /// </summary>
        public MapChipList()
        {
            items = Array.Empty<MapChip>();
        }

        /// <summary>
        /// 指定したインデックスの要素を取得します。
        /// </summary>
        /// <param name="index">検索する要素のインデックス</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が範囲外</exception>
        /// <returns><paramref name="index"/>に対応する要素</returns>
        public MapChip this[int index]
        {
            get
            {
                if (index < 0 || Count <= index) throw new ArgumentOutOfRangeException(nameof(index), "インデックスが範囲外です");
                return items[index];
            }
        }
        MapChip IList<MapChip>.this[int index]
        {
            get => this[index];
            set => throw new NotSupportedException("この操作はサポートされていません");
        }

        /// <summary>
        /// <see cref="MapChip"/>を追加します。
        /// </summary>
        /// <param name="item">追加する<see cref="MapChip"/>のインスタンス</param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/>がnull</exception>
        /// <returns><paramref name="item"/>を追加出来たらtrue，それ以外でfalse</returns>
        public bool Add(MapChip item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item), "引数がnullです");
            if (item.List != null) return false;
            var index = Array.BinarySearch(items, 0, Count, item, comparer);
            if (index < 0) InsertPrivate(~index, item);
            else InsertPrivate(index, item);
            return true;
        }

        /// <summary>
        /// <see cref="Enumerator"/>の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="sort">ソートするかどうか</param>
        /// <returns><see cref="Enumerator"/>の新しいインスタンス</returns>
        public Enumerator GetEnumerator(bool sort)
        {
            if (sort) SortIfRequired();
            return new Enumerator(this);
        }

        private void InsertPrivate(int index, MapChip item)
        {
            if (items.Length < Count + 1) ReSize(Count + 1);
            if (index < Count) Array.Copy(items, index, items, index + 1, Count - index);
            items[index] = item;
            version++;
            Count++;
            item.List = this;
        }

        /// <summary>
        /// ソートをリクエストします。
        /// </summary>
        public void RequestSort()
        {
            requireSorted = true;
        }

        private void ReSize(int min)
        {
            if (min <= items.Length) return;
            var size = items.Length == 0 ? 4 : items.Length * 2;
            if ((uint)size > int.MaxValue) size = int.MaxValue;
            if (size < min) size = min;
            Array.Resize(ref items, size);
        }

        /// <summary>
        /// ソートを実行します。
        /// </summary>
        public void Sort()
        {
            Array.Sort(items, comparer);
            requireSorted = false;
            version++;
        }

        /// <summary>
        /// 必要がある場合にソートを実行します。
        /// </summary>
        public void SortIfRequired()
        {
            if (requireSorted) Sort();
        }

        #region IList
        void ICollection<MapChip>.Add(MapChip item) => Add(item);

        /// <summary>
        /// 全ての要素を削除します。
        /// </summary>
        public void Clear()
        {
            if (Count == 0) return;
            for (int i = 0; i < Count; i++) items[i].List = null;
            Array.Clear(items, 0, Count);
            Count = 0;
            version++;
        }

        /// <summary>
        /// 指定した<see cref="MapChip"/>が格納されているかどうかを取得します。
        /// </summary>
        /// <param name="item">検索する<see cref="MapChip"/>のインスタンス</param>
        /// <returns><paramref name="item"/>が格納されていたらtrue，それ以外でfalse</returns>
        public bool Contains(MapChip item) => item != null && item.List == this;

        void ICollection<MapChip>.CopyTo(MapChip[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException(nameof(array), "引数がnullです");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex), "値が0未満です");
            if (array.Length < Count + arrayIndex) throw new ArgumentException("サイズが足りません", nameof(array));
            for (int i = 0; i < Count; i++) array[arrayIndex++] = items[i];
        }

        /// <summary>
        /// <see cref="Enumerator"/>の新しいインスタンスを生成します。
        /// </summary>
        /// <returns><see cref="Enumerator"/>の新しいインスタンス</returns>
        public Enumerator GetEnumerator() => GetEnumerator(false);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        IEnumerator<MapChip> IEnumerable<MapChip>.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// 指定した<see cref="MapChip"/>のインデックスを取得します。
        /// </summary>
        /// <param name="item">検索する<see cref="MapChip"/>のインスタンス</param>
        /// <returns><paramref name="item"/>のインデックス 格納されていない場合は-1</returns>
        public int IndexOf(MapChip item) => Contains(item) ? Array.IndexOf(items, item) : -1;

        void IList<MapChip>.Insert(int index, MapChip item) => throw new NotSupportedException("この操作はサポートされていません");

        /// <summary>
        /// <see cref="MapChip"/>を削除します。
        /// </summary>
        /// <param name="item">削除する<see cref="MapChip"/>のインスタンス</param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/>がnull</exception>
        /// <returns><paramref name="item"/>を追加出来たらtrue，それ以外でfalse</returns>
        public bool Remove(MapChip item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item), "引数がnullです");
            var index = IndexOf(item);
            if (index < 0) return false;
            RemoveAt(index);
            return true;
        }

        /// <summary>
        /// 指定したインデックスの要素を削除する
        /// </summary>
        /// <param name="index">削除する要素のインデックス</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が範囲外</exception>
        public void RemoveAt(int index)
        {
            if (index < 0 || Count - 1 < index) throw new ArgumentOutOfRangeException(nameof(index), "インデックスが範囲外です");
            var chip = items[index];
            if (index < --Count) Array.Copy(items, index + 1, items, index, Count - index);
            items[index] = default;
            chip.List = null;
            version++;
        }
        #endregion

        /// <summary>
        /// 列挙を補助する構造体
        /// </summary>
        [Serializable]
        public struct Enumerator : IEnumerator<MapChip>
        {
            private readonly MapChipList list;
            private int index;
            private readonly int version;

            /// <summary>
            /// 現在列挙されている要素を取得します。
            /// </summary>
            public MapChip Current { get; private set; }
            readonly object IEnumerator.Current
            {
                get
                {
                    if (index == 0 || list.Count + 1 == index) throw new InvalidOperationException("要素の取得に失敗しました");
                    return Current;
                }
            }

            internal Enumerator(MapChipList list)
            {
                this.list = list;
                Current = default;
                index = 0;
                version = list.version;
            }

            /// <summary>
            /// このインスタンスを破棄します。
            /// </summary>
            public void Dispose() { }

            /// <summary>
            /// 列挙を次に進めます。
            /// </summary>
            /// <exception cref="InvalidOperationException">列挙中にコレクションが変更された</exception>
            /// <returns>列挙を次に進められたらtrue，それ以外でfalse</returns>
            public bool MoveNext()
            {
                if (version != list.version) throw new InvalidOperationException("列挙中にコレクションが変更されました");
                if ((uint)index < (uint)list.Count)
                {
                    Current = list[index++];
                    return true;
                }
                Current = default;
                index = list.Count + 1;
                return false;
            }

            void IEnumerator.Reset()
            {
                if (version != list.version) throw new InvalidOperationException("列挙中にコレクションが変更されました");
                Current = default;
                index = 0;
            }
        }

        private sealed class MapChipComparer : IComparer<MapChip>
        {
            public int Compare(MapChip x, MapChip y)
            {
                if (x == null) return y == null ? 0 : -1;
                if (y == null) return 1;
                return x.ZOrder.CompareTo(y.ZOrder);
            }
        }
    }
}
