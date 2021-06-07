using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using QuestArc.Models;

namespace QuestArc.ViewModels
{
    public class MapViewModel : ObservableObject
    {
        public MapViewModel()
        {
            Quests = App.Database.GetQuestsAsync().Result;
            Waypoints = new ArrayList();
            foreach (var item in Quests)
            {
                if(Waypoints.Count < 5)
                {
                    Waypoints.Add(item);
                }
            };
        }
        public List<Quest> Quests { get; private set; }
        public ArrayList Waypoints { get; private set; }
    }
}
