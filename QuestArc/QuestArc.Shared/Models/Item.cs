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
        private Character character;
        private string title;
        private string description;
        private int itemLevel;
        private int baseDamage;
        private int health;
        private int mana;
        private int strength;
        private int stamina;
        private int constitution;
        private int dexterity;
        private int wisdom;
        private int intelligence;
        private int charisma;
        private int weight;
        private ItemType type;
        private Boolean equipped;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Character))]
        public int CharacterId { get; set; }

        public string Title { get => title; set => SetProperty(ref title, value); }
        public string Description { get => description; set => SetProperty(ref description, value); }
        public int ItemLevel { get => itemLevel; set => SetProperty(ref itemLevel, value); }
        public int BaseDamage { get => baseDamage; set => SetProperty(ref baseDamage, value); }
        public int Health { get => health; set => SetProperty(ref health, value); }
        public int Mana { get => mana; set => SetProperty(ref mana, value); }
        public int Strength { get => strength; set => SetProperty(ref strength, value); }
        public int Stamina { get => stamina; set => SetProperty(ref stamina, value); }
        public int Constitution { get => constitution; set => SetProperty(ref constitution, value); }
        public int Dexterity { get => dexterity; set => SetProperty(ref dexterity, value); }
        public int Wisdom { get => wisdom; set => SetProperty(ref wisdom, value); }
        public int Intelligence { get => intelligence; set => SetProperty(ref intelligence, value); }
        public int Charisma { get => charisma; set => SetProperty(ref charisma, value); }
        public int Weight { get => weight; set => SetProperty(ref weight, value); }
        public ItemType Type { get => type; set => SetProperty(ref type, value); }
        public Boolean Equipped { get => equipped; set => SetProperty(ref equipped, value); }

        public Item()
        {
        }

        public Item(string itemName)
        {
            this.title = itemName;
        }

        public Item(string title
            , string description, int itemLevel, int baseDamage, int health, int mana, int strength, 
            int stamina, int constitution, int dexterity, int wisdom, int intelligence, int charisma, ItemType type)
        {
            this.title = title;
            this.Description = description;
            this.ItemLevel = itemLevel;
            this.BaseDamage = baseDamage;
            this.Health = health;
            this.Mana = mana;
            this.Strength = strength;
            this.Stamina = stamina;
            this.Constitution = constitution;
            this.Dexterity = dexterity;
            this.Wisdom = wisdom;
            this.Intelligence = intelligence;
            this.Charisma = charisma;
            this.Type = type;
        }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Character Character { get => character; set => SetProperty(ref character, value); }
    }

    public enum ItemType
    {
        WEAPON,
        POTION,
        ARMOR
    }
}
