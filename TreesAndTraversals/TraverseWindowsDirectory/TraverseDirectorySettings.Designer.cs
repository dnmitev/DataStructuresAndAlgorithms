﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TraverseWindowsDirectory {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class TraverseDirectorySettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static TraverseDirectorySettings defaultInstance = ((TraverseDirectorySettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new TraverseDirectorySettings())));
        
        public static TraverseDirectorySettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Windows")]
        public string DirString {
            get {
                return ((string)(this["DirString"]));
            }
            set {
                this["DirString"] = value;
            }
        }
    }
}
