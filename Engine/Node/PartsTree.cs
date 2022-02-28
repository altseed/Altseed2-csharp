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
    public class PartsTree
    {
        enum PartsTreeOriginalType
        {
            File,
            Instance,
        }

        /// <summary>
        /// ノードファイルを読み込みます。
        /// </summary>
        /// <param name="filepath"></param>
        public void Load(string filepath)
        {
            nodeTreeGroup = PartsTreeInstantiator.LoadNodeTree(filepath);
            type = PartsTreeOriginalType.File;
        }

        /// <summary>
        /// ノードのインスタンスから<see cref="PartsTree"/>を作成します。
        /// </summary>
        /// <param name="original"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Load(Node original)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 新しいインスタンスを生成し、エンジンに追加します。
        /// </summary>
        public void InstantiateAndAddToEngine()
        {
            Engine.AddNode(Instantiate());
        }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Node Instantiate()
        {
            switch (type)
            {
                case PartsTreeOriginalType.File:
                    return PartsTreeInstantiator.Instantiate(nodeTreeGroup, environment);

                case PartsTreeOriginalType.Instance:
                    throw new NotImplementedException();

                default:
                    return null;
            }
        }

        private PartsTreeOriginalType type;
        private string data;
        private PartsTreeSystem.NodeTreeGroup nodeTreeGroup;
        private PartsTreeSystem.Environment environment = new();
    }
}
