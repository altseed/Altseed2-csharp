using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2
{
    class TransformNodeInfo
    {
        TransformNode TransformNode { get; }

        /// <summary>
        /// <see cref="TransformNode.Size"/>の領域を表示する
        /// </summary>
        RenderedPolygon[] SizeBoxLines { get; }

        /// <summary>
        /// <see cref="TransformNode.Pivot"/>の領域を表示する
        /// </summary>
        RenderedPolygon PivotBox { get; }

        public TransformNodeInfo(TransformNode transformNode)
        {
            TransformNode = transformNode;
            SizeBoxLines = new RenderedPolygon[4];
            for (int i = 0; i < SizeBoxLines.Length; i++)
            {
                SizeBoxLines[i] = RenderedPolygon.Create();
                SizeBoxLines[i].Vertexes = VertexArray.Create(4);
            }

            PivotBox = RenderedPolygon.Create();
            PivotBox.Vertexes = VertexArray.Create(4);
        }

        internal void UpdateSize()
        {
            var points = new Vector2F[4];
            points[0] = new Vector2F();
            points[1] = new Vector2F(TransformNode.Size.X, 0);
            points[2] = TransformNode.Size;
            points[3] = new Vector2F(0, TransformNode.Size.Y);

            for (int i = 0; i < points.Length; i++)
            {
                var point1 = points[i];
                var point2 = points[points.Length == i + 1 ? 0 : i + 1];

                var positions = new Vector2F[4];
                var sub = point2 - point1;
                var degree = sub.Degree;
                var x = new Vector2F(sub.Length, 0.0f)
                {
                    Degree = degree
                };
                var y = new Vector2F(0.0f, 2.0f / 2)
                {
                    Degree = degree + 90
                };
                positions[0] = point1 - y;
                positions[1] = point1 + y;
                positions[2] = point1 + x + y;
                positions[3] = point1 + x - y;

                var array = Vector2FArray.Create(positions.Length);
                array.FromArray(positions);
                SizeBoxLines[i].CreateVertexesByVector2F(array);
                SizeBoxLines[i].OverwriteVertexesColor(new Color(200, 200, 200));
            }

            UpdatePivot();
        }

        internal void UpdatePivot()
        {
            var pos = TransformNode.CenterPosition;
            var points = new Vector2F[4];
            points[0] = pos + new Vector2F(-3, -3);
            points[1] = pos + new Vector2F(3, -3);
            points[2] = pos + new Vector2F(3, 3);
            points[3] = pos + new Vector2F(-3, 3);

            var array = Vector2FArray.Create(4);
            array.FromArray(points);
            PivotBox.CreateVertexesByVector2F(array);
            PivotBox.OverwriteVertexesColor(new Color(0, 0, 255));
        }


        public void Draw()
        {
        //    var mat = TransformNode.CalcInheritedTransform();

        //    for (int i = 0; i < SizeBoxLines.Length; i++)
        //    {
        //        SizeBoxLines[i].Transform = mat;
        //        Engine.Renderer.DrawPolygon(SizeBoxLines[i]);
        //    }

        //    PivotBox.Transform = mat;
            Engine.Renderer.DrawPolygon(PivotBox);
        }
    }
}
