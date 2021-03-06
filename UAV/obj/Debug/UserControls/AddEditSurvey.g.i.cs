﻿#pragma checksum "..\..\..\UserControls\AddEditSurvey.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "37A982121209C1091AA97511251EB238"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
using Microsoft.Maps.MapControl.WPF;
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


namespace UAV.UserControls {
    
    
    /// <summary>
    /// AddEditSurvey
    /// </summary>
    public partial class AddEditSurvey : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 51 "..\..\..\UserControls\AddEditSurvey.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTitle;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\UserControls\AddEditSurvey.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbSites;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\UserControls\AddEditSurvey.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbCustomers;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\UserControls\AddEditSurvey.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker txtDate;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\UserControls\AddEditSurvey.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTime;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\UserControls\AddEditSurvey.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Maps.MapControl.WPF.Map CustomerSiteMap;
        
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
            System.Uri resourceLocater = new System.Uri("/UAV;component/usercontrols/addeditsurvey.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\AddEditSurvey.xaml"
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
            
            #line 7 "..\..\..\UserControls\AddEditSurvey.xaml"
            ((UAV.UserControls.AddEditSurvey)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 38 "..\..\..\UserControls\AddEditSurvey.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnSurveyList_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.cmbSites = ((System.Windows.Controls.ComboBox)(target));
            
            #line 54 "..\..\..\UserControls\AddEditSurvey.xaml"
            this.cmbSites.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbSites_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cmbCustomers = ((System.Windows.Controls.ComboBox)(target));
            
            #line 57 "..\..\..\UserControls\AddEditSurvey.xaml"
            this.cmbCustomers.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbCustomers_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtDate = ((System.Windows.Controls.DatePicker)(target));
            
            #line 61 "..\..\..\UserControls\AddEditSurvey.xaml"
            this.txtDate.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.dpDate_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txtTime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.CustomerSiteMap = ((Microsoft.Maps.MapControl.WPF.Map)(target));
            return;
            case 9:
            
            #line 79 "..\..\..\UserControls\AddEditSurvey.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnNext_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

