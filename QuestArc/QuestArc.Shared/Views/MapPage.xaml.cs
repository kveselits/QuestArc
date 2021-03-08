using System;

using QuestArc.ViewModels;

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
    }
}
