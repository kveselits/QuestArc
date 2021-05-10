
using QuestArc.Helpers;
using QuestArc.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace QuestArc.Views
{
    public sealed partial class InventoryPage : Page
    {
        public InventoryViewModel ViewModel { get; } = new InventoryViewModel();
        ObservableCollection<Class1> Items;
        Class1 SelectedItem;

        public InventoryPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            List<Class1> tempList = new List<Class1>
            {
                new Class1("Test1", "asdfasdf", "asdfsafd", "s", "asdkjfkjsdhafjkhsdf jkashdfkjhkjh asjdkfhkjsdhfkj asdjkfhkjashdf"),
                new Class1("Test2", "asdfasdf", "asdfsafd", "s", "asdkjfkjsdhafjkhsdf jkashdfkjhkjh asjdkfhkjsdhfkj asdjkfhkjashdf"),
                new Class1("Test3", "asdfasdf", "asdfsafd", "s", "asdkjfkjsdhafjkhsdf jkashdfkjhkjh asjdkfhkjsdhfkj asdjkfhkjashdf")
            };
            Items = new ObservableCollection<Class1>(tempList);
        }

        private void ContentListView_ItemClick(object sender, SelectionChangedEventArgs e)
        {
            SelectedItem = e.AddedItems[0] as Class1;
        }
    }
}
