﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.3053
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CHSNS.SQLServerImplement.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\sqlexpress;Initial Catalog=CHSNS.Servicebase;Integrated Security=Tr" +
            "ue")]
        public string CHSNS_DatabaseConnectionString {
            get {
                return ((string)(this["CHSNS_DatabaseConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\sqlexpress;Initial Catalog=CHSNS.Database_DB_0d1a7df4-999c-4ef4-807" +
            "4-83a3fe2a0ffd;Integrated Security=True")]
        public string CHSNS_Database_DB_0d1a7df4_999c_4ef4_8074_83a3fe2a0ffdConnectionString {
            get {
                return ((string)(this["CHSNS_Database_DB_0d1a7df4_999c_4ef4_8074_83a3fe2a0ffdConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\sqlexpress;Initial Catalog=CHSNS.Database;Integrated Security=True")]
        public string CHSNS_DatabaseConnectionString1 {
            get {
                return ((string)(this["CHSNS_DatabaseConnectionString1"]));
            }
        }
    }
}
