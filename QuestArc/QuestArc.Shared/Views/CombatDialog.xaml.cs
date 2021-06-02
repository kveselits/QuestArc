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

        public CombatDialog()
        {
            this.InitializeComponent();
            this.DataContext = ViewModel;
            
            //ObservableCollection<Item> _viewItems = SimCharacter.Items;
            Item EquippedItem = (Item)_viewItems.Where(e => e.Equipped);
            int _viewCharWeapDamage = EquippedItem.BaseDamage; 
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
