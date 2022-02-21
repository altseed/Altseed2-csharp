using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartsTreeSystem;
using System.Reflection;

namespace Altseed2.NodeEditor
{
    class EngineNode : INode
    {
        public EngineNode()
        {
            if(_instance != null)
            {
                foreach(var node in _instance.GetChildren())
                {
                    Engine.RemoveNode(node as Node);
                }
            }
            _instance = this;
        }

        public static EngineNode GetInstance()
        {
            if (_instance == null) _instance = new EngineNode();
            return _instance;
        }

        private static EngineNode _instance;

        public void AddChild(INode node)
        {
            nodes.Add(node);
            if(View.NodeEditorHost.CommandManager != null)
                Engine.AddNode(node as Node);

            //Hack...
        }

        public void RemoveChild(int instanceID)
        {
            var removelist = new List<INode>();
            foreach (var c in GetChildren())
                if (c.InstanceID == instanceID)
                    removelist.Add(c);

            foreach (var c in removelist)
            {
                nodes.Remove(c);
                Engine.RemoveNode(c as Node);
            }
        }

        [SerializeField]
        List<INode> nodes = new List<INode>();

        public IReadOnlyCollection<INode> GetChildren()
        {
            return Engine.GetNodes() as IReadOnlyCollection<INode>;
            return nodes;
        }

        public void InsertChild(int id, INode node) { }

        public int InstanceID { get; set; }
    }
}