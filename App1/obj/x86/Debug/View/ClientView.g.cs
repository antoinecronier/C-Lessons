﻿#pragma checksum "C:\Users\tactfactory\documents\visual studio 2015\Projects\App1\App1\View\ClientView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4388A88F8BDD1C316DA985B3DB1AC34A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App1.View
{
    partial class ClientView : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.UCClient = (global::App1.MyUserControl.ClientUserControl)(target);
                }
                break;
            case 2:
                {
                    this.LUCProductBuy = (global::App1.MyUserControl.ProductListUserControl)(target);
                }
                break;
            case 3:
                {
                    this.LUCProductAvaiable = (global::App1.MyUserControl.ProductListUserControl)(target);
                }
                break;
            case 4:
                {
                    this.UCProduct = (global::App1.MyUserControl.ProductUserControl)(target);
                }
                break;
            case 5:
                {
                    this.UCAddRemove = (global::App1.MyUserControl.AddRemoveUserControl)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

