using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altseed2
{
    /// <summary>
    /// エディタで編集したノードファイルのインスタンスを生成するシステムです。
    /// </summary>
    public class PartsTree<T> where T : Node
    {
        enum PartsTreeOriginalType
        {
            File,
            Instance,
        }

        /// <summary>
        /// ノードファイルから<see cref="PartsTree"/>を作成します。
        /// </summary>
        /// <param name="filepath"></param>
        public PartsTree(string filepath)
        {
            nodeTreeGroup = PartsTreeInstantiator.LoadNodeTree(filepath);
            type = PartsTreeOriginalType.File;

            //Root node type check
            var node = Instantiate();
            if (node.GetType() != typeof(T))
                throw new Exception("This PartsTree's root node type is " + node.GetType().Name + ", not " + typeof(T).Name + ".");
        }

        /// <summary>
        /// ノードのインスタンスから<see cref="PartsTree{T}"/>を作成します。
        /// </summary>
        /// <param name="original"></param>
        /// <exception cref="NotImplementedException"></exception>
        public PartsTree(Node original)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 新しいインスタンスを生成し、エンジンに追加します。
        /// </summary>
        public T InstantiateAndAddToEngine()
        {
            var node = Instantiate();
            Engine.AddNode(node);
            return node;
        }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public T Instantiate()
        {
            switch (type)
            {
                case PartsTreeOriginalType.File:
                    var node =  PartsTreeInstantiator.Instantiate(nodeTreeGroup, environment);
                    return node as T;

                case PartsTreeOriginalType.Instance:
                    throw new NotImplementedException();

                default:
                    return null;
            }
        }

        private PartsTreeOriginalType type;
        private PartsTreeSystem.NodeTreeGroup nodeTreeGroup;
        private PartsTreeSystem.Environment environment = new();
    }
}
