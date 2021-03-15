using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace QuestArc.Models
{
    // Model class we use to display data on pages like Grid, Chart, and Master Detail.
    public class Quest
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Arc))]
        public int ArcId { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Description { get; set; }

        public string Difficulty { get; set; }

        public bool AllDay { get; set; }

        public string Status { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Arc Arc { get; set; }

        public string ShortDescription => $"Quest ID: {Id} - {Title}";
    }
}
