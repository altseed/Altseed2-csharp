using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altseed2.NodeEditor.View
{
    public class NodeEditorCSInterface
    {

        public void Undo() => NodeEditorHost.NodeEditor.Undo();

        public void Redo() => NodeEditorHost.NodeEditor.Redo();

        public void Load() => NodeEditorHost.NodeEditor.Load();

        public void Load(string filepath) => NodeEditorHost.NodeEditor.Load(filepath);

        public void Save(string filepath) => NodeEditorHost.NodeEditor.Save(filepath);

        public int AddNode<NodeType>() where NodeType : Node => NodeEditorHost.NodeEditor.NodeTreeWindow.ViewModel.CreateNode<NodeType>();

    }
}
