using System;
using System.Linq;
using System.Collections.Generic;

namespace Altseed2
{
    /// <summary>
    /// 図形を描画するノードを表します。
    /// </summary>
    [Serializable]
    public class PolygonNode : TransformNode, ICullableDrawn/*, ISized*/
    {
        protected private readonly RenderedPolygon _RenderedPolygon;

        private bool _IsValid = false;

        /// <summary>
        /// <see cref="PolygonNode"/>の新しいインスタンスを生成します。
        /// </summary>
        /// <exception cref="InvalidOperationException">Graphics機能が初期化されていない。</exception>
        public PolygonNode()
        {
            if (!Engine.Config.EnabledCoreModules.HasFlag(CoreModules.Graphics))
            {
                throw new InvalidOperationException("Graphics機能が初期化されていません。");
            }

            _RenderedPolygon = RenderedPolygon.Create();
        }

        #region IDrawn

        Rendered ICullableDrawn.Rendered => _RenderedPolygon;

        void IDrawn.Draw()
        {
            if (_IsValid) Engine.Renderer.DrawPolygon(_RenderedPolygon);
        }

        /// <summary>
        /// カリング用ID
        /// </summary>
        int ICullableDrawn.CullingId => _RenderedPolygon.Id;

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
            Engine.CullingSystem.Register(_RenderedPolygon);
        }

        internal override void Unregistered()
        {
            base.Unregistered();
            Engine.UnregisterDrawn(this);
            Engine.CullingSystem.Unregister(_RenderedPolygon);
        }

        /// <inheritdoc/>
        public override void FlushQueue()
        {
            base.FlushQueue();
            this.UpdateIsDrawnActuallyOfDescendants();
        }

        #endregion

        #region RenderedPolygon

        /// <summary>
        /// ブレンドモードを取得または設定します。
        /// </summary>
        public AlphaBlend AlphaBlend
        {
            get => _RenderedPolygon.AlphaBlend;
            set
            {
                if (_RenderedPolygon.AlphaBlend == value) return;
                _RenderedPolygon.AlphaBlend = value;
            }
        }

        /// <summary>
        /// <see cref="Texture"/>を切り出す範囲を取得または設定します。
        /// </summary>
        public RectF Src
        {
            get => _RenderedPolygon.Src;
            set
            {
                if (_RenderedPolygon.Src == value) return;

                _RenderedPolygon.Src = value;
                _RequireCalcTransform = true;
            }
        }

        /// <summary>
        /// 描画するテクスチャを取得または設定します。
        /// </summary>
        public TextureBase Texture
        {
            get => _RenderedPolygon.Texture;
            set
            {
                if (_RenderedPolygon.Texture == value) return;

                _RenderedPolygon.Texture = value;
                if (value != null)
                    Src = new RectF(0, 0, value.Size.X, value.Size.Y);
                _RequireCalcTransform = true;
            }
        }

        /// <summary>
        /// 描画に適用するマテリアルを取得または設定します。
        /// </summary>
        public Material Material
        {
            get => _RenderedPolygon.Material;
            set
            {
                if (_RenderedPolygon.Material == value) return;

                _RenderedPolygon.Material = value;
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
                _RenderedPolygon.Transform = AbsoluteTransform;
            }
        }

        #endregion

        internal VertexArray VertexeArray => _RenderedPolygon.Vertexes;

        /// <summary>
        /// 頂点情報のコレクションを取得または設定します。
        /// </summary>
        public IReadOnlyList<Vertex> Vertexes
        {
            get => _RenderedPolygon.Vertexes?.ToArray();
            set
            {
                _RenderedPolygon.Vertexes.FromEnumerable(value);
                SetVertexes(_RenderedPolygon.Vertexes);
            }
        }

        /// <summary>
        /// 頂点情報が有効かどうかを判定します。
        /// </summary>
        /// <param name="vertexes">頂点情報</param>
        private bool Validate(VertexArray vertexes)
        {
            if (vertexes.Count < 3)
            {
                Engine.Log.Info(LogCategory.Engine, $"{GetType()} に設定された頂点が 3 個未満のためこのノードは描画されません。");
                return false;
            }

            //for (int i = 0; i < vertexes.Count; ++i)
            //    for (int j = i + 1; j < vertexes.Count; ++j)
            //        if (vertexes[i].Position == vertexes[j].Position)
            //        {
            //            Engine.Log.Info(LogCategory.Engine, $"{GetType()} に設定された頂点に重複があるためこのノードは描画されません。");
            //            return false;
            //        }
            return true;
        }

        /// <summary>
        /// 頂点情報が有効かどうかを判定します。
        /// </summary>
        /// <param name="vertexes">頂点情報</param>
        private bool Validate(Vector2FArray vertexes)
        {
            if (vertexes.Count < 3)
            {
                Engine.Log.Info(LogCategory.Engine, $"{GetType()} に設定された頂点が 3 個未満のためこのノードは描画されません。");
                return false;
            }

            //for (int i = 0; i < vertexes.Count; ++i)
            //    for (int j = i + 1; j < vertexes.Count; ++j)
            //        if (vertexes[i] == vertexes[j])
            //        {
            //            Engine.Log.Info(LogCategory.Engine, $"{GetType()} に設定された頂点に重複があるためこのノードは描画されません。");
            //            return false;
            //        }
            return true;
        }

        internal void SetVertexes(VertexArray array, bool resetIB = true)
        {
            _RenderedPolygon.Vertexes = array;
            _IsValid = Validate(array);
            _RequireCalcTransform = true;
            if (resetIB) SetDefaultIndexBuffer();
        }

        /// <summary>
        /// 座標をもとに頂点情報を設定します。
        /// </summary>
        /// <param name="vertexes">設定する各頂点の座標を格納する<see cref="Span{Vertex}" /></param>
        /// <param name="resetIB"><see cref="Buffers"/>を自動計算したものに設定するかどうか</param>
        /// <remarks>
        /// 色は白(255, 255, 255)に設定されます。
        /// </remarks>
        public void SetVertexes(ReadOnlySpan<Vertex> vertexes, bool resetIB = true)
        {
            _RenderedPolygon.Vertexes.FromSpan(vertexes);
            SetVertexes(_RenderedPolygon.Vertexes, resetIB);
        }

        /// <summary>
        /// 座標をもとに頂点情報を設定します。
        /// </summary>
        /// <param name="vertexes">設定する各頂点の座標を格納する<see cref="IEnumerable{Vertex}" /></param>
        /// <param name="resetIB"><see cref="Buffers"/>を自動計算したものに設定するかどうか</param>
        /// <remarks>
        /// 色は白(255, 255, 255)に設定されます。
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="vertexes"/>がnullです。</exception>
        public void SetVertexes(IEnumerable<Vertex> vertexes, bool resetIB = true)
        {
            _RenderedPolygon.Vertexes.FromEnumerable(vertexes);
            SetVertexes(_RenderedPolygon.Vertexes, resetIB);
        }

        /// <summary>
        /// 座標をもとに頂点情報を設定します。
        /// </summary>
        /// <param name="vertexes">設定する各頂点の座標を格納する<see cref="Span{Vector2F}" /></param>
        /// <param name="color">各頂点に設定する色</param>
        /// <param name="resetIB"><see cref="Buffers"/>を自動計算したものに設定するかどうか</param>
        public void SetVertexes(ReadOnlySpan<Vector2F> vertexes, Color color, bool resetIB = true)
        {
            Engine.Vector2FArrayCache.FromSpan(vertexes);
            SetVertexesFromPositions(Engine.Vector2FArrayCache, color, resetIB);
        }

        /// <summary>
        /// 座標をもとに頂点情報を設定します。
        /// </summary>
        /// <param name="vertexes">設定する各頂点の座標を格納する<see cref="IEnumerable{Vector2F}" /></param>
        /// <param name="color">各頂点に設定する色</param>
        /// <param name="resetIB"><see cref="Buffers"/>を自動計算したものに設定するかどうか</param>
        /// <exception cref="ArgumentNullException"><paramref name="vertexes"/>がnullです。</exception>
        public void SetVertexes(IEnumerable<Vector2F> vertexes, Color color, bool resetIB = true)
        {
            Engine.Vector2FArrayCache.FromEnumerable(vertexes);
            SetVertexesFromPositions(Engine.Vector2FArrayCache, color, resetIB);
        }

        internal void SetVertexesFromPositions(Vector2FArray array, Color color, bool resetIB)
        {
            _RenderedPolygon.CreateVertexesByVector2F(array);
            _RenderedPolygon.OverwriteVertexesColor(color);
            _IsValid = Validate(array);
            _RequireCalcTransform = true;
            if (resetIB) SetDefaultIndexBuffer();
        }

        /// <summary>
        /// 各頂点に指定した色を設定します。
        /// </summary>
        /// <param name="color">設定する色</param>
        public void OverwriteVertexColor(Color color)
        {
            _RenderedPolygon.OverwriteVertexesColor(color);
        }

        /// <summary>
        /// インデックスバッファを取得または設定します。
        /// </summary>
        /// <exception cref="ArgumentNullException">設定しようとした値がnull</exception>
        /// <remarks>大きさは3の倍数である必要があります。余った要素は無視されます。</remarks>
        public IReadOnlyList<int> Buffers
        {
            get => _RenderedPolygon.Buffers?.ToArray();
            set
            {
                _RenderedPolygon.Buffers.FromEnumerable(value);
                SetBuffers(_RenderedPolygon.Buffers);
            }
        }

        internal void SetBuffers(Int32Array array)
        {
            _RenderedPolygon.Buffers = array;
        }

        /// <summary>
        /// インデックスバッファーを設定します。
        /// </summary>
        /// <param name="buffers">設定するインデックスバッファー</param>
        /// <remarks>大きさは3の倍数である必要があります。余った要素は無視されます。</remarks>
        public void SetBuffers(ReadOnlySpan<int> buffers)
        {
            var mod = buffers.Length % 3;
            ReadOnlySpan<int> sizedBuffer;
            if (mod == 0) sizedBuffer = buffers;
            else sizedBuffer = buffers.Slice(0, buffers.Length - mod);
            _RenderedPolygon.Buffers.FromSpan(sizedBuffer);
            SetBuffers(_RenderedPolygon.Buffers);
        }

        /// <summary>
        /// インデックスバッファーを設定します。
        /// </summary>
        /// <param name="buffers">設定するインデックスバッファー</param>
        /// <exception cref="ArgumentNullException"><paramref name="buffers"/>がnull</exception>
        /// <remarks>大きさは3の倍数である必要があります。余った要素は無視されます。</remarks>
        public void SetBuffers(IEnumerable<int> buffers)
        {
            if (buffers == null) throw new ArgumentNullException(nameof(buffers), "引数がnullです");
            var array = buffers is int[] a ? a : buffers.ToArray();
            int[] sizedArray;
            var mod = array.Length % 3;
            if (mod == 0) sizedArray = array;
            else
            {
                sizedArray = new int[array.Length - mod];
                Array.Copy(array, sizedArray, sizedArray.Length);
            }
            _RenderedPolygon.Buffers.FromSpan(sizedArray);
            SetBuffers(_RenderedPolygon.Buffers);
        }

        /// <summary>
        /// 設定した頂点のグループを設定し，そのグループごとに<see cref="PolygonNode"/>と同様の方式でインデックスバッファーを設定します。
        /// </summary>
        /// <param name="vertexes">設定する頂点のグループ</param>
        /// <exception cref="ArgumentNullException"><paramref name="vertexes"/>または<paramref name="vertexes"/>内の要素がnull</exception>
        public void SetVertexGroups(IEnumerable<IEnumerable<Vertex>> vertexes)
        {
            if (vertexes == null) throw new ArgumentNullException(nameof(vertexes), "引数がnullです");
            var vertexList = new List<Vertex>();
            var bufferList = new List<int>();
            var totalCount = 0;
            foreach (var currentVertexes in vertexes)
            {
                if (currentVertexes == null) throw new ArgumentNullException(nameof(vertexes), "要素の一つがnullです");
                var array = currentVertexes is Vertex[] v ? v : currentVertexes.ToArray();
                if (array.Length < 3) continue;
                for (int i = 0; i < array.Length; i++) vertexList.Add(array[i]);
                for (int i = 0; i < array.Length - 2; i++)
                {
                    bufferList.Add(totalCount);
                    bufferList.Add(totalCount + i + 1);
                    bufferList.Add(totalCount + i + 2);
                }
                totalCount += array.Length;
            }
            SetVertexes(vertexList, false);
            SetBuffers(bufferList);
        }

        /// <summary>
        /// 設定した座標をもとに頂点のグループを設定し，そのグループごとに<see cref="PolygonNode"/>と同様の方式でインデックスバッファーを設定します。
        /// </summary>
        /// <param name="vertexes">設定する頂点のグループ</param>
        /// <param name="color">設定する色</param>
        /// <exception cref="ArgumentNullException"><paramref name="vertexes"/>または<paramref name="vertexes"/>内の要素がnull</exception>
        public void SetVertexGroupsFromPositions(IEnumerable<IEnumerable<Vector2F>> vertexes, Color color)
        {
            if (vertexes == null) throw new ArgumentNullException(nameof(vertexes), "引数がnullです");
            var vertexList = new List<Vertex>();
            var bufferList = new List<int>();
            var totalCount = 0;
            foreach (var currentVertexes in vertexes)
            {
                if (currentVertexes == null) throw new ArgumentNullException(nameof(vertexes), "要素の一つがnullです");
                var array = currentVertexes is Vector2F[] v ? v : currentVertexes.ToArray();
                if (array.Length < 3) continue;
                MathHelper.GetMinMax(out var min, out var max, array);
                var size = max - min;
                if (size.X == 0) size.X = 1f;
                if (size.Y == 0) size.Y = 1f;
                for (int i = 0; i < array.Length; i++) vertexList.Add(new Vertex(new Vector3F(array[i].X, array[i].Y, 0.5f), color, (array[i] - min) / size, default));
                for (int i = 0; i < array.Length - 2; i++)
                {
                    bufferList.Add(totalCount);
                    bufferList.Add(totalCount + i + 1);
                    bufferList.Add(totalCount + i + 2);
                }
                totalCount += array.Length;
            }
            SetVertexes(vertexList, false);
            SetBuffers(bufferList);
        }

        /// <summary>
        /// <see cref="PolygonNode"/>と同様の方法でインデックスバッファの設定を行います。
        /// </summary>
        public void SetDefaultIndexBuffer() => _RenderedPolygon.SetDefaultIndexBuffer();

        /// <inheritdoc/>
        public sealed override Vector2F ContentSize
        {
            get
            {
                MathHelper.GetMinMax(out var min, out var max, _RenderedPolygon.Vertexes);
                return max - min;
            }
        }
    }
}
