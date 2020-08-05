using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Altseed2
{
    /// <summary>
    /// 頂点の情報を格納する構造体
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vertex : IEquatable<Vertex>
    {
        /// <summary>
        /// 座標
        /// </summary>
        public Vector3F Position;
        /// <summary>
        /// 色
        /// </summary>
        public Color Color;
        /// <summary>
        /// UV値1
        /// </summary>
        public Vector2F UV1;
        /// <summary>
        /// UV値2
        /// </summary>
        public Vector2F UV2;

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="position">座標</param>
        /// <param name="color">色</param>
        /// <param name="uv1">UV1</param>
        /// <param name="uv2">UV2</param>
        public Vertex(Vector3F position, Color color, Vector2F uv1, Vector2F uv2)
        {
            Position = position;
            Color = color;
            UV1 = uv1;
            UV2 = uv2;
        }

        /// <summary>
        /// もう一つの<see cref="Vertex"/>との間の等価性を判定する
        /// </summary>
        /// <param name="other">等価線を判定する<see cref="Vertex"/>のインスタンス</param>
        /// <returns><paramref name="other"/>との間との等価性が認められたらtrue，それ以外でfalse</returns>
        public readonly bool Equals(Vertex other) => Position == other.Position && Color == other.Color && UV1 == other.UV1 && UV2 == other.UV2;

        /// <summary>
        /// オブジェクトとの等価性を判定する
        /// </summary>
        /// <param name="obj">等価性を判定するオブジェクト</param>
        /// <returns><paramref name="obj"/>との間との等価性が認められたらtrue，それ以外でfalse</returns>
        public readonly override bool Equals(object obj) => obj is Vertex v && Equals(v);

        /// <summary>
        /// このインスタンスのハッシュコードを返す
        /// </summary>
        /// <returns>このインスタンスのハッシュコード</returns>
        public readonly override int GetHashCode() => HashCode.Combine(Position, Color, UV1, UV2);

        public static bool operator ==(Vertex v1, Vertex v2) => v1.Equals(v2);
        public static bool operator !=(Vertex v1, Vertex v2) => !v1.Equals(v2);
    };

    /// <summary>
    /// 色を表す構造体
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Color : IEquatable<Color>
    {
        /// <summary>
        /// R値
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        public byte R;
        /// <summary>
        /// G値
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        public byte G;
        /// <summary>
        /// B値
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        public byte B;
        /// <summary>
        /// A値
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        public byte A;

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="r">R値</param>
        /// <param name="g">G値</param>
        /// <param name="b">B値</param>
        /// <param name="a">A値</param>
        public Color(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="r">R値</param>
        /// <param name="g">G値</param>
        /// <param name="b">B値</param>
        /// <param name="a">A値</param>
        public Color(int r, int g, int b, int a)
        {
            R = Convert(r);
            G = Convert(g);
            B = Convert(b);
            A = Convert(a);
        }
        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="r">R値</param>
        /// <param name="g">G値</param>
        /// <param name="b">B値</param>
        public Color(byte r, byte g, byte b) : this(r, g, b, (byte)255) { }

        private static byte Convert(int value)
        {
            if (value < 0) return 0;
            if (value > 255) return 255;
            return (byte)value;
        }

        /// <summary>
        /// もう一つの<see cref="Color"/>との間の等価性を判定する
        /// </summary>
        /// <param name="other">等価線を判定する<see cref="Color"/>のインスタンス</param>
        /// <returns><paramref name="other"/>との間との等価性が認められたらtrue，それ以外でfalse</returns>
        public readonly bool Equals(Color other) => R == other.R && G == other.G && B == other.B && A == other.A;

        /// <summary>
        /// オブジェクトとの等価性を判定する
        /// </summary>
        /// <param name="obj">等価性を判定するオブジェクト</param>
        /// <returns><paramref name="obj"/>との間との等価性が認められたらtrue，それ以外でfalse</returns>
        public readonly override bool Equals(object obj) => obj is Color c && Equals(c);

        /// <summary>
        /// このインスタンスのハッシュコードを返す
        /// </summary>
        /// <returns>このインスタンスのハッシュコード</returns>
        public readonly override int GetHashCode() => HashCode.Combine(R, G, B, A);

        /// <summary>
        /// このインスタンスを表す文字列を取得する
        /// </summary>
        /// <returns>このインスタンスを表す文字列</returns>
        public readonly override string ToString() => $"({R}, {G}, {B}, {A})";

        public static bool operator ==(Color c1, Color c2) => c1.Equals(c2);
        public static bool operator !=(Color c1, Color c2) => !c1.Equals(c2);
        public static Color operator +(Color c1, Color c2) => new Color(c1.R + c2.R, c1.G + c2.G, c1.B + c2.B, c1.A + c2.A);
        public static Color operator -(Color c1, Color c2) => new Color(c1.R - c2.R, c1.G - c2.G, c1.B - c2.B, c1.A - c2.A);
        public static Color operator *(Color color, byte value) => new Color(color.R * value, color.G * value, color.B * value, color.A * value);
        public static Color operator *(byte value, Color color) => new Color(color.R * value, color.G * value, color.B * value, color.A * value);
        public static Color operator /(Color color, byte value) => new Color(color.R / value, color.G / value, color.B / value, color.A / value);
    }

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct RenderPassParameter : IEquatable<RenderPassParameter>
    {
        public Color ClearColor;

        [MarshalAs(UnmanagedType.Bool)]
        public bool IsColorCleared;

        [MarshalAs(UnmanagedType.Bool)]
        public bool IsDepthCleared;

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="clearColor"></param>
        /// <param name="isColorCleared"></param>
        /// <param name="isDepthCleared"></param>
        public RenderPassParameter(Color clearColor, bool isColorCleared, bool isDepthCleared)
        {
            ClearColor = clearColor;
            IsColorCleared = isColorCleared;
            IsDepthCleared = isDepthCleared;
        }

        /// <summary>
        /// もう一つの<see cref="RenderPassParameter"/>との間の等価性を判定する
        /// </summary>
        /// <param name="other">等価線を判定する<see cref="RenderPassParameter"/>のインスタンス</param>
        /// <returns><paramref name="other"/>との間との等価性が認められたらtrue，それ以外でfalse</returns>
        public readonly bool Equals(RenderPassParameter other) => ClearColor == other.ClearColor && IsColorCleared == other.IsColorCleared && IsDepthCleared == other.IsDepthCleared;
        /// <summary>
        /// オブジェクトとの等価性を判定する
        /// </summary>
        /// <param name="obj">等価性を判定するオブジェクト</param>
        /// <returns><paramref name="obj"/>との間との等価性が認められたらtrue，それ以外でfalse</returns>
        public readonly override bool Equals(object obj) => obj is RenderPassParameter p && Equals(p);

        /// <summary>
        /// このインスタンスのハッシュコードを返す
        /// </summary>
        /// <returns>このインスタンスのハッシュコード</returns>
        public readonly override int GetHashCode() => HashCode.Combine(ClearColor, IsColorCleared, IsDepthCleared);

        public static bool operator ==(RenderPassParameter left, RenderPassParameter right) => left.Equals(right);
        public static bool operator !=(RenderPassParameter left, RenderPassParameter right) => !(left == right);
    }

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct AlphaBlend : IEquatable<AlphaBlend>
    {
        [MarshalAs(UnmanagedType.Bool)]
        public bool IsBlendEnabled;
        public BlendFunction BlendSrcFunc;
        public BlendFunction BlendDstFunc;
        public BlendFunction BlendSrcFuncAlpha;
        public BlendFunction BlendDstFuncAlpha;
        public BlendEquation BlendEquationRGB;
        public BlendEquation BlendEquationAlpha;

        /// <summary>
        /// もう一つの<see cref="AlphaBlend"/>との間の等価性を判定する
        /// </summary>
        /// <param name="other">等価線を判定する<see cref="AlphaBlend"/>のインスタンス</param>
        /// <returns><paramref name="other"/>との間との等価性が認められたらtrue，それ以外でfalse</returns>
        public readonly bool Equals(AlphaBlend other)
        {
            return BlendSrcFunc == other.BlendSrcFunc
                && BlendDstFunc == other.BlendDstFunc
                && BlendSrcFuncAlpha == other.BlendSrcFuncAlpha
                && BlendDstFuncAlpha == other.BlendDstFuncAlpha
                && BlendEquationRGB == other.BlendEquationRGB
                && BlendEquationAlpha == other.BlendEquationAlpha
            ;
        }

        /// <summary>
        /// オブジェクトとの等価性を判定する
        /// </summary>
        /// <param name="obj">等価性を判定するオブジェクト</param>
        /// <returns><paramref name="obj"/>との間との等価性が認められたらtrue，それ以外でfalse</returns>
        public readonly override bool Equals(object obj) => obj is AlphaBlend p && Equals(p);

        /// <summary>
        /// このインスタンスのハッシュコードを返す
        /// </summary>
        /// <returns>このインスタンスのハッシュコード</returns>
        public readonly override int GetHashCode()
        {
            return HashCode.Combine(IsBlendEnabled, BlendDstFunc, BlendDstFunc, BlendSrcFuncAlpha, BlendDstFuncAlpha, BlendEquationRGB, BlendEquationAlpha);
        }

        public static bool operator ==(AlphaBlend left, AlphaBlend right) => left.Equals(right);
        public static bool operator !=(AlphaBlend left, AlphaBlend right) => !(left == right);

        public static AlphaBlend Normal =>
            new AlphaBlend {
                IsBlendEnabled = true,
                BlendSrcFunc = BlendFunction.SrcAlpha,
                BlendDstFunc = BlendFunction.OneMinusSrcAlpha,
                BlendSrcFuncAlpha = BlendFunction.One,
                BlendDstFuncAlpha = BlendFunction.One,
                BlendEquationRGB = BlendEquation.Add,
                BlendEquationAlpha = BlendEquation.Max
            };

        public static AlphaBlend Add =>
            new AlphaBlend
            {
                IsBlendEnabled = true,
                BlendSrcFunc = BlendFunction.SrcAlpha,
                BlendDstFunc = BlendFunction.One,
                BlendSrcFuncAlpha = BlendFunction.One,
                BlendDstFuncAlpha = BlendFunction.One,
                BlendEquationRGB = BlendEquation.Add,
                BlendEquationAlpha = BlendEquation.Max
            };

        public static AlphaBlend Opacity =>
            new AlphaBlend
            {
                IsBlendEnabled = false,
                BlendSrcFunc = BlendFunction.One,
                BlendDstFunc = BlendFunction.Zero,
                BlendSrcFuncAlpha = BlendFunction.One,
                BlendDstFuncAlpha = BlendFunction.One,
                BlendEquationRGB = BlendEquation.Add,
                BlendEquationAlpha = BlendEquation.Max
            };
        
        public static AlphaBlend Substract =>
            new AlphaBlend
            {
                IsBlendEnabled = true,
                BlendSrcFunc = BlendFunction.SrcAlpha,
                BlendDstFunc = BlendFunction.One,
                BlendSrcFuncAlpha = BlendFunction.One,
                BlendDstFuncAlpha = BlendFunction.One,
                BlendEquationRGB = BlendEquation.ReverseSub,
                BlendEquationAlpha = BlendEquation.Max
            };

        public static AlphaBlend Multiply =>
            new AlphaBlend
            {
                IsBlendEnabled = true,
                BlendSrcFunc = BlendFunction.Zero,
                BlendDstFunc = BlendFunction.SrcColor,
                BlendSrcFuncAlpha = BlendFunction.One,
                BlendDstFuncAlpha = BlendFunction.One,
                BlendEquationRGB = BlendEquation.Add,
                BlendEquationAlpha = BlendEquation.Max
            };
    }

    public partial class Shader
    {
        partial void Deserialize_GetPtr(ref IntPtr ptr, SerializationInfo info)
        {
            Shader_Unsetter_Deserialize(info, out var stage, out var code, out var name);
            ptr = cbg_Shader_Compile(name, code, (int)stage);
        }
    }
}
