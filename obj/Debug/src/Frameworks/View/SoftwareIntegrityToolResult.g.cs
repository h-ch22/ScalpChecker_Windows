﻿#pragma checksum "..\..\..\..\..\src\Frameworks\View\SoftwareIntegrityToolResult.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3AD6D23DC4AD9E02CD7E853AD2EF9D2634AC14FEDAD1F77198C414EC4A9D8EE4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using ScalpAnalysis.src.Frameworks.View;
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


namespace ScalpAnalysis.src.Frameworks.View {
    
    
    /// <summary>
    /// SoftwareIntegrityToolResult
    /// </summary>
    public partial class SoftwareIntegrityToolResult : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\..\src\Frameworks\View\SoftwareIntegrityToolResult.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame _NavigationFrame;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\src\Frameworks\View\SoftwareIntegrityToolResult.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TXT_RESULT_HEADER;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\src\Frameworks\View\SoftwareIntegrityToolResult.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TXT_RESULT_DETAIL;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\..\src\Frameworks\View\SoftwareIntegrityToolResult.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_positive;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\..\src\Frameworks\View\SoftwareIntegrityToolResult.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock btn_text_positive;
        
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
            System.Uri resourceLocater = new System.Uri("/ScalpAnalysis;component/src/frameworks/view/softwareintegritytoolresult.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\src\Frameworks\View\SoftwareIntegrityToolResult.xaml"
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
            this._NavigationFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 2:
            this.TXT_RESULT_HEADER = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.TXT_RESULT_DETAIL = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.btn_positive = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\..\src\Frameworks\View\SoftwareIntegrityToolResult.xaml"
            this.btn_positive.Click += new System.Windows.RoutedEventHandler(this.btn_onClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_text_positive = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

