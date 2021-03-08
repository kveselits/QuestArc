using System;
using System.Collections.Generic;

namespace QuestArc.Models
{
    // This is used by the SampleDataService.
    // It is the model class we use to display data on pages like Grid, Chart, and Master Detail.
    
    public class Character
    {
        public int Id { get; set; }

        public DateTime CreatedTime { get; set; }

        public string Name { get; set; }

        public int Health { get; set; }

        public int Strength { get; set; }

        public int Stamina { get; set; }
        
        public int Intelligence { get; set; }
        
        public int Level { get; set; }

        public ICollection<Arc> Arcs { get; set; }
    }
}
