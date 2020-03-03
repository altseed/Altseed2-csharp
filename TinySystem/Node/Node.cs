using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Altseed.TinySystem
{
    /// <summary>
    /// ゲームシーンを構成するノードを表します。
    /// </summary>
    [Serializable]
    public class Node : Registerable<Node>
    {
        public Node()
        {
            _Children = new RegisterableCollection<Node, Node>(this);
            Children = _Children.AsReadOnly();
        }

        internal virtual void Update()
        {
            OnUpdate();

            _Children.Update();
            foreach (var c in Children)
            {
                c.Update();
            }
        }

        #region プロパティ

        /// <summary>
        /// 描画優先度を取得または設定します。
        /// </summary>
        /// <remarks>実際の更新の順序の変更は次フレーム以降</remarks>
        public int DrawingPriority
        {
            get => _DrawingPriority;
            set
            {
                _DrawingPriority = value;
                //if (Scene != null) Scene.NeededSort = true;
            }
        }
        private int _DrawingPriority = 0;

        /// <summary>
        /// 描画を実行するかどうかを取得または設定します。
        /// </summary>
        public bool IsDrawn { get; set; } = true;

        /// <summary>
        /// シーンが変更されても次のシーンへ引き継がれるかどうかを取得または設定します。
        /// </summary>
        public bool IsInherited { get; set; } = true;

        /// <summary>
        /// 更新をするかどうかを取得または設定します。
        /// </summary>
        public bool IsUpdated { get; set; } = true;

        #endregion

        #region Registerable (子として)

        public Node Parent { get; private set; }

        internal override void Added(Node owner)
        {
            Parent = owner;
            SetScenePropRecursively(Parent.Scene);
            OnAdded();
        }

        internal override void Removed()
        {
            Parent = null;
            SetScenePropRecursively(null);
            OnRemoved();
        }

        #endregion

        #region Scene

        public Scene Scene { get; internal set; }
        internal void SetScenePropRecursively(Scene scene)
        {
            Scene = scene;
            foreach (var c in Children)
            {
                c.SetScenePropRecursively(scene);
            }
        }

        #endregion

        #region Registerable (親として)

        private RegisterableCollection<Node, Node> _Children;
        public ReadOnlyCollection<Node> Children { get; }

        public void AddChildNode(Node node)
        {
            _Children.Add(node);
        }

        public void RemoveChildNode(Node node)
        {
            _Children.Remove(node);
        }

        #endregion

        #region 仮想メソッド

        protected virtual void OnAdded() { }

        protected virtual void OnRemoved() { }

        protected virtual void OnUpdate() { }


        #endregion
    }

    [Serializable]
    public abstract class DrawnNode : Node
    {
        internal abstract void Draw();
        // NOTE: 実際はここでRendererを叩くよりも、
        //       描画対象をどこかに積み、後で
        //       まとめて描画するほうが良いかも

        internal override void Update()
        {
            Draw();

            base.Update();
        }
    }

    [Serializable]
    internal sealed class RootNode : Node
    {
        internal ReadOnlyCollection<Node> Nodes { get; }

        internal RootNode(Scene scene)
        {
            Nodes = Children;
            Scene = scene;
        }

        internal void Inherit(Scene scene)
        {
            SetScenePropRecursively(scene);
        }
    }
}
