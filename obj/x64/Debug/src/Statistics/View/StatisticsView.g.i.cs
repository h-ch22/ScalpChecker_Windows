﻿#pragma checksum "..\..\..\..\..\..\src\Statistics\View\StatisticsView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "40933FBFFCFD0A2A7B98767887A55E3067890BA859BB0120FE0E85B807CA69C9"
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
using ScalpAnalysis.src.Statistics.View;
using SciChart.Wpf.UI.Transitionz;
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


namespace ScalpAnalysis.src.Statistics.View {
    
    
    /// <summary>
    /// StatisticsView
    /// </summary>
    public partial class StatisticsView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\..\..\src\Statistics\View\StatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_previous;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\..\..\src\Statistics\View\StatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TXT_ID;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\..\src\Statistics\View\StatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton btn_calendar;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\..\..\src\Statistics\View\StatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Calendar CalendarControl;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\..\..\src\Statistics\View\StatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_next;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\..\..\src\Statistics\View\StatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame Frame_Statistics;
        
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
            System.Uri resourceLocater = new System.Uri("/ScalpAnalysis;component/src/statistics/view/statisticsview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\src\Statistics\View\StatisticsView.xaml"
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
            this.btn_previous = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\..\..\src\Statistics\View\StatisticsView.xaml"
            this.btn_previous.Click += new System.Windows.RoutedEventHandler(this.onClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TXT_ID = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.btn_calendar = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 38 "..\..\..\..\..\..\src\Statistics\View\StatisticsView.xaml"
            this.btn_calendar.Click += new System.Windows.RoutedEventHandler(this.onCalendarButtonClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CalendarControl = ((System.Windows.Controls.Calendar)(target));
            return;
            case 5:
            this.btn_next = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\..\..\..\src\Statistics\View\StatisticsView.xaml"
            this.btn_next.Click += new System.Windows.RoutedEventHandler(this.onClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Frame_Statistics = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

