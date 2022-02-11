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
            Engine.AddNode(node as Node);
        }

        public void RemoveChild(int instanceID)
        {
            var removelist = new List<INode>();
            foreach (var c in GetChildren())
                if (c.InstanceID == instanceID)
                    removelist.Add(c);

            foreach (var c in removelist)
                Engine.RemoveNode(c as Node);
        }

        public IReadOnlyCollection<INode> GetChildren()
        {
            return Engine.GetNodes() as IReadOnlyCollection<INode>;
        }

        public void InsertChild(int id, INode node) { }

        public int InstanceID { get; set; }
    }
}