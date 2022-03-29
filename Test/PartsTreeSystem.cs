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
                var node = PartsTreeInstantiator.Instantiate("TestData/PartsTreeSystem/Parts.nodes");
                Engine.AddNode(node);
            }

            tc.LoopBody(null, null);

            tc.End();
        }

        [Test, Apartment (ApartmentState.STA)]
        public void PartsTree()
        {
            var tc = new TestCore();
            tc.Init();

            var partstree = new PartsTree("TestData/PartsTreeSystem/Parts.nodes");

            tc.Duration = 200;
            Altseed2.Node added = new Altseed2.Node();
            tc.LoopBody(
                (_) =>
                {
                        added = partstree.InstantiateAndAddToEngine();
                },
                (_) =>
                {
                    foreach(var c in added.Children)
                    {
                        if (c is TransformNode tc)
                            tc.Position += new Vector2F(_ * 2f, _ * 2f);
                    }
                }
            );
            tc.End();
        }
    }
}
