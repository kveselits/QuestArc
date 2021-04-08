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

        public SQLiteDatabase Db = App.Database;

        public ICommand ItemInvokedCommand => _itemInvokedCommand ?? (_itemInvokedCommand = new RelayCommand<WinUI.TreeViewItemInvokedEventArgs>(OnItemInvoked));

        public HomeViewModel()
        {
            //Characters = new ObservableCollection<Character> { App.Database.CurrentCharacter };
        }

       
        private void OnItemInvoked(WinUI.TreeViewItemInvokedEventArgs args)
            => SelectedItem = args.InvokedItem;
    }
}
