using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altseed2
{
    public class PartsTree
    {
        public enum PartsTreeOriginalType
        {
            File,
            Instance,
        }

        public void Load(string filepath)
        {
            nodeTreeGroup = PartsTreeInstantiator.LoadNodeTree(filepath);
            type = PartsTreeOriginalType.File;
        }

        public void Load(Node original)
        {
            throw new NotImplementedException();
        }

        public void InstantiateAndAddToEngine()
        {
            Engine.AddNode(Instantiate());
        }

        public Node Instantiate()
        {
            switch (type)
            {
                case PartsTreeOriginalType.File:
                    return PartsTreeInstantiator.Instantiate(nodeTreeGroup, environment);

                case PartsTreeOriginalType.Instance:
                    throw new NotImplementedException();

                default:
                    return null;
            }
        }

        private PartsTreeOriginalType type;
        private string data;
        private PartsTreeSystem.NodeTreeGroup nodeTreeGroup;
        private PartsTreeSystem.Environment environment = new();
    }
}
