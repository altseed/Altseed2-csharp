using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altseed
{
    /// <summary>
    /// オブジェクトを統括するシーンのクラス
    /// </summary>
    [Serializable]
    public class Scene
    {
        [Serializable]
        private sealed class AljectDrawingPriorityComparer : IComparer<Alject>
        {
            /// <summary>
            /// 指定した2つの<see cref="Alject"/>の<see cref="Alject.DrawingPriority"/>を比較する
            /// </summary>
            /// <param name="x">更新優先度を比較する<see cref="Alject"/></param>
            /// <param name="y">更新優先度を比較する<see cref="Alject"/></param>
            /// <returns><paramref name="x"/>と<paramref name="y"/>を比較した結果</returns>
            public int Compare(Alject x, Alject y)
            {
                if (x == null) throw new ArgumentNullException("比較するオブジェクトがnullです", nameof(x));
                if (y == null) throw new ArgumentNullException("比較するオブジェクトがnullです", nameof(y));
                return x.DrawingPriority.CompareTo(y.DrawingPriority);
            }
        }

        private readonly static AljectDrawingPriorityComparer priorityComparer;

        internal bool NeededSort { get; set; } = false;

        internal SceneStatus Status { get; set; }

        static Scene()
        {
            priorityComparer = new AljectDrawingPriorityComparer();
        }

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// 
        public Scene()
        {
            _Objects = new RegisterableCollection<Alject, Scene>(this);
            Objects = _Objects.AsReadOnly();

            _Components = new RegisterableCollection<SceneComponent, Scene>(this);
            Components = _Components.AsReadOnly();
        }

        #region ComponentRegister
        /// <summary>
        /// 登録されているコンポーネントを取得する
        /// </summary>
        public ReadOnlyCollection<SceneComponent> Components { get; }
        private readonly RegisterableCollection<SceneComponent, Scene> _Components;

        /// <summary>
        /// 指定した<see cref="SceneComponent"/>を登録する
        /// </summary>
        /// <param name="component">登録するコンポーネント</param>
        /// <remarks>追加されるのはそのフレームの更新処理が終了した後</remarks>
        public void AddComponent(SceneComponent component)
        {
            _Components.Add(component);
        }

        /// <summary>
        /// 指定した<see cref="SceneComponent"/>を登録する
        /// </summary>
        /// <param name="component">登録するコンポーネント</param>
        /// <remarks>削除されるのはそのフレームの更新処理が終了した後</remarks>
        public void RemoveComponent(SceneComponent component)
        {
            _Components.Remove(component);
        }

        #endregion

        #region AljectRegister

        private readonly RegisterableCollection<Alject, Scene> _Objects;
        /// <summary>
        /// 登録されているオブジェクトを取得する
        /// </summary>
        public ReadOnlyCollection<Alject> Objects { get; }

        /// <summary>
        /// 指定したオブジェクトを登録する
        /// </summary>
        /// <param name="obj">登録されるオブジェクト</param>
        /// <remarks>追加されるのはそのフレームの更新処理が終了した後</remarks>
        public void AddObject(Alject obj)
        {
            _Objects.Add(obj);
        }

        /// <summary>
        /// 指定したオブジェクトを削除する
        /// </summary>
        /// <param name="obj">削除されるオブジェクト</param>
        /// <remarks>削除されるのはそのフレームの更新処理が終了した後</remarks>
        public void RemoveObject(Alject obj)
        {
            _Objects.Remove(obj);
        }
        #endregion

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

        internal void Update()
        {
            foreach (var c in Components)
                if (c.Status == RegisterStatus.Registered)
                    c.RaiseOnUpdating();
            OnUpdating();

            foreach (var o in Objects)
                if (o.Status == RegisterStatus.Registered)
                    o.Update();
            OnUpdated();

            foreach (var c in Components)
                if (c.Status == RegisterStatus.Registered)
                    c.RaiseOnUpdated();

            Draw();

            _Objects.Update();
            _Components.Update();

            if (NeededSort)
            {
                _Objects.Sort(priorityComparer);
                NeededSort = false;
            }
        }

        internal void Draw()
        {
            foreach (var o in Objects) o.Draw();
        }

        internal static void InheritObjects(Scene oldScene, Scene nextScene)
        {
            if (oldScene == null || nextScene == null)
            {
                Engine.Log.Error(LogCategory.Engine, $"シーンが null です。");
                return;
            }

            var objects = oldScene.Objects.Where(x => x.IsInherited);
            oldScene._Objects.Clear();
            nextScene._Objects.AddImmediately(objects);
        }
    }
}
