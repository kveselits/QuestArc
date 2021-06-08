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
            ViewModel.SelectedQuest = ViewModel.Quests[0];
            MapDialog dialog = new MapDialog(ViewModel.SelectedQuest);
            await dialog.ShowAsync();
        }

        private async void ButtonClick1(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModel.SelectedQuest = ViewModel.Quests[1];
            }
            catch (ArgumentOutOfRangeException)
            {
                ViewModel.SelectedQuest = ViewModel.Quests[0];
            }
            MapDialog dialog = new MapDialog(ViewModel.SelectedQuest);
            await dialog.ShowAsync();
        }

        private async void ButtonClick2(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModel.SelectedQuest = ViewModel.Quests[2];
            }
            catch (ArgumentOutOfRangeException)
            {
                ViewModel.SelectedQuest = ViewModel.Quests[0];
            }
            MapDialog dialog = new MapDialog(ViewModel.SelectedQuest);
            await dialog.ShowAsync();
        }

        private async void ButtonClick3(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModel.SelectedQuest = ViewModel.Quests[3];
            }
            catch (ArgumentOutOfRangeException)
            {
                ViewModel.SelectedQuest = ViewModel.Quests[0];
            }
            MapDialog dialog = new MapDialog(ViewModel.SelectedQuest);
            await dialog.ShowAsync();
        }

        private async void ButtonClick4(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModel.SelectedQuest = ViewModel.Quests[4];
            }
            catch (ArgumentOutOfRangeException)
            {
                ViewModel.SelectedQuest = ViewModel.Quests[0];
            }
            MapDialog dialog = new MapDialog(ViewModel.SelectedQuest);
            await dialog.ShowAsync();
        }

        private async void ButtonClick5(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModel.SelectedQuest = ViewModel.Quests[5];
            }
            catch (ArgumentOutOfRangeException)
            {
                ViewModel.SelectedQuest = ViewModel.Quests[0];
            }
            MapDialog dialog = new MapDialog(ViewModel.SelectedQuest);
            await dialog.ShowAsync();
        }

        private async void ButtonClick6(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModel.SelectedQuest = ViewModel.Quests[6];
            }
            catch (ArgumentOutOfRangeException)
            {
                ViewModel.SelectedQuest = ViewModel.Quests[0];
            }
            MapDialog dialog = new MapDialog(ViewModel.SelectedQuest);
            await dialog.ShowAsync();
        }
    }
}
