namespace Altseed
{
    public partial class StaticFile
    {
        /// <summary>
        /// 読み込まれたデータを取得する
        /// </summary>
        public byte[] Buffer
        {
            get { return GetBuffer().ToArray(); }
        }
    }

    public partial class StreamFile
    {
        /// <summary>
        /// 現在読み込まれているデータを取得する
        /// </summary>
        public byte[] TempBuffer
        {
            get { return GetTempBuffer().ToArray(); }
        }
    }
}
