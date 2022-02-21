using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altseed2
{
    public class PartsTree
    {
        public void Load(string filepath)
        {
            nodeTreeGroup = PartsTreeInstantiator.LoadNodeTree(filepath);
        }

        public void InstantiateAndAddToEngine()
        {
            var nodes = Instantiate();
            foreach(var node in nodes)
                Engine.AddNode(node);
        }

        public List<Node> Instantiate()
        {
            return PartsTreeInstantiator.Instantiate(nodeTreeGroup, environment);
        }

        private PartsTreeSystem.NodeTreeGroup nodeTreeGroup;
        private PartsTreeSystem.Environment environment = new();
    }
}
