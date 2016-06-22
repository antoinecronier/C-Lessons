using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.Views;
using App2.WebManager;
using App2.Models;

namespace App2.ViewModels
{
    public class PokemonViewModel
    {
        private PokemonView pokemonView;

        public PokemonViewModel(PokemonView pokemonView)
        {
            this.pokemonView = pokemonView;

            Init();
        }

        public async void Init()
        {
            PokeAPI api = new PokeAPI();
            Pokemon pokemon = await api.GetFromAPI<Pokemon>(1) as Pokemon;
            //this.pokemonView.AbilityUserControl.Slot.Text = pokemon.abilities[0].Slot.ToString();
            this.pokemonView.AbilityUserControl.Ability = pokemon.abilities[0];
            this.pokemonView.FormUserControl.Form = pokemon.forms[0];
        }
    }
}
