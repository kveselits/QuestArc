using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace QuestArc.Models
{
    // Model class we use to display data on pages like Grid, Chart, and Master Detail.

    public class Arc
    {
        public Arc()
        {
            Title = "Default Arc";
            CreatedOn = DateTime.Now;
            Difficulty = "Easy";
            Status = "Todo";
            Quests = new List<Quest>
            {
                new Quest()
            };
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Character))]
        public int ArcId { get; set; }

        [Indexed]
        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Difficulty { get; set; }
        
        public string Status { get; set; }

        [ManyToOne] 
        public Character Character { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ICollection<Quest> Quests { get; set; }

        public override string ToString()
        {
            return $"{Title} {Status}";
        }

        public string ShortDescription => $"Arc ID: {Id}";
    }
}
