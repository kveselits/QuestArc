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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace QuestArc.Views
{
    public sealed partial class CombatDialog : ContentDialog
    {
        CharacterViewModel ViewModel = new CharacterViewModel();
        string MonsterName = "Goblin";
        int MonsterMaxHealth = 100;
        int MonsterCurrHealth = 100;
        int MonsterDamage = 8;

        public CombatDialog()
        {
            this.InitializeComponent();
            this.DataContext = ViewModel;
        }

        private void UseWeapon_Click(object sender, RoutedEventArgs e)
        {
            MonsterCurrHealth = MonsterCurrHealth - ViewModel.CharacterRef.BaseDamage;
        }

        private void Inventory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Flee_Click(object sender, RoutedEventArgs e)
        {
            
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
