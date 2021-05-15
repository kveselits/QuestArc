using Microsoft.Toolkit.Mvvm.ComponentModel;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuestArc.Models
{
    public class Item : ObservableObject
    {
        private int health;
        private int strength;
        private int constitution;
        private int dexterity;
        private int wisdom;
        private int charisma;
        private int stamina;
        private int intelligence;
        private int level;
        private int weight;
        private string description;
        private string title;
        private Character character;


        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Character))]
        public int CharacterId { get; set; }

        public int Health { get => health; set => SetProperty(ref health, value); }

        public string Title { get => title; set => SetProperty(ref title, value); }

        public int Strength { get => strength; set => SetProperty(ref strength, value); }

        public int Constitution { get => constitution; set => SetProperty(ref constitution, value); }

        public int Dexterity { get => dexterity; set => SetProperty(ref dexterity, value); }

        public int Weight { get => weight;  set => SetProperty(ref weight, value); }

        public int Wisdom { get => wisdom; set => SetProperty(ref wisdom, value); }

        public int Charisma { get => charisma; set => SetProperty(ref charisma, value); }

        public int Intelligence { get => intelligence; set => SetProperty(ref intelligence, value); }

        public int Level { get => level; set => SetProperty(ref level, value); }

        public int Stamina { get => stamina; set => SetProperty(ref stamina, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public Item()
        {
        }

        public Item(string title)
        {
            this.Title = title;
        }

        public Item(string title, string description, int strength, int dexterity, int weight, int health, int constitution,
            int wisdom, int charisma, int stamina)
        {
            this.Wisdom = wisdom;
            this.Constitution = constitution;
            this.Charisma = charisma;
            this.Stamina = stamina;
            this.Title = title;
            this.Health = health;
            this.Strength = strength;
            this.Dexterity = dexterity;
            this.Weight = weight;
            this.Description = description;
        }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Character Character { get => character; set => SetProperty(ref character, value); }
    }
}
