using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartsTreeSystem;

namespace Altseed2.NodeEditor
{
    class EngineNode : Node
    {
        public EngineNode()
        {
            
            Engine.RemoveNode(_root);
            _root = this;
            Engine.AddNode(_root);
            
            _instances.Add(this);
        }

        public static void Reflesh()
        {
            foreach(var instance in _instances)
            {
                if (View.NodeEditorHost.NodeTree.Root != instance)
                    Engine.RemoveNode(instance);
                else
                    Engine.AddNode(instance);
            }
        }

        private static EngineNode _root = null;
        private static List<EngineNode> _instances = new();

        public override void AddChild(INode node)
        {
            this.AddChildNode(node as Node);
            _children.Add(node as Node);
        }

        public override void RemoveChild(int instanceID)
        {
            foreach (var c in _children)
            {
                if (c.InstanceID == instanceID)
                {
                    _children.Remove(c);
                    this.RemoveChildNode(c);
                    return;
                }
            }
        }

        [SerializeField]
        private List<Node> _children = new();

        public override IReadOnlyCollection<INode> GetChildren()
        {
            //return Engine.GetNodes() as IReadOnlyCollection<INode>;
            return _children;
        }
    }
}