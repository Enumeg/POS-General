﻿#pragma checksum "..\..\..\jobs.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "70F0652A0758A51B8C328F48D97835098CF74FB1314CD1F514D5F37C9E1535A8"
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
    /// jobs
    /// </summary>
    public partial class jobs : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\jobs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Main_GD;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\jobs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Name_TB;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\jobs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button add_update_outcome;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\jobs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox New;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\jobs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LB;
        
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
            System.Uri resourceLocater = new System.Uri("/POS;component/jobs.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\jobs.xaml"
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
            this.Name_TB = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\..\jobs.xaml"
            this.Name_TB.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Model_TB_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.add_update_outcome = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\jobs.xaml"
            this.add_update_outcome.Click += new System.Windows.RoutedEventHandler(this.add_update_outcome_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.New = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.LB = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            
            #line 23 "..\..\..\jobs.xaml"
            ((Source.EditPanel)(target)).Add += new System.EventHandler(this.EP_Add);
            
            #line default
            #line hidden
            
            #line 23 "..\..\..\jobs.xaml"
            ((Source.EditPanel)(target)).Edit += new System.EventHandler(this.EP_Edit);
            
            #line default
            #line hidden
            
            #line 23 "..\..\..\jobs.xaml"
            ((Source.EditPanel)(target)).Delete += new System.EventHandler(this.EP_Delete);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

