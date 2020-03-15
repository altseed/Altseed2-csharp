using System;
using System.Runtime.Serialization;

namespace Altseed
{
    [Serializable]
    public sealed partial class Configuration : ISerializable
    {
        #region SerializeName
        private const string S_IsFullscreen = "S_IsFullscreen";
        private const string S_IsResizable = "S_IsResizable";
        private const string S_ConsoleLoggingEnabled = "S_ConsoleLoggingEnabled";
        private const string S_EnabledFileLoging = "S_EnabledFileLoging";
        private const string S_LogFileName = "S_LogFileName";
        private const string S_ToolEnabled = "S_ToolEnabled";
        #endregion

        private Configuration(SerializationInfo info, StreamingContext context) : this()
        {
            IsFullscreen = info.GetBoolean(S_IsFullscreen);
            IsResizable = info.GetBoolean(S_IsResizable);
            ConsoleLoggingEnabled = info.GetBoolean(S_ConsoleLoggingEnabled);
            FileLoggingEnabled = info.GetBoolean(S_EnabledFileLoging);
            LogFileName = info.GetString(S_LogFileName) ?? throw new SerializationException("デシリアライズに失敗しました");
            ToolEnabled = info.GetBoolean(S_ToolEnabled);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException("引数がnullです", nameof(info));

            info.AddValue(S_IsFullscreen, IsFullscreen);
            info.AddValue(S_IsResizable, IsResizable);
            info.AddValue(S_ConsoleLoggingEnabled, ConsoleLoggingEnabled);
            info.AddValue(S_EnabledFileLoging, FileLoggingEnabled);
            info.AddValue(S_LogFileName, LogFileName);
            info.AddValue(S_ToolEnabled, ToolEnabled);
        }
    }
}
