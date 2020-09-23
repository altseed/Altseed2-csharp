﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace Altseed2
{
    /// <summary>
    /// ポリゴンコライダを管理するノード
    /// </summary>
    [Serializable]
    public class PolygonColliderNode : ColliderNode
    {
        private bool requireUpdate = true;

        /// <inheritdoc/>
        public sealed override Vector2F ContentSize
        {
            get
            {
                MathHelper.GetMinMax(out var min, out var max, PolygonCollider.VertexesInternal);
                return max - min;
            }
        }

        /// <summary>
        /// 使用するコライダを取得します。
        /// </summary>
        internal PolygonCollider PolygonCollider { get; }
        internal override Collider Collider => PolygonCollider;

        /// <inheritdoc/>
        public sealed override Matrix44F InheritedTransform
        {
            get => base.InheritedTransform;
            private protected set
            {
                if (base.InheritedTransform == value) return;
                base.InheritedTransform = value;
                AbsoluteTransform = value * Matrix44F.GetTranslation2D(-CenterPosition);
                requireUpdate = true;
                Collider.Transform = AbsoluteTransform;
            }
        }

        /// <summary>
        /// 頂点情報の配列を取得または設定します。
        /// </summary>
        /// <exception cref="ArgumentNullException">設定しようとした値がnull</exception>
        public IReadOnlyList<Vector2F> Vertexes
        {
            get => PolygonCollider.Vertexes;
            set
            {
                PolygonCollider.SetVertexes(value);
                requireUpdate = true;
            }
        }

        /// <summary>
        /// 既定の<see cref="Altseed2.PolygonCollider"/>を使用して<see cref="PolygonColliderNode"/>の新しいインスタンスを生成します。
        /// </summary>
        public PolygonColliderNode() : this(null) { }

        /// <summary>
        /// 指定した<see cref="Altseed2.PolygonCollider"/>を使用して<see cref="PolygonColliderNode"/>の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="collider">使用する<see cref="Altseed2.PolygonCollider"/>のインスタンス</param>
        internal PolygonColliderNode(PolygonCollider collider)
        {
            PolygonCollider = collider ?? PolygonCollider.Create();
        }

        /// <summary>
        /// 指定した座標に頂点を設定します。
        /// </summary>
        /// <param name="positions">設定する座標</param>
        /// <exception cref="ArgumentNullException"><paramref name="positions"/>がnull</exception>
        public void SetVertexes(IEnumerable<Vector2F> positions)
        {
            PolygonCollider.SetVertexes(positions);
            requireUpdate = true;
        }

        /// <summary>
        /// 指定した座標に頂点を設定する
        /// </summary>
        /// <param name="positions">設定する座標</param>
        public void SetVertexes(Span<Vector2F> positions)
        {
            PolygonCollider.SetVertexes(positions);
            requireUpdate = true;
        }

        internal override void UpdateCollider()
        {
            if (!requireUpdate) return;

            var scale = CalcScale(InheritedTransform);

            if (Vertexes != null)
            {
                var array = new Vector2F[Vertexes.Count];
                for (int i = 0; i < Vertexes.Count; i++) array[i] = Vertexes[i] * scale - CenterPosition;
                PolygonCollider.Vertexes = array;
            }
            else PolygonCollider.Vertexes = Array.Empty<Vector2F>();

            UpdateVersion();
            requireUpdate = false;
        }
    }

    [Serializable]
    internal sealed class PolygonColliderVisualizeNode : PolygonNode
    {
        private readonly PolygonColliderNode _Owner;
        private int _CurrentVersion;

        internal PolygonColliderVisualizeNode(PolygonColliderNode owner)
        {
            _Owner = owner;
            _CurrentVersion = owner._Version;

            UpdatePolygon();
        }

        internal override void Update()
        {
            if (_CurrentVersion != _Owner._Version)
                UpdatePolygon();

            base.Update();
        }

        private void UpdatePolygon()
        {
            if (_Owner.PolygonCollider.VertexesInternal is Vector2FArray array)
            {

                SetVertexesFromPositions(array, ColliderVisualizeNodeFactory.AreaColor, true);
            }
            else
            {
                Span<Vector2F> span = stackalloc Vector2F[0];
                SetVertexes(span, ColliderVisualizeNodeFactory.AreaColor);
            }
            CenterPosition = _Owner.CenterPosition;

            _CurrentVersion = _Owner._Version;
        }
    }
}
