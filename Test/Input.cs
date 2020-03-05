using System;
using System.Threading;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace Altseed.Test
{
    [TestFixture]
    public class Input
    {
        [Test, Apartment(ApartmentState.STA)]
        public void MousePosition()
        {
            var tc = new TestCore();
            tc.Init();

            var font = Font.LoadDynamicFont("../../Core/TestData/Font/mplus-1m-regular.ttf", 100);
            Assert.NotNull(font);

            var node = new TextNode();
            node.Font = font;

            Engine.AddNode(node);

            tc.LoopBody(c =>
            {
                var mp = Engine.Mouse.Position;
                node.Text = $"{mp.X:D3},{mp.Y:D3}";
            }
            , null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void MouseButton()
        {
            var tc = new TestCore();
            tc.Init();

            var font = Font.LoadDynamicFont("../../Core/TestData/Font/mplus-1m-regular.ttf", 100);
            Assert.NotNull(font);

            var node = new TextNode();
            node.Font = font;

            Engine.AddNode(node);

            tc.LoopBody(c =>
            {
                var left = Engine.Mouse.GetMouseButtonState(MouseButtons.ButtonLeft);
                var right = Engine.Mouse.GetMouseButtonState(MouseButtons.ButtonRight);
                node.Text = $"左:{left}\n右{right}";
            }
            , null);

            tc.End();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void Keyboard()
        {
            var tc = new TestCore();
            tc.Init();

            var font = Font.LoadDynamicFont("../../Core/TestData/Font/mplus-1m-regular.ttf", 100);
            Assert.NotNull(font);

            var node = new TextNode();
            node.Font = font;

            Engine.AddNode(node);

            tc.LoopBody(c =>
            {
                var sp = Engine.Keyboard.GetKeyState(Keys.Space);
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

            var font = Font.LoadDynamicFont("../../Core/TestData/Font/mplus-1m-regular.ttf", 100);
            Assert.NotNull(font);

            var node = new TextNode();
            node.Font = font;

            Engine.AddNode(node);

            Engine.Joystick.RefreshConnectedState();
            Engine.Joystick.RefreshInputState();

            for (int i = 0; i < Engine.Joystick.MaxCount; i++)
            {
                if (!Engine.Joystick.IsPresent(i)) continue;

                var name = Engine.Joystick.GetJoystickName(i);
                tc.LoopBody(c =>
                {
                    var leftup = Engine.Joystick.GetButtonStateByType(i, JoystickButtonType.LeftUp);
                    node.Text = $"{name}：LeftUp = {leftup}";
                }
                , null);
            }
            tc.End();
        }
    }
}
