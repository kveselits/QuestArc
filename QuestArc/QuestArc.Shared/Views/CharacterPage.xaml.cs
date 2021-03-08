using System;

using QuestArc.ViewModels;

using Windows.UI.Xaml.Controls;

namespace QuestArc.Views
{
    public sealed partial class CharacterPage : Page
    {
        public CharacterViewModel ViewModel { get; } = new CharacterViewModel();

        public CharacterPage()
        {
            InitializeComponent();
        }
    }
}
