using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altseed.TinySystem
{
    /// <summary>
    /// オブジェクトを統括するシーンのクラス
    /// </summary>
    [Serializable]
    public class Scene
    {
        internal SceneStatus Status { get; set; }

        private RootNode RootNode;

        public ReadOnlyCollection<Node> Nodes { get; }

        public Scene()
        {
            RootNode = new RootNode(this);
            Nodes = RootNode.Nodes;
        }

        #region 仮想メソッド

        /// <summary>
        /// シーンが登録されたときに実行
        /// </summary>
        protected virtual void OnRegistered() { }

        /// <summary>
        /// 更新対象になったときに1度だけ実行
        /// </summary>
        protected virtual void OnStartUpdating() { }

        /// <summary>
        /// シーン推移完了時に実行
        /// </summary>
        protected virtual void OnTransitionFinished() { }

        /// <summary>
        /// オブジェクトの更新が行われる前に実行
        /// </summary>
        protected virtual void OnUpdating() { }

        /// <summary>
        /// オブジェクトの更新が行われた後に実行
        /// </summary>
        protected virtual void OnUpdated() { }

        /// <summary>
        /// シーン推移開始時に実行
        /// </summary>
        protected virtual void OnTransitionBegin() { }
        /// <summary>
        /// 更新対象から外れた時に1度だけ実行
        /// </summary>
        protected virtual void OnStopUpdating() { }

        /// <summary>
        /// シーンの登録が解除されるときに実行
        /// </summary>
        protected virtual void OnUnRegistered() { }

        #endregion;

        #region イベント発火

        internal void RaiseOnRegistered()
        {
            Status = SceneStatus.FadingIn;
            OnRegistered();
        }

        internal void RaiseOnStartUpdating()
        {
            Status = SceneStatus.StartUpdating;
            OnStartUpdating();
        }

        internal void RaiseOnStopUpdating()
        {
            Status = SceneStatus.StopUpdating;
            OnStopUpdating();
        }

        internal void RaiseOnTransitionBegin()
        {
            Status = SceneStatus.FadingOut;
            OnTransitionBegin();
        }

        internal void RaiseOnTransitionFinished()
        {
            Status = SceneStatus.Updated;
            OnTransitionFinished();
        }

        internal void RaiseOnUnRegistered()
        {
            Status = SceneStatus.Free;
            OnUnRegistered();
        }

        #endregion

        public void AddNode(Node node)
        {
            RootNode.AddChildNode(node);
        }

        public void RemoveNode(Node node)
        {
            RootNode.RemoveChildNode(node);
        }

        internal void Update()
        {

            RootNode.Update();
        }


        internal static void InheritObjects(Scene oldScene, Scene nextScene)
        {
            //if (oldScene == null || nextScene == null)
            //{
            //    Engine.Log.Error(LogCategory.Engine, $"シーンが null です。");
            //    return;
            //}

            //var objects = oldScene.Objects.Where(x => x.IsInherited);
            //oldScene._Objects.Clear();
            //nextScene._Objects.AddImmediately(objects);
        }
    }
}
