using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Altseed2;
using System.Reflection;

namespace Altseed2
{
    internal static class PartsTreeInstantiator
    {
        public static PartsTreeSystem.NodeTreeGroup LoadNodeTree(string path)
        {
            var text = System.IO.File.ReadAllText(path);
            var group = PartsTreeSystem.NodeTreeGroup.Deserialize(text);
            return group;
        }

        public static Node Instantiate(string path)
        {
            var group = LoadNodeTree(path);
            return Instantiate(group);
        }

        public static Node Instantiate(PartsTreeSystem.NodeTreeGroup nodeTreeGroup)
        {
            var env = new PartsTreeSystem.Environment();
            return Instantiate(nodeTreeGroup, env);
        }

        public static Node Instantiate(PartsTreeSystem.NodeTreeGroup nodeTreeGroup, PartsTreeSystem.Environment environment)
        {
            var instance = PartsTreeSystem.Utility.CreateNodeFromNodeTreeGroup(nodeTreeGroup, environment);


            if (instance.Root is Node node)
            {
                return node;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
