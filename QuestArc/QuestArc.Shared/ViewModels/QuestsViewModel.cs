using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using QuestArc.Models;

namespace QuestArc.ViewModels
{
    public class QuestsViewModel : NotificationBase
    {
        private ObservableCollection<QuestViewModel> _quests;

        public QuestsViewModel()
        {
            Quests = new ObservableCollection<QuestViewModel>();
        }


        public ObservableCollection<QuestViewModel> Quests
        {
            get => _quests;
            set 
            { 
                if (_quests == value)
                    return;
                _quests = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadAsync()
        {
            Quests.Clear();
            await Task.Delay(2000);

                Quests.Add(new QuestViewModel()
                {
                    Id = 1,
                    Description = "Go to school",
                    AllDay = false,
                    Difficulty = Difficulty.Easy,
                    EndTime = DateTime.Today,
                    StartTime = DateTime.Now
                }

                );

                Quests.Add(new QuestViewModel()
                    {
                        Id = 2,
                        Description = "Go to mall",
                        AllDay = false,
                        Difficulty = Difficulty.Easy,
                        EndTime = DateTime.Today,
                        StartTime = DateTime.Now
                    }

                );

                
        }
        public async void Launch()
        {
            await LoadAsync();
        }
    }
}
