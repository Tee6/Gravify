﻿#pragma checksum "..\..\CreatePlaylist.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8BDBD357EA944DF76FD1B7FB411DE0E6051931276F73CA8B547D5FEB821FC8B3"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Spotify;
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


namespace Spotify {
    
    
    /// <summary>
    /// CreatePlaylist
    /// </summary>
    public partial class CreatePlaylist : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\CreatePlaylist.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas Banner1;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\CreatePlaylist.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Gravify1;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\CreatePlaylist.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CreatePlaylist1;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\CreatePlaylist.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LoadSongs1;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\CreatePlaylist.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameplaylist;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\CreatePlaylist.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox descrplaylist;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\CreatePlaylist.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas CanvasPic;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\CreatePlaylist.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image icon;
        
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
            System.Uri resourceLocater = new System.Uri("/Spotify;component/createplaylist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CreatePlaylist.xaml"
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
            this.Banner1 = ((System.Windows.Controls.Canvas)(target));
            return;
            case 2:
            this.Gravify1 = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.CreatePlaylist1 = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.LoadSongs1 = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.nameplaylist = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\CreatePlaylist.xaml"
            this.nameplaylist.GotFocus += new System.Windows.RoutedEventHandler(this.nameplaylist_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.descrplaylist = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\CreatePlaylist.xaml"
            this.descrplaylist.GotFocus += new System.Windows.RoutedEventHandler(this.descrplaylist_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CanvasPic = ((System.Windows.Controls.Canvas)(target));
            return;
            case 8:
            this.icon = ((System.Windows.Controls.Image)(target));
            return;
            case 9:
            
            #line 22 "..\..\CreatePlaylist.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 23 "..\..\CreatePlaylist.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ImportPic_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
