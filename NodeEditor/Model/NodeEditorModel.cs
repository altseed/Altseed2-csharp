using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartsTreeSystem;

namespace Altseed2.NodeEditor.Model
{
    public static class NodeEditorModel
    {
        private static CommandManager _commandManager;
        private static PartsTreeSystem.Environment _environment;
        private static NodeTreeGroup _nodeTreeGroup;
        private static NodeTree _nodeTree;

        public static NodeTree NodeTree => _nodeTree;

        public static bool Initialize(string title, int width, int height, Configuration config = null)
        {
            config ??= new Configuration();
            config.EnabledCoreModules |= CoreModules.Tool;
            
            var res = Engine.Initialize(title, width, height, config);
            Engine.Tool.AddFontFromFileTTF("../TestData/Font/mplus-1m-regular.ttf", 20, ToolGlyphRange.Japanese);
            Engine.Tool.ToolUsage = ToolUsage.Main;

            _environment = new PartsTreeSystem.Environment();
            _commandManager = new CommandManager();
            _nodeTreeGroup = new();
            _nodeTreeGroup.Init(typeof(Node), _environment);
            ReconstructNodeTree();

            return res;
        }

        public static bool Update()
        {
            foreach(var node in Engine.GetNodes())
            {
                if(node != _nodeTree.Root){
                    Engine.RemoveNode(node);
                }
            }

            return Engine.UpdateComponents(true, true);
        }

        public static void Terminate()
        {
            Engine.Terminate();
        }


        private static void ReconstructNodeTree()
        {
            var newtree = Utility.CreateNodeFromNodeTreeGroup(_nodeTreeGroup, _environment);
            _nodeTree = newtree;
            Engine.AddNode(_nodeTree.Root as Node);
        }

        public static void Undo()
        {
            _commandManager.Undo(_environment);
            ReconstructNodeTree();
        }

        public static void Redo()
        {
            _commandManager.Redo(_environment);
            ReconstructNodeTree();
        }

        public static void Save()
        {
            var path = Altseed2.Engine.Tool.SaveDialog("nodes", System.IO.Directory.GetCurrentDirectory());
            Save(path);
        }

        public static void Save(string filepath)
        {
            if (!string.IsNullOrEmpty(filepath))
            {
                var text = _nodeTreeGroup.Serialize(_environment);
                var ext = System.IO.Path.GetExtension(filepath).ToLower();

                if (ext != ".nodes")
                    filepath += ".nodes";

                System.IO.File.WriteAllText(filepath, text);
            }

            ReconstructNodeTree();
        }

        public static void Load()
        {
            var path = Altseed2.Engine.Tool.OpenDialog("nodes", System.IO.Directory.GetCurrentDirectory());
            Load(path);
        }

        public static void Load(string filepath)
        {
            if (!string.IsNullOrEmpty(filepath))
            {
                var text = System.IO.File.ReadAllText(filepath);
                _nodeTreeGroup = NodeTreeGroup.Deserialize(text);

            }
            
            ReconstructNodeTree();
        }

        public static int AddNode<NodeType>() where NodeType : Node
        {
            var id = _commandManager.AddNode(
                _nodeTreeGroup,
                _nodeTree,
                _nodeTree.Root.InstanceID,
                typeof(NodeType),
                _environment
            );
            ReconstructNodeTree();
            return id;
        }

        public static Node FindInstance(int instanceID)
        {
            return _nodeTree.FindInstance(instanceID) as Node;
        }

        public static void NotifyEditFields(IInstanceID node)
        {
            _commandManager.NotifyEditFields(node);
        }

        public static void StartEditFields(IInstanceID node)
        {
            _commandManager.StartEditFields(_nodeTreeGroup, _nodeTree, node, _environment);
        }

        public static void EndEditFields(IInstanceID node)
        {
            _commandManager.EndEditFields(node, _environment);
        }
    }
}
