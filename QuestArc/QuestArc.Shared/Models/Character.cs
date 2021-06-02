using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace QuestArc.Models
{
    // Model class we use to display data on pages like Grid, Chart, and Master Detail.

    public class Character : ObservableObject
    {
        private string name;
        private int health = 100;
        private int currentHealth = 100;
        private int strength = 8;
        private int constitution = 8;
        private int dexterity = 8;
        private int wisdom = 8;
        private int charisma = 8;
        private int stamina = 8;
        private int intelligence = 8;
        private int level = 1;
        private int baseDamage = 6;
        private ObservableCollection<Item> items;
        private ObservableCollection<Arc> arcs;
        private DateTime createdOn;
        private int unallocatedPoints;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public DateTime CreatedOn { get => createdOn; set => SetProperty(ref createdOn, value); }

        public int Health { get => health; set => SetProperty(ref health, value); }

        public int CurrentHealth { get => currentHealth; set => SetProperty(ref currentHealth, value); }

        public int Strength { get => strength; set => SetProperty(ref strength, value); }

        public int Constitution { get => constitution; set => SetProperty(ref constitution, value); }

        public int BaseDamage { get => baseDamage; set => SetProperty(ref baseDamage, value); }

        // Dex should control how many actions a character can use during a turn
        public int Dexterity { get => dexterity; set => SetProperty(ref dexterity, value); }

        public int Wisdom { get => wisdom; set => SetProperty(ref wisdom, value); }

        public int Charisma { get => charisma; set => SetProperty(ref charisma, value); }

        public int Intelligence { get => intelligence; set => SetProperty(ref intelligence, value); }

        public int Level { get => level; set => SetProperty(ref level, value); }

        public int Stamina { get => stamina; set => SetProperty(ref stamina, value); }

        public int UnallocatedPoints { get => unallocatedPoints; set => SetProperty(ref unallocatedPoints, value); }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Arc> Arcs { get => arcs; set => SetProperty(ref arcs, value); }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Item> Items { get => items; set => SetProperty(ref items, value); }

        [Ignore]
        public Item RightHand { get; set; }
        [Ignore]
        public Item LeftHand { get; set; }
        [Ignore]
        public Item Chest { get; set; }
        [Ignore]
        public Item Legs { get; set; }
        [Ignore]
        public Item Hands { get; set; }
        [Ignore]
        public Item Feet { get; set; }
        [Ignore]
        public Item Back { get; set; }
        [Ignore]
        public Item Head { get; set; }

        public bool Initialized { get; set; }

        public bool EquipItem(Item item)
        {
            switch (item.Slot)
            {
                case ItemSlot.RIGHTHAND:
                    if (RightHand != null)
                        DeModifyStats(RightHand);
                    RightHand = item;
                    ModifyStats(item);
                    return true;

                case ItemSlot.LEFTHAND:
                    if (LeftHand != null)
                        DeModifyStats(LeftHand);
                    LeftHand = item;
                    ModifyStats(item);
                    return true;

                case ItemSlot.CHEST:
                    if (Chest != null)
                        DeModifyStats(Chest);
                    Chest = item;
                    ModifyStats(item);
                    return true;

                case ItemSlot.LEGS:
                    if (Legs != null)
                        DeModifyStats(Legs);
                    Legs = item;
                    ModifyStats(item);
                    return true;

                case ItemSlot.HANDS:
                    if (Hands != null)
                        DeModifyStats(Hands);
                    Hands = item;
                    ModifyStats(item);
                    return true;

                case ItemSlot.FEET:
                    if (Feet != null)
                        DeModifyStats(Feet);
                    Feet = item;
                    ModifyStats(item);
                    return true;

                case ItemSlot.BACK:
                    if (Back != null)
                        DeModifyStats(Back);
                    Back = item;
                    ModifyStats(item);
                    return true;

                case ItemSlot.HEAD:
                    if (Head != null)
                        DeModifyStats(Head);
                    Head = item;
                    ModifyStats(item);
                    return true;

                default:
                    return false;
            }
        }

        public void ModifyStats(Item item)
        {
            BaseDamage += item.BaseDamage;
            Health += item.Health;
            Strength += item.Strength;
            Stamina += item.Stamina;
            Constitution += item.Constitution;
            Dexterity += item.Dexterity;
            Wisdom += item.Wisdom;
            Intelligence += item.Intelligence;
            Charisma += item.Charisma;
        }

        public void DeModifyStats(Item item)
        {
            BaseDamage -= item.BaseDamage;
            Health -= item.Health;
            Strength -= item.Strength;
            Stamina -= item.Stamina;
            Constitution -= item.Constitution;
            Dexterity -= item.Dexterity;
            Wisdom -= item.Wisdom;
            Intelligence -= item.Intelligence;
            Charisma -= item.Charisma;
        }

        public void takeDamage()
        {

        }
    }
}
