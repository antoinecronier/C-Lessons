using App2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace App2.UserControls
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class AbilityUserControl : BaseUserControl
    {
        private Ability ability;

        public Ability Ability
        {
            get { return ability; }
            set
            {
                ability = value;
                base.OnPropertyChanged("Ability");
            }
        }

        //public TextBlock Slot { get; set; }

        public AbilityUserControl()
        {
            this.InitializeComponent();
            //this.Slot = this.slot;
            this.DataContext = this;
        }
    }
}
