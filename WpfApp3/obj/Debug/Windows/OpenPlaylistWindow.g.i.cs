﻿#pragma checksum "..\..\..\Windows\OpenPlaylistWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D62EB0D993BE461F56760020500212AD6E387841"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WpfApp3.Windows;


namespace WpfApp3.Windows {
    
    
    /// <summary>
    /// OpenPlaylistWindow
    /// </summary>
    public partial class OpenPlaylistWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Windows\OpenPlaylistWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbPlayLists;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Windows\OpenPlaylistWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOpen;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Windows\OpenPlaylistWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp3;component/windows/openplaylistwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\OpenPlaylistWindow.xaml"
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
            this.lbPlayLists = ((System.Windows.Controls.ListBox)(target));
            
            #line 12 "..\..\..\Windows\OpenPlaylistWindow.xaml"
            this.lbPlayLists.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.LbPlayLists_MouseDoubleClick_1);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\Windows\OpenPlaylistWindow.xaml"
            this.lbPlayLists.KeyDown += new System.Windows.Input.KeyEventHandler(this.LbPlayLists_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnOpen = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\Windows\OpenPlaylistWindow.xaml"
            this.btnOpen.Click += new System.Windows.RoutedEventHandler(this.BtnOpen_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\Windows\OpenPlaylistWindow.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.BtnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
