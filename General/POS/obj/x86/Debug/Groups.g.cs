﻿#pragma checksum "..\..\..\Groups.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4E3E8E61F1C9D0D0F577FADAFA6D4CBC04889745FFB26789AF3D170899A7FA95"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Source;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace POS {
    
    
    /// <summary>
    /// Groups
    /// </summary>
    public partial class Groups : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\Groups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Main_GD;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Groups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Type_TB;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Groups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox New;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Groups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LB;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Groups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Source.SavePanel Save;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/POS;component/groups.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Groups.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Main_GD = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.Type_TB = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\..\Groups.xaml"
            this.Type_TB.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Type_TB_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.New = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 4:
            this.LB = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.Save = ((Source.SavePanel)(target));
            
            #line 21 "..\..\..\Groups.xaml"
            this.Save.Save += new System.EventHandler(this.Save_Save);
            
            #line default
            #line hidden
            
            #line 21 "..\..\..\Groups.xaml"
            this.Save.Cancel += new System.EventHandler(this.Save_Cancel);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 22 "..\..\..\Groups.xaml"
            ((Source.EditPanel)(target)).Add += new System.EventHandler(this.EditPanel_Add);
            
            #line default
            #line hidden
            
            #line 22 "..\..\..\Groups.xaml"
            ((Source.EditPanel)(target)).Edit += new System.EventHandler(this.EditPanel_Edit);
            
            #line default
            #line hidden
            
            #line 22 "..\..\..\Groups.xaml"
            ((Source.EditPanel)(target)).Delete += new System.EventHandler(this.EditPanel_Delete);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

