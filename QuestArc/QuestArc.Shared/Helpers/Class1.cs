using System;
using System.Collections.Generic;
using System.Text;

namespace QuestArc.Helpers
{
    class Class1
    {
        public string Title { get; set; }
        public string Strength { get; set; }
        public string Dexterity { get; set; }
        public string Weight { get; set; }
        public string Description { get; set; }

        public Class1(String title, string strength, string dexterity, string weight, string description)
        {
            this.Title = title;
            this.Strength = strength;
            this.Dexterity = dexterity;
            this.Weight = weight;
            this.Description = description;
        }

    }
}
