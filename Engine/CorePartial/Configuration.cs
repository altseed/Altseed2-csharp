using System;
using System.Runtime.Serialization;

namespace Altseed
{
    [Serializable]
    public sealed partial class Configuration : ISerializable
    {
        #region SerializeName
        private const string S_IsFullscreenMode = "S_IsFullscreenMode";
        private const string S_IsResizable = "S_IsResizable";
        private const string S_EnabledConsoleLogging = "S_EnabledConsoleLogging";
        private const string S_EnabledFileLoging = "S_EnabledFileLoging";
        private const string S_LogFileName = "S_LogFileName";
        #endregion

        private Configuration(SerializationInfo info, StreamingContext context) : this()
        {
            IsFullscreenMode = info.GetBoolean(S_IsFullscreenMode);
            IsResizable = info.GetBoolean(S_IsResizable);
            EnabledConsoleLogging = info.GetBoolean(S_EnabledConsoleLogging);
            EnabledFileLogging = info.GetBoolean(S_EnabledFileLoging);
            LogFilename = info.GetString(S_LogFileName) ?? throw new SerializationException("デシリアライズに失敗しました");
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException("引数がnullです", nameof(info));

            info.AddValue(S_IsFullscreenMode, IsFullscreenMode);
            info.AddValue(S_IsResizable, IsResizable);
            info.AddValue(S_EnabledConsoleLogging, EnabledConsoleLogging);
            info.AddValue(S_EnabledFileLoging, EnabledFileLogging);
            info.AddValue(S_LogFileName, LogFilename);
        }
    }
}
