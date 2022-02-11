using PartsTreeSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altseed2
{
    public class PrefabNode : Node
    {

        public override void AddChild(INode node)
        {
            _children.Add(node);
            base.AddChild(node);
        }

        public override void RemoveChild(int instanceID)
        {
            foreach(var child in _children)
                if(child.InstanceID == instanceID)
                {
                    _children.Remove(child);
                    return;
                }

            base.RemoveChild(instanceID);
        }

        public override IReadOnlyCollection<INode> GetChildren()
        {
            return _children;
        }

        [SerializeField]
        private List<INode> _children = new();
    }
}
