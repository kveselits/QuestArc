using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

using QuestArc.Models;
using QuestArc.Services;
using QuestArc.Views;
using Uno.Extensions.Specialized;
using WinUI = Microsoft.UI.Xaml.Controls;

namespace QuestArc.ViewModels
{
    public class HomeViewModel : ObservableObject
    {
        private ICommand _itemInvokedCommand;
        private object _selectedItem;

        public object SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        private ObservableCollection<Character> characters;
        public ObservableCollection<Character> Characters { get => characters; set => SetProperty(ref characters, value); }

        private ObservableCollection<Quest> quests;
        public ObservableCollection<Quest> Quests { get => quests; set => SetProperty(ref quests, value); }

        private ObservableCollection<Quest> tempQuests = App.Database.GetQuestsOnDateAsync(DateTime.Now);
        public ObservableCollection<Quest> TempQuests { get => tempQuests; set => SetProperty(ref tempQuests, value); }

        public string SelectedDay { get => selectedDay; set => SetProperty(ref selectedDay, value); }

        public SQLiteDatabase Db = App.Database;
        private string selectedDay;

        public ICommand ItemInvokedCommand => _itemInvokedCommand ?? (_itemInvokedCommand = new RelayCommand<WinUI.TreeViewItemInvokedEventArgs>(OnItemInvoked));

        public HomeViewModel()
        {  
            DateTime dt = DateTime.Now;
            SelectedDay = dt.ToShortDateString();
            /*Quests = new ObservableCollection<Quest>();
            Quests = Db.GetQuestsOnDateAsync(DateTime.Now);*/
        }

       
        private void OnItemInvoked(WinUI.TreeViewItemInvokedEventArgs args)
            => SelectedItem = args.InvokedItem;
    }
}
