using System;
using System.Collections.Generic;
using QuestArc.ViewModels;

using Windows.UI.Xaml.Controls;
using QuestArc.Models;
using Windows.UI.Xaml;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Threading.Tasks;

namespace QuestArc.Views
{
    public sealed partial class CharacterPage : Page
    {
        public CharacterViewModel ViewModel { get; } = new CharacterViewModel();
        ContentDialogResult result;

        ContentDialog insufficientPointsDialog = new ContentDialog()
        {
            Title = "Insufficient points",
            CloseButtonText = "Ok"
        };

        ContentDialog areYouSureDialog = new ContentDialog()
        {
            CloseButtonText = "Cancel",
            PrimaryButtonText = "Do It!"
        };

        public CharacterPage()
        {
            
            InitializeComponent();
            DataContext = ViewModel;
        }

        private async Task displayDialog(int expectedPoints, int actualPoints, string stat)
        {
            if(actualPoints < expectedPoints)
            {
                int difference = expectedPoints - actualPoints;

                insufficientPointsDialog.Content = "You must acquire " + difference + " more points berfore you can level up " + stat + ".";
                result = await insufficientPointsDialog.ShowAsync();
            } else
            {
                areYouSureDialog.Content = "Are you sure you want to use " + expectedPoints + " points to level up " + stat + "?";
                areYouSureDialog.Title = "Level up " + stat + "?";
                result = await areYouSureDialog.ShowAsync();
            }
        }

        private async void StrButton_Pressed(object sender, RoutedEventArgs e)
        {
            await displayDialog(ViewModel.viewStr * 5, ViewModel.CharacterRef.UnallocatedPoints, "Strength");

            if (result == ContentDialogResult.Primary)
            {
                ViewModel.CharacterRef.UnallocatedPoints -= ViewModel.viewStr * 5;
                ViewModel.viewStr += 1;
                ViewModel.CharacterRef.Strength += 1;
                await App.Database.SaveCharacterAsync(ViewModel.CharacterRef);
            }
        }

        private async void ConButton_Pressed(object sender, RoutedEventArgs e)
        {
            await displayDialog(ViewModel.viewCon * 5, ViewModel.CharacterRef.UnallocatedPoints, "Constitution");

            if (result == ContentDialogResult.Primary)
            {
                ViewModel.CharacterRef.UnallocatedPoints -= ViewModel.viewCon * 5;
                ViewModel.viewCon += 1;
                ViewModel.CharacterRef.Constitution += 1;
                await App.Database.SaveCharacterAsync(ViewModel.CharacterRef);
            }
        }

        private async void DexButton_Pressed(object sender, RoutedEventArgs e)
        {
            await displayDialog(ViewModel.viewDex * 5, ViewModel.CharacterRef.UnallocatedPoints, "Dexterity");

            if (result == ContentDialogResult.Primary)
            {
                ViewModel.CharacterRef.UnallocatedPoints -= ViewModel.viewDex * 5;
                ViewModel.viewDex += 1;
                ViewModel.CharacterRef.Dexterity += 1;
                await App.Database.SaveCharacterAsync(ViewModel.CharacterRef);
            }
        }

        private async void WisButton_Pressed(object sender, RoutedEventArgs e)
        {
            await displayDialog(ViewModel.viewWis * 5, ViewModel.CharacterRef.UnallocatedPoints, "Wisdom");

            if (result == ContentDialogResult.Primary)
            {
                ViewModel.CharacterRef.UnallocatedPoints -= ViewModel.viewWis * 5;
                ViewModel.viewWis += 1;
                ViewModel.CharacterRef.Wisdom += 1;
                await App.Database.SaveCharacterAsync(ViewModel.CharacterRef);
            }
        }

        private async void ChaButton_Pressed(object sender, RoutedEventArgs e)
        {
            await displayDialog(ViewModel.viewCha * 5, ViewModel.CharacterRef.UnallocatedPoints, "Charisma");

            if (result == ContentDialogResult.Primary)
            {
                ViewModel.CharacterRef.UnallocatedPoints -= ViewModel.viewCha * 5;
                ViewModel.viewCha += 1;
                ViewModel.CharacterRef.Charisma += 1;
                await App.Database.SaveCharacterAsync(ViewModel.CharacterRef);
            }
        }

        private async void IntButton_Pressed(object sender, RoutedEventArgs e)
        {
            await displayDialog(ViewModel.viewInt * 5, ViewModel.CharacterRef.UnallocatedPoints, "Intelligence");

            if (result == ContentDialogResult.Primary)
            {
                ViewModel.CharacterRef.UnallocatedPoints -= ViewModel.viewInt * 5;
                ViewModel.viewInt += 1;
                ViewModel.CharacterRef.Intelligence += 1;
                await App.Database.SaveCharacterAsync(ViewModel.CharacterRef);
            }
        }

        private async void DoBattle_Pressed(object sender, RoutedEventArgs e)
        {
            BattleSimulator sim = new BattleSimulator();
            await sim.RandomBattle();
        }
    }
}
