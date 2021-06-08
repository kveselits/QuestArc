using System;

using QuestArc.ViewModels;

using Windows.UI.Xaml.Controls;

namespace QuestArc.Views
{
    public sealed partial class QuestLogPage : Page
    {
        public QuestLogViewModel ViewModel { get; } = new QuestLogViewModel();

        public QuestLogPage()
        {
            InitializeComponent();
            Quests.ItemsSource = App.Database.GetQuestsOnStatusAsync();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
