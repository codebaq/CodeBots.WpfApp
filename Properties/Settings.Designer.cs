namespace CodeBots.WpfApp.Properties
{
    [global::System.Runtime.CompilerServices.CompilerGenerated()]
    [global::System.CodeDom.Compiler.GeneratedCode("SettingsSingleFileGenerator", "1.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase
    {
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default => defaultInstance;

        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Configuration.DefaultSettingValue("")]
        public string Token
        {
            get => ((string)(this["Token"]));
            set => this["Token"] = value;
        }
    }
}
