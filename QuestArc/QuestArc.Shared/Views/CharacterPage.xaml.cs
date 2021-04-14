using System;
using System.Collections.Generic;
using QuestArc.ViewModels;

using Windows.UI.Xaml.Controls;
using QuestArc.Models;
using Windows.UI.Xaml;

namespace QuestArc.Views
{
    public sealed partial class CharacterPage : Page
    {
        public CharacterViewModel ViewModel { get; } = new CharacterViewModel();

        public CharacterPage()
        {
            Character character = App.Database.GetCharacterAsync(1).Result;
            this.CharacterRef = character;
            this._viewName = character.Name;
            this._viewHealth = character.Health;
            this._viewStr = character.Strength;
            this._viewCon = character.Constitution;
            this._viewDex = character.Dexterity;
            this._viewWis = character.Wisdom;
            this._viewCha = character.Charisma;
            this._viewInt = character.Intelligence;
            this.numLevel = character.Level;
            this._viewLevel = "Level: " + Convert.ToString(this.numLevel);
            InitializeComponent();
        }

        public async void StrButton_Pressed(object sender, RoutedEventArgs e)
        {
            viewStr = viewStr + 1;
            await App.Database.SaveCharacterAsync(CharacterRef);
        }

        private async void ConButton_Pressed(object sender, RoutedEventArgs e)
        {
            viewCon = viewCon + 1;
            await App.Database.SaveCharacterAsync(CharacterRef);
        }

        private async void DexButton_pressed(object sender, RoutedEventArgs e)
        {
            viewDex = viewDex + 1;
            await App.Database.SaveCharacterAsync(CharacterRef);
        }


        private Character CharacterRef;

        private string _viewName;
        public string viewName 
        {
            get => _viewName;
            set => _viewName = value;
        }

        private int _viewHealth;
        public int viewHealth 
        {
            get => _viewHealth;
            set => _viewHealth = value;
        }

        private int _viewStr;
        public int viewStr 
        {
            get => _viewStr;
            set => _viewStr = value;
        }

        private int _viewCon;
        public int viewCon
        {
            get => _viewCon;
            set => _viewCon = value;
        }

        private int _viewDex;
        public int viewDex
        {
            get => _viewDex;
            set => _viewDex = value;
        }

        private int _viewWis;
        public int viewWis
        {
            get => _viewWis;
            set => _viewWis = value;
        }

        private int _viewCha;
        public int viewCha
        {
            get => _viewCha;
            set => _viewCha = value;
        }


        private int _viewInt;
        public int viewInt 
        {
            get => _viewInt;
            set => _viewInt = value;
        }

        private int numLevel;
        private string _viewLevel;
        public string viewLevel 
        {
            get => _viewLevel;
            set => _viewLevel = "Level: " + value;
        }
    }
}
