using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed
{
    public partial class Tool
    {
        Int32Array int32Array = Int32Array.Create(0);
        FloatArray floatArray = FloatArray.Create(0);

        public bool BeginFullScreen(int offset)
        {
            var pos = new Vector2F(0, offset);
            var size = Engine.Window.Size - pos;
            SetNextWindowSize(size, ToolCond.None);
            SetNextWindowPos(pos, ToolCond.None);

            var flags = ToolWindow.NoMove | ToolWindow.NoBringToFrontOnFocus
                | ToolWindow.NoResize | ToolWindow.NoScrollbar
                | ToolWindow.NoScrollbar | ToolWindow.NoTitleBar;

            //const float oldWindowRounding = ImGui::GetStyle().WindowRounding; ImGui::GetStyle().WindowRounding = 0;
            var visible = Begin(" ", flags);
            // ImGui::GetStyle().WindowRounding = oldWindowRounding;
            return visible;
        }

        public bool ListBox(string label, ref int current, IEnumerable<string> items, int popup_max_height_in_items)
        {
            return ListBox(label, ref current, string.Join('\t', items), popup_max_height_in_items);
        }

        public bool Combo(string label, ref int current, IEnumerable<string> items, int popup_max_height_in_items)
        {
            return Combo(label, ref current, string.Join('\t', items), popup_max_height_in_items);
        }

        public bool InputInt2(string label, int[] array)
        {
            if (array.Length < 2)
                throw new ArgumentException("配列の長さが足りません");

            int32Array.FromArray(array);
            bool res = InputInt2(label, int32Array);

            if (res)
                for (int i = 0; i < array.Length; i++)
                    array[i] = int32Array.GetAt(i);

            return res;
        }

        public bool InputInt3(string label, int[] array)
        {
            if (array.Length < 3)
                throw new ArgumentException("配列の長さが足りません");

            int32Array.FromArray(array);
            bool res = InputInt3(label, int32Array);

            if (res)
                for (int i = 0; i < array.Length; i++)
                    array[i] = int32Array.GetAt(i);

            return res;
        }

        public bool InputInt4(string label, int[] array)
        {
            if (array.Length < 4)
                throw new ArgumentException("配列の長さが足りません");

            int32Array.FromArray(array);
            bool res = InputInt4(label, int32Array);

            if (res)
                for (int i = 0; i < array.Length; i++)
                    array[i] = int32Array.GetAt(i);

            return res;
        }

        public bool InputFloat2(string label, float[] array)
        {
            if (array.Length < 2)
                throw new ArgumentException("配列の長さが足りません");

            floatArray.FromArray(array);
            bool res = InputFloat2(label, floatArray);

            if (res)
                for (int i = 0; i < array.Length; i++)
                    array[i] = floatArray.GetAt(i);

            return res;
        }

        public bool InputFloat3(string label, float[] array)
        {
            if (array.Length < 3)
                throw new ArgumentException("配列の長さが足りません");

            floatArray.FromArray(array);
            bool res = InputFloat3(label, floatArray);

            if (res)
                for (int i = 0; i < array.Length; i++)
                    array[i] = floatArray.GetAt(i);

            return res;
        }

        public bool InputFloat4(string label, float[] array)
        {
            if (array.Length < 4)
                throw new ArgumentException("配列の長さが足りません");

            floatArray.FromArray(array);
            bool res = InputFloat4(label, floatArray);

            if (res)
                for (int i = 0; i < array.Length; i++)
                    array[i] = floatArray.GetAt(i);

            return res;
        }

        public bool SliderInt2(string label, int[] array, float speed, int v_min, int v_max)
        {
            if (array.Length < 2)
                throw new ArgumentException("配列の長さが足りません");

            int32Array.FromArray(array);
            bool res = SliderInt2(label, int32Array, speed, v_min, v_max);

            if (res)
                for (int i = 0; i < array.Length; i++)
                    array[i] = int32Array.GetAt(i);

            return res;
        }

        public bool SliderInt3(string label, int[] array, float speed, int v_min, int v_max)
        {
            if (array.Length < 3)
                throw new ArgumentException("配列の長さが足りません");

            int32Array.FromArray(array);
            bool res = SliderInt3(label, int32Array, speed, v_min, v_max);

            if (res)
                for (int i = 0; i < array.Length; i++)
                    array[i] = int32Array.GetAt(i);

            return res;
        }

        public bool SliderInt4(string label, int[] array, float speed, int v_min, int v_max)
        {
            if (array.Length < 4)
                throw new ArgumentException("配列の長さが足りません");

            int32Array.FromArray(array);
            bool res = SliderInt4(label, int32Array, speed, v_min, v_max);

            if (res)
                for (int i = 0; i < array.Length; i++)
                    array[i] = int32Array.GetAt(i);

            return res;
        }

        public bool SliderFloat2(string label, float[] array, float speed, float v_min, float v_max)
        {
            if (array.Length < 2)
                throw new ArgumentException("配列の長さが足りません");

            floatArray.FromArray(array);
            bool res = SliderFloat2(label, floatArray, speed, v_min, v_max);

            if (res)
                for (int i = 0; i < array.Length; i++)
                    array[i] = floatArray.GetAt(i);

            return res;
        }

        public bool SliderFloat3(string label, float[] array, float speed, float v_min, float v_max)
        {
            if (array.Length < 3)
                throw new ArgumentException("配列の長さが足りません");

            floatArray.FromArray(array);
            bool res = SliderFloat3(label, floatArray, speed, v_min, v_max);

            if (res)
                for (int i = 0; i < array.Length; i++)
                    array[i] = floatArray.GetAt(i);

            return res;
        }

        public bool SliderFloat4(string label, float[] array, float speed, float v_min, float v_max)
        {
            if (array.Length < 4)
                throw new ArgumentException("配列の長さが足りません");

            floatArray.FromArray(array);
            bool res = SliderFloat4(label, floatArray, speed, v_min, v_max);

            if (res)
                for (int i = 0; i < array.Length; i++)
                    array[i] = floatArray.GetAt(i);

            return res;
        }

        public void PlotLines(
            string label,
            float[] values,
            int values_count,
            int values_offset = 0,
            string overlay_text = null,
            float scale_min = float.MinValue,
            float scale_max = float.MaxValue,
            Vector2F graph_size = default,
            int stride = sizeof(float))
        {
            floatArray.FromArray(values);
            PlotLines(label, floatArray, values_count, values_offset, overlay_text, scale_min, scale_max, graph_size, stride);
        }

        public void PlotHistogram(
            string label,
            float[] values,
            int values_count,
            int values_offset = 0,
            string overlay_text = null,
            float scale_min = float.MinValue,
            float scale_max = float.MaxValue,
            Vector2F graph_size = default,
            int stride = sizeof(float))
        {
            floatArray.FromArray(values);
            PlotHistogram(label, floatArray, values_count, values_offset, overlay_text, scale_min, scale_max, graph_size, stride);
        }
    }
}
