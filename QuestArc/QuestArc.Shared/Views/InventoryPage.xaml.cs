using System;

using QuestArc.ViewModels;

using Windows.UI.Xaml.Controls;

namespace QuestArc.Views
{
    public sealed partial class InventoryPage : Page
    {
        public InventoryViewModel ViewModel { get; } = new InventoryViewModel();

        public InventoryPage()
        {
            InitializeComponent();
        }
    }
}
