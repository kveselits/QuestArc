using System;
using System.Collections.ObjectModel;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using QuestArc.Models;
using Windows.UI.Xaml;

namespace QuestArc.ViewModels
{
    public class CharacterViewModel : ObservableObject
    {
        public Character CharacterRef { get; set;}
        public CharacterViewModel()
        {
            Character character = App.Database.GetCharacterAsync(1).Result;
            CharacterRef = character;
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
        }

        private string _viewName;
        public string viewName
        {
            get => _viewName;
            set => SetProperty(ref _viewName, value);
        }

        private int _viewHealth;
        public int viewHealth
        {
            get => _viewHealth;
            set => SetProperty(ref _viewHealth, value);
        }

        private int _viewStr;
        public int viewStr
        {
            get => _viewStr;
            set => SetProperty(ref _viewStr, value);
        }

        private int _viewCon;
        public int viewCon
        {
            get => _viewCon;
            set => SetProperty(ref _viewCon, value);
        }

        private int _viewDex;
        public int viewDex
        {
            get => _viewDex;
            set => SetProperty(ref _viewDex, value);
        }

        private int _viewWis;
        public int viewWis
        {
            get => _viewWis;
            set => SetProperty(ref _viewWis, value);
        }

        private int _viewCha;
        public int viewCha
        {
            get => _viewCha;
            set => SetProperty(ref _viewCha, value);
        }


        private int _viewInt;
        public int viewInt
        {
            get => _viewInt;
            set => SetProperty(ref _viewInt, value);
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
