using System;
using System.Collections.Generic;

namespace Altseed2
{
    public partial class Tool
    {
        readonly Int32Array int32Array = Int32Array.Create(4);
        readonly FloatArray floatArray = FloatArray.Create(4);

        /// <summary>
        /// フルスクリーンでツールウィンドウを開始します。
        /// </summary>
        /// <param name="offset"></param>
        /// <returns>処理に成功したらtrue，それ以外でfalse</returns>
        public bool BeginFullScreen(int offset)
        {
            var pos = new Vector2F(0, offset);
            var size = Engine.Window.Size - pos;
            SetNextWindowSize(size, ToolCond.None);
            SetNextWindowPos(pos, ToolCond.None, new Vector2F());

            var flags = ToolWindowFlags.NoMove | ToolWindowFlags.NoBringToFrontOnFocus
                | ToolWindowFlags.NoResize | ToolWindowFlags.NoScrollbar
                | ToolWindowFlags.NoScrollbar | ToolWindowFlags.NoTitleBar;

            //const float oldWindowRounding = ImGui::GetStyle().WindowRounding; ImGui::GetStyle().WindowRounding = 0;
            bool _tmp = false;
            var visible = Begin(" ", ref _tmp, flags);
            // ImGui::GetStyle().WindowRounding = oldWindowRounding;
            return visible;
        }

        /// <summary>
        /// ボタンを生成します。
        /// </summary>
        /// <param name="label">ボタンに表示される文字列</param>
        /// <returns>クリックされた時にtrue，それ以外でfalse</returns>
        public bool Button(string label)
        {
            return Button(label, new Vector2F());
        }

        /// <summary>
        /// リストボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示されるラベルの文字列</param>
        /// <param name="current">選択されている要素のインデックス -1で何も選択していない事を表す</param>
        /// <param name="items">表示する要素の文字列</param>
        /// <param name="popupMaxHeightInItems">表示される要素の数</param>
        /// <returns>いずれかの要素がクリックされたらtrue，それ以外でfalse</returns>
        public bool ListBox(string label, ref int current, IEnumerable<string> items, int popupMaxHeightInItems)
        {
            return ListBox(label, ref current, string.Join('\t', items), popupMaxHeightInItems);
        }

        /// <summary>
        /// コンボボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示されるラベルの文字列</param>
        /// <param name="current">選択されている要素のインデックス -1で何も選択していない事を表す</param>
        /// <param name="items">表示する要素の文字列</param>
        /// <param name="popupMaxHeightInItems">表示される要素の数</param>
        /// <returns>いずれかの要素がクリックされたらtrue，それ以外でfalse</returns>
        public bool Combo(string label, ref int current, IEnumerable<string> items, int popupMaxHeightInItems)
        {
            return Combo(label, ref current, string.Join('\t', items), popupMaxHeightInItems);
        }

        /// <summary>
        /// 2つの整数を入力するボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示されるラベルの文字列</param>
        /// <param name="span">それぞれのボックスの値を格納するSpan</param>
        /// <param name="flags"></param>
        /// <exception cref="ArgumentException"><paramref name="span"/>の大きさが2未満</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        public bool InputInt2(string label, Span<int> span, ToolInputTextFlags flags)
        {
            if (span.Length < 2)
                throw new ArgumentException("Spanの長さが2未満です。");

            int32Array.FromSpan(span);
            bool res = InputInt2(label, int32Array, flags);

            if (res)
                for (int i = 0; i < 2; i++)
                    span[i] = int32Array.GetAt(i);

            return res;
        }

        /// <summary>
        /// 3つの整数を入力するボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示されるラベルの文字列</param>
        /// <param name="span">それぞれのボックスの値を格納するSpan</param>
        /// <param name="flags"></param>
        /// <exception cref="ArgumentException"><paramref name="span"/>の大きさが3未満</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        public bool InputInt3(string label, Span<int> span, ToolInputTextFlags flags)
        {
            if (span.Length < 3)
                throw new ArgumentException("Spanの長さが3未満です。");

            int32Array.FromSpan(span);
            bool res = InputInt3(label, int32Array, flags);

            if (res)
                for (int i = 0; i < 3; i++)
                    span[i] = int32Array.GetAt(i);

            return res;
        }

        /// <summary>
        /// 4つの整数を入力するボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示されるラベルの文字列</param>
        /// <param name="span">それぞれのボックスの値を格納するSpan</param>
        /// <exception cref="ArgumentException"><paramref name="span"/>の大きさが4未満</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        public bool InputInt4(string label, Span<int> span, ToolInputTextFlags flags)
        {
            if (span.Length < 4)
                throw new ArgumentException("Spanの長さが4未満です。");

            int32Array.FromSpan(span);
            bool res = InputInt4(label, int32Array, flags);

            if (res)
                for (int i = 0; i < 4; i++)
                    span[i] = int32Array.GetAt(i);

            return res;
        }

        /// <summary>
        /// 2つの小数を入力するボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示されるラベルの文字列</param>
        /// <param name="span">それぞれのボックスの値を格納するSpan</param>
        /// <exception cref="ArgumentException"><paramref name="span"/>の大きさが2未満</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        public bool InputFloat2(string label, Span<float> span, string format, ToolInputTextFlags flags)
        {
            if (span.Length < 2)
                throw new ArgumentException("Spanの長さが2未満です。");

            floatArray.FromSpan(span);
            bool res = InputFloat2(label, floatArray, format, flags);

            if (res)
                for (int i = 0; i < 2; i++)
                    span[i] = floatArray.GetAt(i);

            return res;
        }

        /// <summary>
        /// 3つの小数を入力するボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示されるラベルの文字列</param>
        /// <param name="span">それぞれのボックスの値を格納するSpan</param>
        /// <exception cref="ArgumentException"><paramref name="span"/>の大きさが3未満</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        public bool InputFloat3(string label, Span<float> span, string format, ToolInputTextFlags flags)
        {
            if (span.Length < 3)
                throw new ArgumentException("Spanの長さが3未満です。");

            floatArray.FromSpan(span);
            bool res = InputFloat3(label, floatArray, format, flags);

            if (res)
                for (int i = 0; i < 3; i++)
                    span[i] = floatArray.GetAt(i);

            return res;
        }

        /// <summary>
        /// 4つの小数を入力するボックスを生成します。
        /// </summary>
        /// <param name="label">横に表示されるラベルの文字列</param>
        /// <param name="span">それぞれのボックスの値を格納するSpan</param>
        /// <exception cref="ArgumentException"><paramref name="span"/>の大きさが4未満</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        public bool InputFloat4(string label, Span<float> span, string format, ToolInputTextFlags flags)
        {
            if (span.Length < 4)
                throw new ArgumentException("Spanの長さが4未満です。");

            floatArray.FromSpan(span);
            bool res = InputFloat4(label, floatArray, format, flags);

            if (res)
                for (int i = 0; i < 4; i++)
                    span[i] = floatArray.GetAt(i);

            return res;
        }

        /// <summary>
        /// 2つのスライドで値を増減するバーを生成します。
        /// </summary>
        /// <param name="label">横に表示されるラベルの文字列</param>
        /// <param name="span">各バーの値を格納するSpan</param>
        /// <param name="vMin">最小値</param>
        /// <param name="vMax">最大値</param>
        /// <exception cref="ArgumentException"><paramref name="span"/>の大きさが2未満</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        public bool SliderInt2(string label, Span<int> span, int vMin, int vMax, string format, ToolSliderFlags flags)
        {
            if (span.Length < 2)
                throw new ArgumentException("配列の長さが足りません");

            int32Array.FromSpan(span);
            bool res = SliderInt2(label, int32Array, vMin, vMax, format, flags);

            if (res)
                for (int i = 0; i < 2; i++)
                    span[i] = int32Array.GetAt(i);

            return res;
        }

        /// <summary>
        /// 3つのスライドで値を増減するバーを生成します。
        /// </summary>
        /// <param name="label">横に表示されるラベルの文字列</param>
        /// <param name="span">各バーの値を格納するSpan</param>
        /// <param name="vMin">最小値</param>
        /// <param name="vMax">最大値</param>
        /// <exception cref="ArgumentException"><paramref name="span"/>の大きさが3未満</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        public bool SliderInt3(string label, Span<int> span, int vMin, int vMax, string format, ToolSliderFlags flags)
        {
            if (span.Length < 3)
                throw new ArgumentException("Spanの長さが3未満です。");

            int32Array.FromSpan(span);
            bool res = SliderInt3(label, int32Array, vMin, vMax, format, flags);

            if (res)
                for (int i = 0; i < 3; i++)
                    span[i] = int32Array.GetAt(i);

            return res;
        }

        /// <summary>
        /// 4つのスライドで値を増減するバーを生成します。
        /// </summary>
        /// <param name="label">横に表示されるラベルの文字列</param>
        /// <param name="span">各バーの値を格納するSpan</param>
        /// <param name="vMin">最小値</param>
        /// <param name="vMax">最大値</param>
        /// <exception cref="ArgumentException"><paramref name="span"/>の大きさが4未満</exception>
        /// <exception cref="ArgumentNullException"><paramref name="span"/>がnull</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        public bool SliderInt4(string label, Span<int> span, int vMin, int vMax, string format, ToolSliderFlags flags)
        {
            if (span.Length < 4)
                throw new ArgumentException("Spanの長さが4未満です。");

            int32Array.FromSpan(span);
            bool res = SliderInt4(label, int32Array, vMin, vMax, format, flags);

            if (res)
                for (int i = 0; i < 4; i++)
                    span[i] = int32Array.GetAt(i);

            return res;
        }

        /// <summary>
        /// 2つのスライドで値を増減するバーを生成します。
        /// </summary>
        /// <param name="label">横に表示されるラベルの文字列</param>
        /// <param name="span">各バーの値を格納するSpan</param>
        /// <param name="vMin">最小値</param>
        /// <param name="vMax">最大値</param>
        /// <exception cref="ArgumentException"><paramref name="span"/>の大きさが2未満</exception>
        /// <exception cref="ArgumentNullException"><paramref name="span"/>がnull</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        public bool SliderFloat2(string label, Span<float> span, float vMin, float vMax, string format, ToolSliderFlags flags)
        {
            if (span.Length < 2)
                throw new ArgumentException("Spanの長さが足りません");

            floatArray.FromSpan(span);
            bool res = SliderFloat2(label, floatArray, vMin, vMax, format, flags);

            if (res)
                for (int i = 0; i < 2; i++)
                    span[i] = floatArray.GetAt(i);

            return res;
        }

        /// <summary>
        /// 3つのスライドで値を増減するバーを生成します。
        /// </summary>
        /// <param name="label">横に表示されるラベルの文字列</param>
        /// <param name="span">各バーの値を格納するSpan</param>
        /// <param name="speed">値の増減する量</param>
        /// <param name="vMin">最小値</param>
        /// <param name="vMax">最大値</param>
        /// <exception cref="ArgumentException"><paramref name="span"/>の大きさが3未満</exception>
        /// <exception cref="ArgumentNullException"><paramref name="span"/>がnull</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        public bool SliderFloat3(string label, Span<float> span, float vMin, float vMax, string format, ToolSliderFlags flags)
        {
            if (span.Length < 3)
                throw new ArgumentException("Spanの長さが3未満です。");

            floatArray.FromSpan(span);
            bool res = SliderFloat3(label, floatArray, vMin, vMax, format, flags);

            if (res)
                for (int i = 0; i < 3; i++)
                    span[i] = floatArray.GetAt(i);

            return res;
        }

        /// <summary>
        /// 4つのスライドで値を増減するバーを生成します。
        /// </summary>
        /// <param name="label">横に表示されるラベルの文字列</param>
        /// <param name="span">各バーの値を格納するSpan</param>
        /// <param name="speed">値の増減する量</param>
        /// <param name="vMin">最小値</param>
        /// <param name="vMax">最大値</param>
        /// <exception cref="ArgumentException"><paramref name="span"/>の大きさが4未満</exception>
        /// <exception cref="ArgumentNullException"><paramref name="span"/>がnull</exception>
        /// <returns>入力が決定されたらtrue，それ以外でfalse</returns>
        public bool SliderFloat4(string label, Span<float> span, float vMin, float vMax, string format, ToolSliderFlags flags)
        {
            if (span.Length < 4)
                throw new ArgumentException("Spanの長さが4未満です。");

            floatArray.FromSpan(span);
            bool res = SliderFloat4(label, floatArray, vMin, vMax, format, flags);

            if (res)
                for (int i = 0; i < 4; i++)
                    span[i] = floatArray.GetAt(i);

            return res;
        }

        public void PlotLines(
            string label,
            Span<float> values,
            int valuesCount,
            int valuesOffset = 0,
            string overlayText = null,
            float scaleMin = float.MinValue,
            float scaleMax = float.MaxValue,
            Vector2F graphSize = default,
            int stride = sizeof(float))
        {
            floatArray.FromSpan(values);
            PlotLines(label, floatArray, valuesCount, valuesOffset, overlayText, scaleMin, scaleMax, graphSize, stride);
        }

        public void PlotHistogram(
            string label,
            Span<float> values,
            int values_count,
            int valuesOffset = 0,
            string overlayText = null,
            float scaleMin = float.MinValue,
            float scaleMax = float.MaxValue,
            Vector2F graphSize = default,
            int stride = sizeof(float))
        {
            floatArray.FromSpan(values);
            PlotHistogram(label, floatArray, values_count, valuesOffset, overlayText, scaleMin, scaleMax, graphSize, stride);
        }

        public bool ColorEdit3(string label, ref Color col, ToolColorEditFlags flags)
        {
            float[] span = new float[3] { col.R / 255f, col.G / 255f, col.B / 255f };
            floatArray.FromSpan(span);
            var res = ColorEdit3(label, floatArray, flags);
            col.R = (byte)(floatArray[0] * 255);
            col.G = (byte)(floatArray[1] * 255);
            col.B = (byte)(floatArray[2] * 255);
            return res;
        }

        public bool ColorEdit4(string label, ref Color col, ToolColorEditFlags flags)
        {
            float[] span = new float[4] { col.R / 255f, col.G / 255f, col.B / 255f, col.A / 255f };
            floatArray.FromSpan(span);
            var res = ColorEdit4(label, floatArray, flags);
            col.R = (byte)(floatArray[0] * 255);
            col.G = (byte)(floatArray[1] * 255);
            col.B = (byte)(floatArray[2] * 255);
            col.A = (byte)(floatArray[3] * 255);
            return res;
        }

        public bool DragInt2(string label, Span<int> span, float v_speed, int v_min, int v_max, string format, ToolSliderFlags flags)
        {
            if (span.Length < 2)
                throw new ArgumentException("Spanの長さが2未満です。");

            int32Array.FromSpan(span);
            bool res = DragInt2(label, int32Array, v_speed, v_min, v_max, format, flags);

            if (res)
                for (int i = 0; i < 2; i++)
                    span[i] = int32Array.GetAt(i);

            return res;
        }

        public bool DragInt3(string label, Span<int> span, float v_speed, int v_min, int v_max, string format, ToolSliderFlags flags)
        {
            if (span.Length < 3)
                throw new ArgumentException("Spanの長さが3未満です。");

            int32Array.FromSpan(span);
            bool res = DragInt3(label, int32Array, v_speed, v_min, v_max, format, flags);

            if (res)
                for (int i = 0; i < 3; i++)
                    span[i] = int32Array.GetAt(i);

            return res;
        }

        public bool DragInt4(string label, Span<int> span, float v_speed, int v_min, int v_max, string format, ToolSliderFlags flags)
        {
            if (span.Length < 4)
                throw new ArgumentException("Spanの長さが4未満です。");

            int32Array.FromSpan(span);
            bool res = DragInt4(label, int32Array, v_speed, v_min, v_max, format, flags);

            if (res)
                for (int i = 0; i < 4; i++)
                    span[i] = int32Array.GetAt(i);

            return res;
        }

        public bool DragFloat2(string label, Span<float> span, float v_speed, float v_min, float v_max, string format, ToolSliderFlags flags)
        {
            if (span.Length < 2)
                throw new ArgumentException("Spanの長さが2未満です。");

            floatArray.FromSpan(span);
            bool res = DragFloat2(label, floatArray, v_speed, v_min, v_max, format, flags);

            if (res)
                for (int i = 0; i < 2; i++)
                    span[i] = floatArray.GetAt(i);

            return res;
        }

        public bool DragFloat3(string label, Span<float> span, float v_speed, float v_min, float v_max, string format, ToolSliderFlags flags)
        {
            if (span.Length < 3)
                throw new ArgumentException("Spanの長さが3未満です。");

            floatArray.FromSpan(span);
            bool res = DragFloat3(label, floatArray, v_speed, v_min, v_max, format, flags);

            if (res)
                for (int i = 0; i < 3; i++)
                    span[i] = floatArray.GetAt(i);

            return res;
        }

        public bool DragFloat4(string label, Span<float> span, float v_speed, float v_min, float v_max, string format, ToolSliderFlags flags)
        {
            if (span.Length < 4)
                throw new ArgumentException("Spanの長さが4未満です。");

            floatArray.FromSpan(span);
            bool res = DragFloat4(label, floatArray, v_speed, v_min, v_max, format, flags);

            if (res)
                for (int i = 0; i < 4; i++)
                    span[i] = floatArray.GetAt(i);

            return res;
        }
    }
}
