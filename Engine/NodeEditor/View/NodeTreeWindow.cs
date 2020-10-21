using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using Altseed2.NodeEditor.Presenter;

namespace Altseed2.NodeEditor.View
{
    internal class NodeTreeWindow : INodeTreeView
    {
        private static readonly NewNodeButton[] NodeButtonLayout = {
            new NewNodeButton(NodeType.Sprite, true),
            new NewNodeButton(NodeType.Text),
            new NewNodeButton(NodeType.Arc),
            new NewNodeButton(NodeType.Circle),
            new NewNodeButton(NodeType.Line, true),
            new NewNodeButton(NodeType.Rectangle),
            new NewNodeButton(NodeType.Triangle),
        };
        private static readonly ToolWindowFlags NodeTreeWindowConfig =
            ToolWindowFlags.NoMove | ToolWindowFlags.NoBringToFrontOnFocus
            | ToolWindowFlags.NoResize | ToolWindowFlags.NoScrollbar
            | ToolWindowFlags.NoScrollbar | ToolWindowFlags.NoCollapse;

        private readonly IEditorPropertyAccessor _accessor;
        private readonly Subject<NodeType> _onCommitNewNodeSubject = new Subject<NodeType>();

        public NodeTreeWindow(IEditorPropertyAccessor accessor)
        {
            _accessor = accessor;
        }

        public IObservable<NodeType> OnCommitNewNode => _onCommitNewNodeSubject;

        public void UpdateNodeTreeWindow()
        {
            // TODO: size, pos, begin, end の呼び出しのセットが頻出するかを確認して、クラスに抽出したい
            var size = new Vector2F(300, Engine.WindowSize.Y - _accessor.MenuHeight);
            var pos = new Vector2F(0, _accessor.MenuHeight);
            Engine.Tool.SetNextWindowSize(size, ToolCond.None);
            Engine.Tool.SetNextWindowPos(pos, ToolCond.None);

            if (Engine.Tool.Begin("Node", NodeTreeWindowConfig))
            {
                foreach (var button in NodeButtonLayout)
                {
                    button.Update(_onCommitNewNodeSubject);
                }

                UpdateNodeTree(Engine.GetNodes());
                Engine.Tool.End();
            }
        }

        private void UpdateNodeTree(IEnumerable<Node> nodes)
        {
            foreach (var node in nodes)
            {
                Engine.Tool.PushID(node.GetHashCode());

                // TODO: これは状態の問い合わせ処理なので、Node に対して Presenter のような層は欲しいかも。
                var flags = ToolTreeNodeFlags.OpenOnArrow;
                if (node == _accessor.Selected)
                    flags |= ToolTreeNodeFlags.Selected;
                if (node.Children.Count == 0)
                    flags |= ToolTreeNodeFlags.Leaf;

                bool treeNode = Engine.Tool.TreeNodeEx(node.ToString(), flags);
                if (Engine.Tool.IsItemClicked(0))
                {
                    // TODO: これはデータ更新なので、Presenterを挟みたいかも。
                    _accessor.Selected = node;
                }

                if (treeNode)
                {
                    UpdateNodeTree(node.Children);
                    Engine.Tool.TreePop();
                }
                Engine.Tool.PopID();
            }
        }

        private sealed class NewNodeButton
        {
            private readonly NodeType _type;
            private readonly bool _onNewLine;

            public NewNodeButton(NodeType type, bool onNewLine = false)
            {
                _type = type;
                _onNewLine = onNewLine;
            }

            public void Update(IObserver<NodeType> observer)
            {
                if (!_onNewLine)
                {
                    Engine.Tool.SameLine();
                }

                if (Engine.Tool.Button(_type.ToString()))
                {
                    observer.OnNext(_type);
                }
            }
        }
    }
}
