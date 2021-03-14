using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace QuestArc.Models
{
    // Model class we use to display data on pages like Grid, Chart, and Master Detail.
    
    public class Character
    {
        public Character()
        {
            Name = "Default Character";
            CreatedOn = DateTime.Now;
            Arcs = new List<Arc>
            {
                new Arc()
            };
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Health { get; set; }

        public int Strength { get; set; }

        public int Stamina { get; set; }
        
        public int Intelligence { get; set; }
        
        public int Level { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ICollection<Arc> Arcs { get; set; }
    }
}
