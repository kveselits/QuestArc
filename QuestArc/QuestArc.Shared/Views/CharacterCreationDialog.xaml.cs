using System;
using System.Collections.Generic;

using Windows.UI.Xaml.Controls;
using QuestArc.Models;
using QuestArc.Views;

using Windows.UI.Xaml;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using QuestArc.ViewModels;

namespace QuestArc.Views
{
    public sealed partial class CharacterCreationDialog : ContentDialog
    {
        public CharacterViewModel ViewModel { get; }

        public CharacterCreationDialog(CharacterViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = ViewModel; 
        }

        private async void StrButton_Pressed(object sender, RoutedEventArgs e)
        {
            if (ViewModel.CharacterRef.UnallocatedPoints > 0)
            {
                ViewModel.viewStr += 1;
                ViewModel.CharacterRef.Strength += 1;
                ViewModel.CharacterRef.UnallocatedPoints -= 1;
                ViewModel.viewUnallocatedPoints -= 1;
            }

            ViewModel.CharacterRef.Initialized = true;
            await App.Database.SaveCharacterAsync(ViewModel.CharacterRef);
        }

        private async void ConButton_Pressed(object sender, RoutedEventArgs e)
        {
            if (ViewModel.CharacterRef.UnallocatedPoints > 0)
            {
                ViewModel.viewCon += 1;
                ViewModel.CharacterRef.Constitution += 1;
                ViewModel.CharacterRef.UnallocatedPoints -= 1;
                ViewModel.viewUnallocatedPoints -= 1;
            }

            ViewModel.CharacterRef.Initialized = true;
            await App.Database.SaveCharacterAsync(ViewModel.CharacterRef);
        }

        private async void DexButton_Pressed(object sender, RoutedEventArgs e)
        {
            if (ViewModel.CharacterRef.UnallocatedPoints > 0)
            {
                ViewModel.viewDex += 1;
                ViewModel.CharacterRef.Dexterity += 1;
                ViewModel.CharacterRef.UnallocatedPoints -= 1;
                ViewModel.viewUnallocatedPoints -= 1;
            }

            ViewModel.CharacterRef.Initialized = true;
            await App.Database.SaveCharacterAsync(ViewModel.CharacterRef);
        }

        private async void WisButton_Pressed(object sender, RoutedEventArgs e)
        {
            if (ViewModel.CharacterRef.UnallocatedPoints > 0)
            {
                ViewModel.viewWis += 1;
                ViewModel.CharacterRef.Wisdom += 1;
                ViewModel.CharacterRef.UnallocatedPoints -= 1;
                ViewModel.viewUnallocatedPoints -= 1;
            }

            ViewModel.CharacterRef.Initialized = true;
            await App.Database.SaveCharacterAsync(ViewModel.CharacterRef);
        }

        private async void ChaButton_Pressed(object sender, RoutedEventArgs e)
        {
            if (ViewModel.CharacterRef.UnallocatedPoints > 0)
            {
                ViewModel.viewCha += 1;
                ViewModel.CharacterRef.Charisma += 1;
                ViewModel.CharacterRef.UnallocatedPoints -= 1;
                ViewModel.viewUnallocatedPoints -= 1;
            }

            ViewModel.CharacterRef.Initialized = true;
            await App.Database.SaveCharacterAsync(ViewModel.CharacterRef);
        }

        private async void IntButton_Pressed(object sender, RoutedEventArgs e)
        {
            if (ViewModel.CharacterRef.UnallocatedPoints > 0)
            {
                ViewModel.viewInt += 1;
                ViewModel.CharacterRef.Intelligence += 1;
                ViewModel.CharacterRef.UnallocatedPoints -= 1;
                ViewModel.viewUnallocatedPoints -= 1;
            }

            ViewModel.CharacterRef.Initialized = true;
            await App.Database.SaveCharacterAsync(ViewModel.CharacterRef);
        }

        private async void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            ViewModel.viewName = charNameTextBox.Text;
            Character newCharacter = new Character()
            {
                Name = ViewModel.viewName,
                Arcs = new ObservableCollection<Arc>(),
                Items = new ObservableCollection<Item>(),
                Health = ViewModel.viewHealth,
                Strength = ViewModel.viewStr,
                Constitution = ViewModel.viewCon,
                Dexterity = ViewModel.viewDex,
                Wisdom = ViewModel.viewWis,
                Charisma = ViewModel.viewCha,
                Intelligence = ViewModel.viewInt,
                Initialized = true

            };
            App.Database.CurrentCharacter = newCharacter;
            App.Database.CurrentCharacter.Initialized = true;
            await App.Database.SaveCharacterAsync(App.Database.CurrentCharacter);

            Hide();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Hide();
        }
    }
}
