using System;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using QuestArc.Models;

namespace QuestArc.ViewModels
{
    public class CharacterViewModel : ObservableObject
    {
        public Character CharacterRef { get; set; }
        public Monster MonsterRef { get; set; }

        public CharacterViewModel()
        {
            Character character = App.Database.CurrentCharacter;
            MonsterRef = new Monster("Goblin", 100, 5);
            CharacterRef = character;
            this._viewName = character.Name;
            this._viewHealth = character.Health;
            this._viewCurrentHealth = character.Health;
            this._viewStr = character.Strength;
            this._viewCon = character.Constitution;
            this._viewDex = character.Dexterity;
            this._viewWis = character.Wisdom;
            this._viewCha = character.Charisma;
            this._viewInt = character.Intelligence;
            this._viewBaseDamage = character.BaseDamage;
            this.numPoints = character.UnallocatedPoints;
            this._unallocatedPoints = "Points: " + Convert.ToString(this.numPoints);
            this.numLevel = character.Level;
            this._viewUnallocatedPoints = character.UnallocatedPoints;
            this._viewLevel = "Level: " + Convert.ToString(this.numLevel);

            this.viewLeftHand = character.LeftHand;
            this.viewRightHand = character.RightHand;
            this.viewBack = character.Back;
            this.viewHelmet = character.Head;
            this.viewChest = character.Chest;
            this.viewFeet = character.Feet;

            this._viewMonsterDamage = MonsterRef.Damage;
            this._viewMonsterHealth = MonsterRef.Health;
            this._viewMonsterCurrentHealth = MonsterRef.CurrentHealth;
            this._viewMonsterName = MonsterRef.Name;


        }

        private int numPoints;
        private string _unallocatedPoints;
        public string UnallocatedPoints
        {
            get => _unallocatedPoints;
            set => _unallocatedPoints = "Points: " + value;
        }

        private string _viewName;
        public string viewName
        {
            get => _viewName;
            set => SetProperty(ref _viewName, value);
        }

        private int _viewUnallocatedPoints;
        public int viewUnallocatedPoints
        {
            get => _viewUnallocatedPoints;
            set => SetProperty(ref _viewUnallocatedPoints, value);
        }

        private int _viewHealth;
        public int viewHealth
        {
            get => _viewHealth;
            set => SetProperty(ref _viewHealth, value);
        }

        private int _viewCurrentHealth;
        public int viewCurrentHealth
        {
            get => _viewCurrentHealth;
            set => SetProperty(ref _viewCurrentHealth, value);
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

        private int _viewBaseDamage;
        public int viewBaseDamage
        {
            get => _viewBaseDamage;
            set => SetProperty(ref _viewBaseDamage, value);
        }

        private Item _viewLeftHand;
        public Item viewLeftHand
        {
            get => _viewLeftHand;
            set => SetProperty(ref _viewLeftHand, value);
        }

        private Item _viewRightHand;
        public Item viewRightHand
        {
            get => _viewRightHand;
            set => SetProperty(ref _viewRightHand, value);
        }

        private Item _viewChest;
        public Item viewChest
        {
            get => _viewChest;
            set => SetProperty(ref _viewChest, value);
        }

        private Item _viewFeet;
        public Item viewFeet
        {
            get => _viewFeet;
            set => SetProperty(ref _viewFeet, value);
        }

        private Item _viewHelmet;
        public Item viewHelmet
        {
            get => _viewHelmet;
            set => SetProperty(ref _viewHelmet, value);
        }

        private Item _viewBack;
        public Item viewBack
        {
            get => _viewBack;
            set => SetProperty(ref _viewBack, value);
        }

        private int _viewMonsterDamage;
        public int viewMonsterDamage
        {
            get => _viewMonsterDamage;
            set => SetProperty(ref _viewMonsterDamage, value);
        }

        private int _viewMonsterHealth;
        public int viewMonsterHealth
        {
            get => _viewMonsterHealth;
            set => SetProperty(ref _viewMonsterHealth, value);
        }

        private int _viewMonsterCurrentHealth;
        public int viewMonsterCurrentHealth
        {
            get => _viewMonsterCurrentHealth;
            set => SetProperty(ref _viewMonsterCurrentHealth, value);
        }

        private string _viewMonsterName;
        public string viewMonsterName
        {
            get => _viewMonsterName;
            set => SetProperty(ref _viewMonsterName, value);
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
