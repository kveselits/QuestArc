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
        private int health;
        private int strength;
        private int constitution;
        private int dexterity;
        private int wisdom;
        private int charisma;
        private int stamina;
        private int intelligence;
        private int level;
        private ObservableCollection<Arc> arcs;
        private DateTime createdOn;
        private ObservableCollection<Arc> tempArcs;
        private int unallocatedPoints;
        private ObservableCollection<Quest> tempQuests;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public DateTime CreatedOn { get => createdOn; set => SetProperty(ref createdOn, value); }

        public int Health { get => health; set => SetProperty(ref health, value); }

        public int Strength { get => strength; set => SetProperty(ref strength, value); }

        public int Constitution { get => constitution; set => SetProperty(ref constitution, value); }

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
        public ObservableCollection<Arc> TempArcs { get => tempArcs; set => SetProperty(ref tempArcs, value); }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Quest> TempQuests { get => tempQuests; set => SetProperty(ref tempQuests, value); }
    }
}
