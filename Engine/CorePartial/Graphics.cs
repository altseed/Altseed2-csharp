using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed
{
    public struct Vertex
    {
        public Vector3F Position;
        public Color Color;
        public Vector2F UV1;
        public Vector2F UV2;
    };

    public struct Color
    {
        public byte R;
        public byte G;
        public byte B;
        public byte A;

        public Color(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }

    public partial class Renderer
    {
        public void DrawPolygon(Vertex[] vertexBuffer, int[] indexBuffer, Texture2D texture = null, Material material = null)
        {
            var vb = VertexArray.Create(vertexBuffer.Length);
            vb.FromArray(vertexBuffer);
            var ib = Int32Array.Create(indexBuffer.Length);
            ib.FromArray(indexBuffer);

            DrawPolygon(vb, ib, texture, material);
        }
    }
}
