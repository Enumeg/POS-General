﻿#pragma checksum "..\..\..\Properties.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "20DED74DF19F559F05E8F905ADCF0410"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
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
    /// Propertiess
    /// </summary>
    public partial class Propertiess : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\Properties.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Main_GD;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Properties.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Categories_CB;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Properties.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Property_TB;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Properties.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox New;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Properties.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LB;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Properties.xaml"
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
            System.Uri resourceLocater = new System.Uri("/POS;component/properties.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Properties.xaml"
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
            this.Categories_CB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 20 "..\..\..\Properties.xaml"
            this.Categories_CB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Categories_CB_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Property_TB = ((System.Windows.Controls.TextBox)(target));
            
            #line 21 "..\..\..\Properties.xaml"
            this.Property_TB.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Property_TB_TextChanged);
            
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
            this.Save = ((Source.SavePanel)(target));
            
            #line 24 "..\..\..\Properties.xaml"
            this.Save.Save += new System.EventHandler(this.Save_Save);
            
            #line default
            #line hidden
            
            #line 24 "..\..\..\Properties.xaml"
            this.Save.Cancel += new System.EventHandler(this.Save_Cancel);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 25 "..\..\..\Properties.xaml"
            ((Source.EditPanel)(target)).Add += new System.EventHandler(this.EditPanel_Add);
            
            #line default
            #line hidden
            
            #line 25 "..\..\..\Properties.xaml"
            ((Source.EditPanel)(target)).Edit += new System.EventHandler(this.EditPanel_Edit);
            
            #line default
            #line hidden
            
            #line 25 "..\..\..\Properties.xaml"
            ((Source.EditPanel)(target)).Delete += new System.EventHandler(this.EditPanel_Delete);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

