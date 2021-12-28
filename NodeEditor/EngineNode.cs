using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartsTreeSystem;

namespace Altseed2.NodeEditor
{
    class EngineNode : INode
    {
        public EngineNode()
        {
            _instance = this;
        }

        public static EngineNode GetInstance()
        {
            if (_instance == null) _instance = new EngineNode();
            return _instance;
        }

        private static EngineNode _instance;

        public List<Node> children = new();

        public int InstanceID { get; set; }

        public void AddChild(INode node)
        {
            Engine.AddNode(node as Node);
            children.Add(node as Node);
        }

        public void RemoveChild(int instanceID)
        {

            children.ForEach(_ => {
                if (_.InstanceID == instanceID) 
                { 
                    Engine.RemoveNode(_);
                }
            });
            children.RemoveAll(_ => _.InstanceID == instanceID);
        }

        public IReadOnlyCollection<INode> GetChildren()
        {
            return children;
        }
    }
}
