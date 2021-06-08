using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using QuestArc.Models;

namespace QuestArc.ViewModels
{
    public class MapViewModel : ObservableObject
    {
        private Quest selectedQuest;

        public MapViewModel()
        {
            Quests = App.Database.GetQuestsAsync().Result;
            SelectedQuest = Quests[0];
        }
        public List<Quest> Quests { get; set; }
        public Quest SelectedQuest { get => selectedQuest; set => SetProperty(ref selectedQuest, value); }
    }
}
