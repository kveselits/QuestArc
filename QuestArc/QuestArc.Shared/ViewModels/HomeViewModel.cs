using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

using QuestArc.Models;
using QuestArc.Services;
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

        public ObservableCollection<Character> SampleItems { get; } = new ObservableCollection<Character>();

        public ICommand ItemInvokedCommand => _itemInvokedCommand ?? (_itemInvokedCommand = new RelayCommand<WinUI.TreeViewItemInvokedEventArgs>(OnItemInvoked));

        public HomeViewModel()
        {
        }

        public async Task LoadDataAsync()
        {
            var data = await SampleDataService.GetTreeViewDataAsync();
            foreach (var item in data)
            {
                SampleItems.Add(item);
            }
        }

        private void OnItemInvoked(WinUI.TreeViewItemInvokedEventArgs args)
            => SelectedItem = args.InvokedItem;
    }
}
