﻿#pragma checksum "..\..\..\View\Window1.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ECC4585C420EEA8F293FE62EDB21BA3214926B59"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
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
using WpfApplication1.View;


namespace WpfApplication1.View {
    
    
    /// <summary>
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\View\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button navigationwindows;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\View\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button navigatetobase;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\View\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button navigatetoframe;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApplication1;component/view/window1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\Window1.xaml"
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
            this.navigationwindows = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\View\Window1.xaml"
            this.navigationwindows.Click += new System.Windows.RoutedEventHandler(this.navigationwindows_Click);
            
            #line default
            #line hidden
            
            #line 11 "..\..\..\View\Window1.xaml"
            this.navigationwindows.MouseEnter += new System.Windows.Input.MouseEventHandler(this.navigationwindows_MouseEnter);
            
            #line default
            #line hidden
            return;
            case 2:
            this.navigatetobase = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\View\Window1.xaml"
            this.navigatetobase.Click += new System.Windows.RoutedEventHandler(this.navigatetobase_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.navigatetoframe = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\View\Window1.xaml"
            this.navigatetoframe.Click += new System.Windows.RoutedEventHandler(this.navigatetoframe_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

