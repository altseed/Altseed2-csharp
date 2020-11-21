using System;
using System.Linq;
using NUnit.Framework;

namespace Altseed2.Test.NodeEditor
{
    class ToolElementTreeFactoryTest
    {
        [Test]
        public void メンバーがint型1つの型に対してツリーを生成できる()
        {
            var impl = new ToolElementTreeFactory();
            var elements = impl.CreateToolElements(new TestSubject1()).ToArray();

            Assert.AreEqual(1, elements.Length);
            Assert.AreEqual("TestInteger", elements[0].Name);
            Assert.AreEqual("Integer", elements[0].PropertyName);
            Assert.IsInstanceOf<IntToolElement>(elements[0]);
        }

        [Test]
        public void メンバーがboolとVector2Fの型に対してツリーを生成できる()
        {
            var impl = new ToolElementTreeFactory();
            var elements = impl.CreateToolElements(new TestSubject2()).ToArray();
            
            Assert.AreEqual(2, elements.Length);
            Assert.AreEqual("Boolean", elements[0].Name);
            Assert.IsInstanceOf<BoolToolElement>(elements[0]);

            Assert.AreEqual("Vector", elements[1].Name);
            Assert.IsInstanceOf<Vector2FToolElement>(elements[1]);
        }
        
        [Test]
        public void ToolAuto属性のついた型に対してツリーを生成できる()
        {
            var impl = new ToolElementTreeFactory();
            var elements = impl.CreateToolElements(new TestSubject3()).ToArray();
            
            Assert.AreEqual(2, elements.Length);
            Assert.AreEqual("Single", elements[0].Name);
            Assert.IsInstanceOf<FloatToolElement>(elements[0]);

            Assert.AreEqual("Color", elements[1].Name);
            Assert.IsInstanceOf<ColorToolElement>(elements[1]);
        }

        [Test]
        public void メソッドをGUIに表示するようなツリーを生成できる()
        {
            var impl = new ToolElementTreeFactory();
            var elements = impl.CreateToolElements(new TestSubject4()).ToArray();

            Assert.AreEqual(2, elements.Length);
            Assert.AreEqual("SubmitCommand", elements[0].Name);
            Assert.IsInstanceOf<ButtonToolElement>(elements[0]);

            Assert.AreEqual("UserCommand", elements[1].Name);
            Assert.IsInstanceOf<UserToolElement>(elements[1]);

            if (elements[0] is ButtonToolElement button)
            {
                Assert.AreEqual("Submit", button.MethodName);
            }

            if (elements[1] is UserToolElement user)
            {
                Assert.AreEqual("User", user.MethodName);
            }
        }

        sealed class TestSubject1
        {
            [ToolInt("TestInteger")]
            public int Integer { get; set; } = 10;
        }

        sealed class TestSubject2
        {
            [ToolBool]
            public bool Boolean { get; set; } = false;

            [ToolVector2F]
            public Vector2F Vector { get; set; }
        }

        [ToolAuto]
        sealed class TestSubject3
        {
            public float Single { get; set; }
            public Color Color { get; set; }
        }

        sealed class TestSubject4
        {
            [ToolButton("SubmitCommand")]
            public void Submit()
            {
            }

            [ToolUser("UserCommand")]
            public void User()
            {
            }
        }
    }
}
