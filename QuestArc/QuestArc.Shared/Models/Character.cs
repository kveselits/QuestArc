﻿using System;
using System.Collections.Generic;
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
        private int stamina;
        private int intelligence;
        private int level;
        private List<Arc> arcs;
        private DateTime createdOn;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public DateTime CreatedOn { get => createdOn; set => SetProperty(ref createdOn, value); }

        public int Health { get => health; set => SetProperty(ref health, value); }

        public int Strength { get => strength; set => SetProperty(ref strength, value); }

        public int Stamina { get => stamina; set => SetProperty(ref stamina, value); }

        public int Intelligence { get => intelligence; set => SetProperty(ref intelligence, value); }

        public int Level { get => level; set => SetProperty(ref level, value); }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Arc> Arcs { get => arcs; set => SetProperty(ref arcs, value); }
    }
}
