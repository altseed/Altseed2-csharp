using System;
using System.Threading;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace Altseed2.Test
{
    [TestFixture]
    public class Input
    {
        [Test, Apartment(ApartmentState.STA)]
        public void MousePosition()
        {
            var tc = new TestCore();
            tc.Init();

            var font = Font.LoadDynamicFont("TestData/Font/mplus-1m-regular.ttf", 100);
            Assert.NotNull(font);

            var node = new TextNode();
            node.Font = font;

            Engine.AddNode(node);

            tc.LoopBody(c =>
            {
                var mp = Engine.Mouse.Position;
                node.Text = $"{mp.X},{mp.Y}";
            }
            , null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void MouseButtonTest()
        {
            var tc = new TestCore();
            tc.Init();

            var font = Font.LoadDynamicFont("TestData/Font/mplus-1m-regular.ttf", 100);
            Assert.NotNull(font);

            var node = new TextNode();
            node.Font = font;

            Engine.AddNode(node);

            tc.LoopBody(c =>
            {
                var left = Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft);
                var right = Engine.Mouse.GetMouseButtonState(MouseButton.ButtonRight);
                node.Text = $"左:{left}\n右{right}";
            }
            , null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void MouseCursor()
        {
            var tc = new TestCore();
            tc.Init();

            var cursor = Cursor.Create("TestData/IO/AltseedPink.png", new Vector2I(16, 16));
            Assert.NotNull(cursor);
            if (cursor != null)
            {
                // マウスにカーソルをセットします。
                Engine.Mouse.CursorImage = cursor;
            }

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Keyboard()
        {
            var tc = new TestCore();
            tc.Init();

            var font = Font.LoadDynamicFont("TestData/Font/mplus-1m-regular.ttf", 100);
            Assert.NotNull(font);

            var node = new TextNode();
            node.Font = font;

            Engine.AddNode(node);

            tc.LoopBody(c =>
            {
                var sp = Engine.Keyboard.GetKeyState(Key.Space);
                node.Text = $"Spaceキー：{sp}";
            }
            , null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Joystick()
        {
            var tc = new TestCore();
            tc.Init();

            var font = Font.LoadDynamicFont("TestData/Font/mplus-1m-regular.ttf", 100);
            Assert.NotNull(font);

            var node = new TextNode();
            node.Font = font;

            Engine.AddNode(node);
            tc.LoopBody(c =>
            {
                var text = "";
                for (int i = 0; i < Engine.Joystick.MaxCount; i++)
                {
                    var info = Engine.Joystick.GetJoystickInfo(i);
                    if (info == null) continue;

                    if (info.IsGamepad)
                    {
                        var name = info.GamepadName;
                        var state = Engine.Joystick.GetButtonState(i, JoystickButton.DPadUp);
                        text += $"{name}: LeftUp = {state}\n";
                    }
                    else
                    {
                        var name = info.Name;
                        var state = Engine.Joystick.GetButtonState(i, 0);
                        text += $"{name}: Button 0 = {state}\n";
                    }
                }
                node.Text = text;
            }
            , null);
            tc.End();
        }
    }
}
