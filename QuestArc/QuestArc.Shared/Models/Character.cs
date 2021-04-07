using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace QuestArc.Models
{
    // Model class we use to display data on pages like Grid, Chart, and Master Detail.
    
    public class Character
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Health { get; set; }

        public int Strength { get; set; }

        public int Constitution { get; set; }

        public int Dexterity { get; set; }

        public int Wisdom { get; set; }

        public int Charisma { get; set; }

        public int Intelligence { get; set; }

        public int Level { get; set; }

        // Something for attribute point storage

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Arc> Arcs { get; set; }
    }
}
