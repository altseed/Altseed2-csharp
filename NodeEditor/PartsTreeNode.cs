using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartsTreeSystem;
using System.Reflection;

namespace Altseed2.NodeEditor
{
    class PartsTreeNode : INode
    {
        public PartsTreeNode()
        {
            if (inEditor())
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
        }

        public static PartsTreeNode GetInstance()
        {
            if (_instance == null) _instance = new PartsTreeNode();
            return _instance;
        }

        private static PartsTreeNode _instance;

        public void AddChild(INode node)
        {
            nodes.Add(node);
            if(inEditor())
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

        List<INode> nodes = new List<INode>();

        public IReadOnlyCollection<INode> GetChildren()
        {
            if (inEditor())
                return Engine.GetNodes() as IReadOnlyCollection<INode>;
            else
                return nodes;
        }

        private bool inEditor()
        {
            return View.NodeEditorHost.CommandManager != null;
        }

        public void InsertChild(int id, INode node) { }

        public int InstanceID { get; set; }
    }
}