using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;
using System.Reflection;

namespace Altseed2.Test
{
    [TestFixture]
    class PartsTreeSystem
    {
        [Test, Apartment(ApartmentState.STA)]
        public void Instantiate()
        {
            var tc = new TestCore();
            tc.Init();

            for(var i = 0; i < 10; i++)
            {
                var nodes = PartsTreeInstantiator.Instantiate("testsave.nodes");
                var node = nodes[0] as CircleNode;
                node.Position += new Vector2F(i, i) * 20;
                node.Color = new Color(i * 10, i * 5, i * 2, i * 10);
                Engine.AddNode(node);
            }

            tc.LoopBody(null, null);

            tc.End();
        }
    }
}
