using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using QuestArc.Models;
using System.Collections.ObjectModel;
using QuestArc.ViewModels;
using System.Threading.Tasks;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace QuestArc.Views
{
    public sealed partial class CombatDialog : ContentDialog
    {
        CharacterViewModel ViewModel = new CharacterViewModel();
       

        public CombatDialog()
        {
            this.InitializeComponent();
            this.DataContext = ViewModel;
        }

        ContentDialog PlayerWins = new ContentDialog()
        {
            Title = "You won!",
            CloseButtonText = "Ok"
        };

        ContentDialog MonsterWins = new ContentDialog()
        {
            Title = "You lost!",
            CloseButtonText = "Ok"
        };


        private async void UseWeapon_Click(object sender, RoutedEventArgs e)
        {
            if(ViewModel.viewCurrentHealth > 0 && ViewModel.viewMonsterCurrentHealth > 0)
            {
                // Monster curr hp = monster curr hp - Player damage
                ViewModel.viewMonsterCurrentHealth = ViewModel.viewMonsterCurrentHealth - ViewModel.viewBaseDamage;

                await Task.Delay(300);

                // Player curr hp = player curr hp - Monster damage
                ViewModel.viewCurrentHealth = ViewModel.viewCurrentHealth - ViewModel.viewMonsterDamage;

                if(ViewModel.viewCurrentHealth <= 0)
                {
                    this.Hide();
                    await PlayerWins.ShowAsync();
                }

                if(ViewModel.viewMonsterCurrentHealth <= 0)
                {
                    this.Hide();
                    await MonsterWins.ShowAsync();
                }
            }

        }

        private void Inventory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Flee_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            // Testing 1 2 3
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
