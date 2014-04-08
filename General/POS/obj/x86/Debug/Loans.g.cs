﻿#pragma checksum "..\..\..\Loans.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5C18AA3B9C4D1D4FB3D51155D64E3C93"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
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
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace POS {
    
    
    /// <summary>
    /// Loans
    /// </summary>
    public partial class Loans : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\Loans.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DateTimePicker From_DTP;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Loans.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DateTimePicker To_DTP;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Loans.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Income_DG;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Loans.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Outcome_DG;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Loans.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Source.EditPanel Income_EP;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Loans.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Source.EditPanel Outcome_EP;
        
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
            System.Uri resourceLocater = new System.Uri("/POS;component/loans.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Loans.xaml"
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
            this.From_DTP = ((Xceed.Wpf.Toolkit.DateTimePicker)(target));
            
            #line 19 "..\..\..\Loans.xaml"
            this.From_DTP.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(this.From_DTP_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.To_DTP = ((Xceed.Wpf.Toolkit.DateTimePicker)(target));
            
            #line 20 "..\..\..\Loans.xaml"
            this.To_DTP.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(this.From_DTP_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Income_DG = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.Outcome_DG = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.Income_EP = ((Source.EditPanel)(target));
            
            #line 51 "..\..\..\Loans.xaml"
            this.Income_EP.Add += new System.EventHandler(this.Income_EP_Add);
            
            #line default
            #line hidden
            
            #line 51 "..\..\..\Loans.xaml"
            this.Income_EP.Edit += new System.EventHandler(this.Income_EP_Edit);
            
            #line default
            #line hidden
            
            #line 51 "..\..\..\Loans.xaml"
            this.Income_EP.Delete += new System.EventHandler(this.Income_EP_Delete);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Outcome_EP = ((Source.EditPanel)(target));
            
            #line 52 "..\..\..\Loans.xaml"
            this.Outcome_EP.Add += new System.EventHandler(this.Outcome_EP_Add);
            
            #line default
            #line hidden
            
            #line 52 "..\..\..\Loans.xaml"
            this.Outcome_EP.Edit += new System.EventHandler(this.Outcome_EP_Edit);
            
            #line default
            #line hidden
            
            #line 52 "..\..\..\Loans.xaml"
            this.Outcome_EP.Delete += new System.EventHandler(this.Outcome_EP_Delete);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

