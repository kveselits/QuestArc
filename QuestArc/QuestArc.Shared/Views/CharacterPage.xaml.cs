using System;
using System.Collections.Generic;
using QuestArc.ViewModels;

using Windows.UI.Xaml.Controls;
using QuestArc.Models;

namespace QuestArc.Views
{
    public sealed partial class CharacterPage : Page
    {
        public CharacterViewModel ViewModel { get; } = new CharacterViewModel();

        public CharacterPage()
        {
            Character character = App.Database.GetCharacterAsync(1).Result;
            UpdateCharacter(character);
            InitializeComponent();
        }

        private void UpdateCharacter(Character character)
        {
            
        }
    }
}
