﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30128.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CHSNS.SQLServerImplement.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
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