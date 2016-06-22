using App2.UserControls;
using App2.ViewModels;
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

namespace App2.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class PokemonView : Page
    {
        public AbilityUserControl AbilityUserControl { get; set; }
        public FormUserControl FormUserControl { get; set; }
        public PokemonViewModel PokemonViewModel { get; set; }

        public PokemonView()
        {
            this.InitializeComponent();

            this.AbilityUserControl = this.abilityUserControl;
            this.FormUserControl = this.formUserControl;

            this.PokemonViewModel = new PokemonViewModel(this);
        }
    }
}
