using System;
using System.Collections.Generic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace QuestArc.Models
{
    // Model class we use to display data on pages like Grid, Chart, and Master Detail.

    public class Arc : ObservableObject
    {
        private string title;
        private DateTime createdOn;
        private DateTime startTime;
        private DateTime endTime;
        private string difficulty;
        private string status;
        private Character character;
        private List<Quest> quests;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Character))]
        public int CharacterId { get; set; }

        public string Title { get => title; set => SetProperty(ref title, value); }

        public DateTime CreatedOn { get => createdOn; set => SetProperty(ref createdOn, value); }

        public DateTime StartTime { get => startTime; set => SetProperty(ref startTime, value); }

        public DateTime EndTime { get => endTime; set => SetProperty(ref endTime, value); }

        public string Difficulty { get => difficulty; set => SetProperty(ref difficulty, value); }

        public string Status { get => status; set => SetProperty(ref status, value); }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Character Character { get => character; set => SetProperty(ref character, value); }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Quest> Quests { get => quests; set => SetProperty(ref quests, value); }

        public override string ToString()
        {
            return $"{Title} {Status}";
        }

        public string ShortDescription => $"Arc ID: {Id}";
    }
}
