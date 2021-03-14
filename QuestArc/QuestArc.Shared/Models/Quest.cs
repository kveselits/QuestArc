using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace QuestArc.Models
{
    // Model class we use to display data on pages like Grid, Chart, and Master Detail.
    public class Quest
    {
        public Quest()
        {
            CreatedOn = DateTime.Now;
            Title = "Default Quest";
            Difficulty = "Easy";
            Status = "Todo";
        }
  
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Arc))]
        public int QuestId { get; set; }

        [Indexed]
        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Description { get; set; }

        public string Difficulty { get; set; }

        public bool AllDay { get; set; }

        public string Status { get; set; }

        [ManyToOne] 
        public Arc Arc { get; set; }

        public string ShortDescription => $"Quest ID: {Id} - {Title}";
    }
}
