using System;
using System.Runtime.InteropServices;

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
        /// <see cref="Vertex"/>の新しいインスタンスを生成します。
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
        /// もう一つの<see cref="Vertex"/>との間の等価性を判定します。
        /// </summary>
        /// <param name="other">等価線を判定する<see cref="Vertex"/>のインスタンス</param>
        /// <returns><paramref name="other"/>との間との等価性が認められたらtrue，それ以外でfalse</returns>
        public readonly bool Equals(Vertex other) => Position == other.Position && Color == other.Color && UV1 == other.UV1 && UV2 == other.UV2;

        /// <summary>
        /// オブジェクトとの等価性を判定します。
        /// </summary>
        /// <param name="obj">等価性を判定するオブジェクト</param>
        /// <returns><paramref name="obj"/>との間との等価性が認められたらtrue，それ以外でfalse</returns>
        public readonly override bool Equals(object obj) => obj is Vertex v && Equals(v);

        /// <summary>
        /// このインスタンスのハッシュコードを返します。
        /// </summary>
        /// <returns>このインスタンスのハッシュコード</returns>
        public readonly override int GetHashCode() => HashCode.Combine(Position, Color, UV1, UV2);

        /// <summary>
        /// 二つの<see cref="Vertex"/>の間の等価性を判定します。
        /// </summary>
        /// <param name="v1">等価性を判定する<see cref="Vertex"/>のインスタンス</param>
        /// <param name="v2">等価性を判定する<see cref="Vertex"/>のインスタンス</param>
        /// <returns><paramref name="v1"/>と<paramref name="v2"/>の間との等価性が認められたらtrue，それ以外でfalse</returns>
        public static bool operator ==(Vertex v1, Vertex v2) => v1.Equals(v2);
        /// <summary>
        /// 二つの<see cref="Vertex"/>の間の非等価性を判定します。
        /// </summary>
        /// <param name="v1">等価性を判定する<see cref="Vertex"/>のインスタンス</param>
        /// <param name="v2">等価性を判定する<see cref="Vertex"/>のインスタンス</param>
        /// <returns><paramref name="v1"/>と<paramref name="v2"/>の間との非等価性が認められたらtrue，それ以外でfalse</returns>
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
        /// <see cref="Color"/>の新しいインスタンスを生成します。
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
        /// <see cref="Color"/>の新しいインスタンスを生成します。
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
        /// <see cref="Color"/>の新しいインスタンスを生成します。
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
        /// このインスタンスから要素を取り出します。
        /// </summary>
        /// <param name="r"><see cref="R"/></param>
        /// <param name="g"><see cref="G"/></param>
        /// <param name="b"><see cref="B"/></param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public readonly void Deconstruct(out byte r, out byte g, out byte b)
        {
            r = R;
            g = G;
            b = B;
        }

        /// <summary>
        /// このインスタンスから要素を取り出します。
        /// </summary>
        /// <param name="r"><see cref="R"/></param>
        /// <param name="g"><see cref="G"/></param>
        /// <param name="b"><see cref="B"/></param>
        /// <param name="a"><see cref="A"/></param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public readonly void Deconstruct(out byte r, out byte g, out byte b, out byte a)
        {
            r = R;
            g = G;
            b = B;
            a = A;
        }

        /// <summary>
        /// もう一つの<see cref="Color"/>との間の等価性を判定します。
        /// </summary>
        /// <param name="other">等価線を判定する<see cref="Color"/>のインスタンス</param>
        /// <returns><paramref name="other"/>との間との等価性が認められたらtrue，それ以外でfalse</returns>
        public readonly bool Equals(Color other) => R == other.R && G == other.G && B == other.B && A == other.A;

        /// <summary>
        /// オブジェクトとの等価性を判定します。
        /// </summary>
        /// <param name="obj">等価性を判定するオブジェクト</param>
        /// <returns><paramref name="obj"/>との間との等価性が認められたらtrue，それ以外でfalse</returns>
        public readonly override bool Equals(object obj) => obj is Color c && Equals(c);

        /// <summary>
        /// このインスタンスのハッシュコードを返します。
        /// </summary>
        /// <returns>このインスタンスのハッシュコード</returns>
        public readonly override int GetHashCode() => HashCode.Combine(R, G, B, A);

        /// <summary>
        /// このインスタンスを表す文字列を取得する
        /// </summary>
        /// <returns>このインスタンスを表す文字列</returns>
        public readonly override string ToString() => $"({R}, {G}, {B}, {A})";

        /// <summary>
        /// 二つの<see cref="Color"/>の間の等価性を判定します。
        /// </summary>
        /// <param name="c1">等価性を判定する<see cref="Color"/>のインスタンス</param>
        /// <param name="c2">等価性を判定する<see cref="Color"/>のインスタンス</param>
        /// <returns><paramref name="c1"/>と<paramref name="c2"/>の間との等価性が認められたらtrue，それ以外でfalse</returns>
        public static bool operator ==(Color c1, Color c2) => c1.Equals(c2);
        /// <summary>
        /// 二つの<see cref="Color"/>の間の非等価性を判定します。
        /// </summary>
        /// <param name="c1">非等価性を判定する<see cref="Color"/>のインスタンス</param>
        /// <param name="c2">非等価性を判定する<see cref="Color"/>のインスタンス</param>
        /// <returns><paramref name="c1"/>と<paramref name="c2"/>の間との非等価性が認められたらtrue，それ以外でfalse</returns>
        public static bool operator !=(Color c1, Color c2) => !c1.Equals(c2);
        /// <summary>
        /// 加算を行います。
        /// </summary>
        /// <param name="c1">加算する要素</param>
        /// <param name="c2">加算される要素</param>
        /// <remarks>オーバーフロー，アンダーフローは起きず0-255の間に修正される</remarks>
        /// <returns><paramref name="c1"/>と<paramref name="c2"/>を加算した結果</returns>
        public static Color operator +(Color c1, Color c2) => new Color(c1.R + c2.R, c1.G + c2.G, c1.B + c2.B, c1.A + c2.A);
        /// <summary>
        /// 減算を行います。
        /// </summary>
        /// <param name="c1">減算する要素</param>
        /// <param name="c2">減算される要素</param>
        /// <remarks>オーバーフロー，アンダーフローは起きず0-255の間に修正される</remarks>
        /// <returns><paramref name="c1"/>から<paramref name="c2"/>を減算した結果</returns>
        public static Color operator -(Color c1, Color c2) => new Color(c1.R - c2.R, c1.G - c2.G, c1.B - c2.B, c1.A - c2.A);
        /// <summary>
        /// 乗算を行います。
        /// </summary>
        /// <param name="color">定数倍される色</param>
        /// <param name="value">乗算する値</param>
        /// <remarks>オーバーフロー，アンダーフローは起きず0-255の間に修正される</remarks>
        /// <returns><paramref name="color"/>に<paramref name="value"/>を乗算した結果</returns>
        public static Color operator *(Color color, byte value) => new Color(color.R * value, color.G * value, color.B * value, color.A * value);
        /// <summary>
        /// 乗算を行います。
        /// </summary>
        /// <param name="value">乗算する値</param>
        /// <param name="color">定数倍される色</param>
        /// <remarks>オーバーフロー，アンダーフローは起きず0-255の間に修正される</remarks>
        /// <returns><paramref name="color"/>に<paramref name="value"/>を乗算した結果</returns>
        public static Color operator *(byte value, Color color) => new Color(color.R * value, color.G * value, color.B * value, color.A * value);
        /// <summary>
        /// 除算を行います。
        /// </summary>
        /// <param name="color">定数倍される色</param>
        /// <param name="value">除算する値</param>
        /// <remarks>オーバーフロー，アンダーフローは起きず0-255の間に修正される</remarks>
        /// <returns><paramref name="color"/>を<paramref name="value"/>で除算した結果</returns>
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
        /// <see cref="RenderPassParameter"/>新しいインスタンスを生成します。
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
        /// もう一つの<see cref="RenderPassParameter"/>との間の等価性を判定します。
        /// </summary>
        /// <param name="other">等価線を判定する<see cref="RenderPassParameter"/>のインスタンス</param>
        /// <returns><paramref name="other"/>との間との等価性が認められたらtrue，それ以外でfalse</returns>
        public readonly bool Equals(RenderPassParameter other) => ClearColor == other.ClearColor && IsColorCleared == other.IsColorCleared && IsDepthCleared == other.IsDepthCleared;
        /// <summary>
        /// オブジェクトとの等価性を判定します。
        /// </summary>
        /// <param name="obj">等価性を判定するオブジェクト</param>
        /// <returns><paramref name="obj"/>との間との等価性が認められたらtrue，それ以外でfalse</returns>
        public readonly override bool Equals(object obj) => obj is RenderPassParameter p && Equals(p);

        /// <summary>
        /// このインスタンスのハッシュコードを返します。
        /// </summary>
        /// <returns>このインスタンスのハッシュコード</returns>
        public readonly override int GetHashCode() => HashCode.Combine(ClearColor, IsColorCleared, IsDepthCleared);

        /// <summary>
        /// 二つの<see cref="RenderPassParameter"/>の間の等価性を判定します。
        /// </summary>
        /// <param name="left">等価性を判定する<see cref="RenderPassParameter"/>のインスタンス</param>
        /// <param name="right">等価性を判定する<see cref="RenderPassParameter"/>のインスタンス</param>
        /// <returns><paramref name="left"/>と<paramref name="right"/>の間との等価性が認められたらtrue，それ以外でfalse</returns>
        public static bool operator ==(RenderPassParameter left, RenderPassParameter right) => left.Equals(right);
        /// <summary>
        /// 二つの<see cref="RenderPassParameter"/>の間の非等価性を判定します。
        /// </summary>
        /// <param name="left">非等価性を判定する<see cref="RenderPassParameter"/>のインスタンス</param>
        /// <param name="right">非等価性を判定する<see cref="RenderPassParameter"/>のインスタンス</param>
        /// <returns><paramref name="left"/>と<paramref name="right"/>の間との非等価性が認められたらtrue，それ以外でfalse</returns>
        public static bool operator !=(RenderPassParameter left, RenderPassParameter right) => !(left == right);
    }

    /// <summary>
    /// アルファブレンドの方法を表す構造体
    /// </summary>
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
        /// もう一つの<see cref="AlphaBlend"/>との間の等価性を判定します。
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
        /// オブジェクトとの等価性を判定します。
        /// </summary>
        /// <param name="obj">等価性を判定するオブジェクト</param>
        /// <returns><paramref name="obj"/>との間との等価性が認められたらtrue，それ以外でfalse</returns>
        public readonly override bool Equals(object obj) => obj is AlphaBlend p && Equals(p);

        /// <summary>
        /// このインスタンスのハッシュコードを返します。
        /// </summary>
        /// <returns>このインスタンスのハッシュコード</returns>
        public readonly override int GetHashCode()
        {
            return HashCode.Combine(IsBlendEnabled, BlendDstFunc, BlendDstFunc, BlendSrcFuncAlpha, BlendDstFuncAlpha, BlendEquationRGB, BlendEquationAlpha);
        }

        /// <summary>
        /// 二つの<see cref="AlphaBlend"/>の間の等価性を判定します。
        /// </summary>
        /// <param name="left">等価性を判定する<see cref="AlphaBlend"/>のインスタンス</param>
        /// <param name="right">等価性を判定する<see cref="AlphaBlend"/>のインスタンス</param>
        /// <returns><paramref name="left"/>と<paramref name="right"/>の間との等価性が認められたらtrue，それ以外でfalse</returns>
        public static bool operator ==(AlphaBlend left, AlphaBlend right) => left.Equals(right);
        /// <summary>
        /// 二つの<see cref="AlphaBlend"/>の間の非等価性を判定します。
        /// </summary>
        /// <param name="left">非等価性を判定する<see cref="AlphaBlend"/>のインスタンス</param>
        /// <param name="right">非等価性を判定する<see cref="AlphaBlend"/>のインスタンス</param>
        /// <returns><paramref name="left"/>と<paramref name="right"/>の間との非等価性が認められたらtrue，それ以外でfalse</returns>
        public static bool operator !=(AlphaBlend left, AlphaBlend right) => !(left == right);

        /// <summary>
        /// 通常のアルファブレンドを表すインスタンスを取得します。
        /// </summary>
        public static AlphaBlend Normal =>
            new AlphaBlend
            {
                IsBlendEnabled = true,
                BlendSrcFunc = BlendFunction.SrcAlpha,
                BlendDstFunc = BlendFunction.OneMinusSrcAlpha,
                BlendSrcFuncAlpha = BlendFunction.One,
                BlendDstFuncAlpha = BlendFunction.One,
                BlendEquationRGB = BlendEquation.Add,
                BlendEquationAlpha = BlendEquation.Max
            };

        /// <summary>
        /// 加算のアルファブレンドを表すインスタンスを取得します。
        /// </summary>
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

        /// <summary>
        /// 不透明のアルファブレンドを表すインスタンスを取得します。
        /// </summary>
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

        /// <summary>
        /// 減算のアルファブレンドを表すインスタンスを取得します。
        /// </summary>
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

        /// <summary>
        /// 乗算のアルファブレンドを表すインスタンスを取得します。
        /// </summary>
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
}
