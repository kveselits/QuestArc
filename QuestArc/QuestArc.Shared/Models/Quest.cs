using Microsoft.Toolkit.Mvvm.ComponentModel;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace QuestArc.Models
{
    // Model class we use to display data on pages like Grid, Chart, and Master Detail.
    public class Quest : ObservableObject
    {
        private string title;
        private DateTime createdOn;
        private DateTime startTime;
        private DateTime endTime;
        private string description;
        private string difficulty;
        private bool allDay;
        private string status;
        private Arc arc;
        private Character character;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Arc))]
        public int ArcId { get; set; }

        [ForeignKey(typeof(Character))]
        public int CharacterId { get; set; }


        public string Title { get => title; set => SetProperty(ref title, value); }

        public DateTime CreatedOn { get => createdOn; set => SetProperty(ref createdOn, value); }

        public DateTime StartTime { get => startTime; set => SetProperty(ref startTime, value); }

        public DateTime EndTime { get => endTime; set => SetProperty(ref endTime, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public string Difficulty { get => difficulty; set => SetProperty(ref difficulty, value); }

        public bool AllDay { get => allDay; set => SetProperty(ref allDay, value); }

        public string Status { get => status; set => SetProperty(ref status, value); }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Arc Arc { get => arc; set => SetProperty(ref arc, value); }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Character Character { get => character; set => SetProperty(ref character, value); }

        public string ShortDescription => $"Quest ID: {Id} - {Title}";
    }
}
