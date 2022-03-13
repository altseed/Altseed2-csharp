using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartsTreeSystem;

namespace Altseed2.NodeEditor.Model
{
    class Environment : PartsTreeSystem.Environment
    {
        Dictionary<PartsTreeSystem.Asset, string> pathes = new Dictionary<PartsTreeSystem.Asset, string>();
        public Dictionary<PartsTreeSystem.Asset, int> instantIDs = new Dictionary<PartsTreeSystem.Asset, int>();

        public override PartsTreeSystem.Asset GetAsset(string path)
        {
            if (pathes.ContainsValue(path))
            {
                return pathes.Where(_ => _.Value == path).FirstOrDefault().Key;
            }
            var text = System.IO.File.ReadAllText(path);
            var nodeTreeGroup = PartsTreeSystem.NodeTreeGroup.Deserialize(text);

            pathes.Add(nodeTreeGroup, path);
            return nodeTreeGroup;
        }

        public override string GetAssetPath(PartsTreeSystem.Asset asset)
        {
            if (pathes.TryGetValue(asset, out var path))
            {
                return System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), path);
            }
            return System.IO.Directory.GetCurrentDirectory();
        }
    }

    public static class NodeEditorModel
    {
        private static CommandManager _commandManager;
        private static Environment _environment;
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

            LoadPartsFile("./");

            _environment = new Environment();
            _commandManager = new CommandManager();
            _nodeTreeGroup = new();
            _nodeTreeGroup.Init(typeof(Node), _environment);
            ReconstructNodeTree();

            return res;
        }

        public static bool Update()
        {
            foreach (var node in Engine.GetNodes())
            {
                if (node != _nodeTree.Root)
                {
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
            var id = AddNode<NodeType>(_nodeTree.Root as Node);
            return id;
        }

        public static int AddNode<NodeType>(Node parent) where NodeType : Node
        {
            var id = _commandManager.AddNode(
                _nodeTreeGroup,
                _nodeTree,
                parent.InstanceID,
                typeof(NodeType),
                _environment
            );
            ReconstructNodeTree();
            return id;
        }

        public static void RemoveNode(Node node)
        {
            //_commandManager.RemoveNode(_nodeTreeGroup, _nodeTree, node.InstanceID, _environment);

            void removeLeaf(Node node)
            {
                if (node == null)
                    return;

                foreach (var child in node.GetChildren())
                    removeLeaf(child as Node);

                _commandManager.RemoveNode(_nodeTreeGroup, _nodeTree, node.InstanceID, _environment);
            }

            removeLeaf(node);
            ReconstructNodeTree();
        }

        public static bool isRemovable(Node node)
        {
            return _nodeTree.Root != node;
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


        static List<string> partsfilepathes = new();
        public static void LoadPartsFile(string path)
        {
            foreach (var p in System.IO.Directory.GetFiles(path, "*.nodes"))
                partsfilepathes.Add(p);
        }

        public static List<string> GetPartsPathes()
        {
            return partsfilepathes;
        }

        public static void AddNodeTreeGroup(string path, int parentID)
        {
            var addingNodeTreeGroup = _environment.GetAsset(path) as PartsTreeSystem.NodeTreeGroup;
            var id = _commandManager.AddNode(_nodeTreeGroup, _nodeTree, parentID, addingNodeTreeGroup, _environment);
            _environment.instantIDs.Add(addingNodeTreeGroup, id);
            ReconstructNodeTree();
        }

        public static bool IsAsset(Node node, out string path)
        {
            foreach (var o in _environment.instantIDs)
            {
                if (node.InstanceID == o.Value)
                {
                    path = _environment.GetAssetPath(o.Key);
                    return true;
                }
            }

            path = String.Empty;
            return false;
        }
    }
}
