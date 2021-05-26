using System;
using QuestArc.ViewModels;

using Windows.UI.Xaml.Controls;
using QuestArc.Models;
using Windows.UI.Xaml;
using System.Linq;
using System.Threading.Tasks;

namespace QuestArc.Views
{
    public sealed partial class CharacterPage : Page
    {
        public CharacterViewModel ViewModel { get; } = new CharacterViewModel();

        public CharacterPage()
        {
            InitializeComponent();
            DataContext = ViewModel;

            // When CharacterPage is drawn immediately start a new Character prompt.
            // [Done] Will need to check if it's been done before so as not to create new characters everytime.
            Character currentCharacter = App.Database.CurrentCharacter;

            if (!currentCharacter.Initialized)
            {
                NewCharacterInit();
            }
        }

        private async void NewCharacterInit()
        {
            CharacterCreationDialog NewCharDialog = new CharacterCreationDialog(ViewModel);
            await NewCharDialog.ShowAsync();
        }

        private async void DoBattle_Pressed(object sender, RoutedEventArgs e)
        {
            BattleSimulator sim = new BattleSimulator();
            await sim.RandomBattle();
        }

        private async void LevelUpButton_Pressed(object sender, RoutedEventArgs e)
        {
            CharacterCreationDialog dialog = new CharacterCreationDialog(ViewModel);

            await dialog.ShowAsync();
        }
    }
}
