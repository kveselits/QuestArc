using System;

using QuestArc.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace QuestArc.Views
{
    public sealed partial class MapPage : Page
    {
        public MapViewModel ViewModel { get; } = new MapViewModel();

        public MapPage()
        {
            InitializeComponent();
        }

       
        private async void ButtonClick(object sender, RoutedEventArgs e)
        {
            MapDialog dialog = new MapDialog();
            await dialog.ShowAsync();
        }
    }
}
