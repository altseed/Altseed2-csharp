using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2
{
    /// <summary>
    /// アンカー機能の計算方法を指定します。
    /// </summary>
    [Serializable]
    public enum AnchorMode
    {
        /// <summary>
        /// Size いっぱいに描画されるよう拡大率を計算します。ContentSize の縦横比は保持されません。
        /// </summary>
        Fill,

        /// <summary>
        /// ContentSize の縦横比は保持しつつ、Size に収まって描画されるよう拡大率を計算します。
        /// </summary>
        KeepAspect,

        /// <summary>
        /// ContentSizeのまま表示します
        /// </summary>
        ContentSize,
    }

    /// <summary>
    /// 水平方向の配置
    /// </summary>
    [Serializable]
    public enum HorizontalAlignment
    {
        /// <summary>
        /// 左揃え
        /// </summary>
        Left,

        /// <summary>
        /// 中央揃え
        /// </summary>
        Center,

        /// <summary>
        /// 右揃え
        /// </summary>
        Right,

        /// <summary>
        /// 手動
        /// </summary>
        Manual,
    }

    /// <summary>
    /// 垂直方向の配置
    /// </summary>
    [Serializable]
    public enum VerticalAlignment
    {
        /// <summary>
        /// 上揃え
        /// </summary>
        Top,

        /// <summary>
        /// 中央揃え
        /// </summary>
        Center,

        /// <summary>
        /// 下揃え
        /// </summary>
        Bottom,

        /// <summary>
        /// 手動
        /// </summary>
        Manual,
    }


    /// <summary>
    /// アンカーによって変形するノードのクラス
    /// </summary>
    [Serializable]
    public class AnchorTransformNode : TransformNode, IAnchorTransformInternal
    {
        /// <summary>
        /// 先祖の変形を加味した変形行列を取得します。
        /// </summary>
        public override Matrix44F InheritedTransform
        {
            get => _InheritedTransform;
            internal set
            {
                _InheritedTransform = value;
            }
        }

        /// <summary>
        /// 先祖の変形および<see cref="AnchorMode"/>を加味した最終的な変形行列を取得します。
        /// </summary>
        public override Matrix44F AbsoluteTransform => _InheritedTransform;

        /// <summary>
        /// 座標を取得または設定します。
        /// </summary>
        public override Vector2F Position
        {
            get => _Position;
            set
            {
                if (_Position == value) return;

                _Position = value;
                _RequireCalcTransform = true;

                UpdateMargin();
            }
        }

        void IAnchorTransformInternal.SetPositionDirectly(Vector2F position)
        {
            if (_Position == position) return;

            _Position = position;
            _RequireCalcTransform = true;
        }

        /// <summary>
        /// 中心となる座標をピクセル単位で取得または設定します。
        /// </summary>
        public override Vector2F CenterPosition
        {
            get => Pivot * Size;
            set
            {
                if (Pivot * Size == value) return;

                if (Size.X == 0 || Size.Y == 0)
                {
                    Engine.Log.Warn(LogCategory.Engine, "AnchorTransform Pivot: Size include zero　element.");
                    return;
                }

                Pivot = value / Size;
            }
        }

        /// <summary>
        /// 中心となる座標を[0, 1]で取得または設定します。
        /// </summary>
        public Vector2F Pivot
        {
            get => _Pivot;
            set
            {
                if (_Pivot == value) return;

                _Pivot = value;
                _RequireCalcTransform = true;
            }
        }
        private Vector2F _Pivot;

        /// <summary>
        /// 描画サイズを取得または設定します。
        /// </summary>
        public Vector2F Size
        {
            get => _Size;
            set
            {
                if (value == _Size) return;

                _Size = value;
                _RequireCalcTransform = true;

                UpdateMargin();
                ApplySizeChanged();
            }
        }
        private Vector2F _Size = new Vector2F(1f, 1f);

        void IAnchorTransformInternal.SetSizeDirectly(Vector2F size)
        {
            if (size == _Size) return;

            _Size = size;
            _RequireCalcTransform = true;
        }

        /// <summary>
        /// <see cref="Size" />の左上から親ノードの<see cref="Size" />の左上までの距離
        /// </summary>
        public Vector2F LeftTop
        {
            get => _LeftTop;
            set
            {
                if (_LeftTop == value) return;

                _LeftTop = value;
                UpdateMargin();
            }
        }
        private Vector2F _LeftTop = new Vector2F(0f, 0f);

        /// <summary>
        /// <see cref="Size" />の右下から親ノードの<see cref="Size" />の右下までの距離
        /// </summary>
        public Vector2F RightBottom
        {
            get => _RightBottom;
            set
            {
                if (_RightBottom == value) return;

                _RightBottom = value;
                UpdateMargin();
            }
        }
        private Vector2F _RightBottom = new Vector2F(0f, 0f);

        /// <summary>
        /// アンカー(左上)を取得または設定します。
        /// </summary>
        public Vector2F AnchorMin
        {
            get => _AnchorMin;
            set
            {
                if (value == _AnchorMin) return;
                _AnchorMin = value;

                if (_AnchorMin.X < 0) _AnchorMin.X = 0;
                if (_AnchorMin.X > _AnchorMax.X) _AnchorMax.X = _AnchorMin.X;
                if (_AnchorMin.Y < 0) _AnchorMin.Y = 0;
                if (_AnchorMin.Y > _AnchorMax.Y) _AnchorMax.Y = _AnchorMin.Y;

                UpdateMargin();
                _RequireCalcTransform = true;
            }
        }
        private Vector2F _AnchorMin = new Vector2F(0f, 0f);

        /// <summary>
        /// アンカー(右下)を取得または設定します。
        /// </summary>
        public Vector2F AnchorMax
        {
            get => _AnchorMax;
            set
            {
                if (value == _AnchorMax) return;
                _AnchorMax = value;

                if (_AnchorMax.X > 1) _AnchorMax.X = 1;
                if (_AnchorMax.X < _AnchorMin.X) _AnchorMin.X = _AnchorMax.X;
                if (_AnchorMax.Y > 1) _AnchorMin.Y = 1;
                if (_AnchorMax.Y < _AnchorMin.Y) _AnchorMin.Y = _AnchorMax.Y;

                UpdateMargin();
                _RequireCalcTransform = true;
            }
        }
        private Vector2F _AnchorMax = new Vector2F(1f, 1f);

        /// <summary>
        /// レイアウト自動計算の方法を指定します。
        /// </summary>
        public virtual AnchorMode AnchorMode { get; set; }

        /// <summary>
        /// 水平方向の配置
        /// </summary>
        public virtual HorizontalAlignment HorizontalAlignment { get; set; }

        /// <summary>
        /// 垂直方向の配置
        /// </summary>
        public virtual VerticalAlignment VerticalAlignment { get; set; }

        private protected void ApplySizeChanged()
        {
            foreach (var child in Children)
            {
                ApplySizeChanged(child);
            }
        }

        /// <summary>
        /// <see cref="Size"/>変更時に、直下の<see cref="AnchorTransformNode{T}"/>に対して
        /// <see cref="LeftTop"/>/<see cref="RightBottom"/>/<see cref="AnchorMax"/>/<see cref="AnchorMin"/>を用いて
        /// <see cref="Size"/>/<see cref="Position"/>を更新します。
        /// </summary>
        private void ApplySizeChanged(Node node)
        {
            if (node is IAnchorTransformInternal t)
            {
                var anchorTransform = node.GetAncestorSpecificNode<IAnchorTransform>();
                var anchorDistance = (anchorTransform?.Size ?? new Vector2F()) * (AnchorMax - AnchorMin);

                t.SetSizeDirectly(anchorDistance + t.LeftTop - t.RightBottom);
                t.SetPositionDirectly(t.Size * t.Pivot - t.LeftTop);
            }

            foreach (var child in node.Children)
            {
                ApplySizeChanged(child);
            }
        }

        private protected void UpdateMargin()
        {
            if (Status == RegisteredStatus.Free) return;

            // Margin の更新
            var anchorDistance = (GetAncestorSpecificNode<IAnchorTransform>()?.Size ?? new Vector2F()) * (AnchorMax - AnchorMin);
            _LeftTop = Pivot * Size - Position;
            _RightBottom = anchorDistance + _LeftTop - _Size;
        }

        /// <inheritdoc/>
        private protected override void CalcTransform()
        {
            var scale = Scale * new Vector2F(HorizontalFlip ? -1 : 1, VerticalFlip ? -1 : 1);
            var offset = (GetAncestorSpecificNode<IAnchorTransform>()?.Size ?? default) * AnchorMin;

            Transform = Matrix44F.GetTranslation2D(offset) * MathHelper.CalcTransform(Position, MathHelper.DegreeToRadian(Angle), scale) * Matrix44F.GetTranslation2D(-CenterPosition);
            //_TransformNodeInfo?.Update();
            _RequireCalcTransform = false;
        }

        #region Node

        internal override void Registered()
        {
            base.Registered();

            UpdateMargin();
        }

        internal override void Unregistered()
        {
            base.Unregistered();
        }

        #endregion
    }

    /// <summary>
    /// アンカーによって変形するノードのクラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class AnchorTransformNode<T> : AnchorTransformNode, IAnchorTransformInternal, ICullableDrawn
        where T : Node, ICullableDrawn, new()
    {
        /// <summary>
        /// 元となるのノード
        /// </summary>
        public T Source { get; }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public AnchorTransformNode()
        {
            Source = new T();
        }

        /// <summary>
        /// サイズとコンテンツの関係を取得または設定します。
        /// </summary>
        public override AnchorMode AnchorMode
        {
            get => _AnchorMode;
            set
            {
                if (_AnchorMode == value) return;

                _AnchorMode = value;
                _RequireCalcTransform = true;
            }
        }
        private AnchorMode _AnchorMode = AnchorMode.ContentSize;

        /// <summary>
        /// 水平方向の配置
        /// </summary>
        public override HorizontalAlignment HorizontalAlignment
        {
            get => _HorizontalAlignment;
            set
            {
                if (value == _HorizontalAlignment) return;

                _HorizontalAlignment = value;
                _RequireCalcTransform = true;
            }
        }
        private HorizontalAlignment _HorizontalAlignment = HorizontalAlignment.Left;

        /// <summary>
        /// 垂直方向の配置
        /// </summary>
        public override VerticalAlignment VerticalAlignment
        {
            get => _VerticalAlignment;
            set
            {
                if (value == _VerticalAlignment)
                    return;

                _VerticalAlignment = value;
                _RequireCalcTransform = true;
            }
        }
        private VerticalAlignment _VerticalAlignment = VerticalAlignment.Top;

        /// <summary>
        /// 先祖の変形を加味した変形行列を取得します。
        /// </summary>
        public override Matrix44F InheritedTransform
        {
            get => _InheritedTransform;
            internal set
            {
                _InheritedTransform = value;
                Source.Rendered.Transform = value * CalcInternalTransform();
            }
        }

        private Matrix44F CalcInternalTransform()
        {
            var res = Matrix44F.Identity;
            var relativeSize = Size;
            switch (AnchorMode)
            {
                case AnchorMode.Fill:
                    res *= Matrix44F.GetScale2D(Size / ContentSize);
                    break;

                case AnchorMode.KeepAspect:
                    if (Size.X / Size.Y > ContentSize.X / ContentSize.Y)
                        relativeSize.X = ContentSize.X * Size.Y / ContentSize.Y;
                    else
                        relativeSize.Y = ContentSize.Y * Size.X / ContentSize.X;

                    res *= Matrix44F.GetScale2D(relativeSize / ContentSize);
                    break;

                case AnchorMode.ContentSize:
                    break;

                default: throw new InvalidOperationException(nameof(AnchorMode));
            }

            switch (HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    break;
                case HorizontalAlignment.Center:
                    res = Matrix44F.GetTranslation2D(new Vector2F((Size.X - relativeSize.X) / 2, 0)) * res;
                    break;
                case HorizontalAlignment.Right:
                    res = Matrix44F.GetTranslation2D(new Vector2F(Size.X - relativeSize.X, 0)) * res;
                    break;
                default:
                    break;
            }

            switch (VerticalAlignment)
            {
                case VerticalAlignment.Top:
                    break;
                case VerticalAlignment.Center:
                    res = Matrix44F.GetTranslation2D(new Vector2F(0, (Size.Y - relativeSize.Y) / 2)) * res;
                    break;
                case VerticalAlignment.Bottom:
                    res = Matrix44F.GetTranslation2D(new Vector2F(0, Size.Y - relativeSize.Y)) * res;
                    break;
                default:
                    break;
            }

            return res;
        }

        #region Node

        internal override void Registered()
        {
            base.Registered();
            Engine.RegisterDrawn(this);
            Engine.CullingSystem.Register(Source.Rendered);
        }

        internal override void Unregistered()
        {
            base.Unregistered();
            Engine.UnregisterDrawn(this);
            Engine.CullingSystem.Unregister(Source.Rendered);
        }

        #endregion

        #region IDrawn

        Rendered ICullableDrawn.Rendered => Source.Rendered;

        void IDrawn.Draw()
        {
            Source.Draw();
        }

        /// <summary>
        /// カリング用ID
        /// </summary>
        int ICullableDrawn.CullingId => Source.Rendered.Id;

        /// <summary>
        /// コンテンツのサイズを取得します。
        /// </summary>
        public override Vector2F ContentSize => Source.ContentSize;

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

                if (Status == RegisteredStatus.Registered)
                {
                    Engine.UpdateDrawnZOrder(this, old);
                }
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
        /// 先祖の<see cref="IsDrawn" />を考慮して、このノードを描画するかどうかを取得します。
        /// </summary>
        public bool IsDrawnActually => (this as ICullableDrawn).IsDrawnActually;
        bool ICullableDrawn.IsDrawnActually { get; set; } = true;

        #endregion
    }
}
