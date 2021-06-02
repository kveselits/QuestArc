
using System.Data.SQLite;
using QuestArc.Helpers;
using QuestArc.Models;
using QuestArc.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace QuestArc.Views
{
    public sealed partial class InventoryPage : Page
    {
        public InventoryViewModel ViewModel { get; set; } = new InventoryViewModel();

        public InventoryPage()
        {
            this.InitializeComponent();
        }

        public async void EquipItem(object sender, RoutedEventArgs e)
        {
            String errorMessage = "Unable to equip item, insufficient values:";
            Boolean isOpen = false;

            if (ViewModel.Db.CurrentCharacter.Strength < ViewModel.SelectedItem.Strength)
            {
                int value = ViewModel.SelectedItem.Strength - ViewModel.Db.CurrentCharacter.Strength;
                errorMessage += "\n Strength must be increased " + value + " levels.";

                isOpen = true;
            }
            if (ViewModel.Db.CurrentCharacter.Stamina < ViewModel.SelectedItem.Stamina)
            {
                int value = ViewModel.SelectedItem.Stamina - ViewModel.Db.CurrentCharacter.Stamina;
                errorMessage += "\n Stamina must be increased " + value + " levels.";

                isOpen = true;
            }
            if (ViewModel.Db.CurrentCharacter.Constitution < ViewModel.SelectedItem.Constitution)
            {
                int value = ViewModel.SelectedItem.Constitution - ViewModel.Db.CurrentCharacter.Constitution;
                errorMessage += "\n Constitution must be increased " + value + " levels.";
                isOpen = true;
            }
            if (ViewModel.Db.CurrentCharacter.Dexterity < ViewModel.SelectedItem.Dexterity)
            {
                int value = ViewModel.SelectedItem.Dexterity - ViewModel.Db.CurrentCharacter.Dexterity;
                errorMessage += "\n Dexterity must be increased " + value + " levels.";
                isOpen = true;
            }
            if (ViewModel.Db.CurrentCharacter.Wisdom < ViewModel.SelectedItem.Wisdom)
            {
                int value = ViewModel.SelectedItem.Wisdom - ViewModel.Db.CurrentCharacter.Wisdom;
                errorMessage += "\n Wisdom must be increased " + value + " levels.";
                isOpen = true;
            }
            if (ViewModel.Db.CurrentCharacter.Intelligence < ViewModel.SelectedItem.Intelligence)
            {
                int value = ViewModel.SelectedItem.Intelligence - ViewModel.Db.CurrentCharacter.Intelligence;
                errorMessage += "\n Intelligence must be increased " + value + " levels.";
                isOpen = true;
            }
            if (ViewModel.Db.CurrentCharacter.Charisma < ViewModel.SelectedItem.Charisma)
            {
                int value = ViewModel.SelectedItem.Charisma - ViewModel.Db.CurrentCharacter.Charisma;
                errorMessage += "\n Charisma must be increased " + value + " levels.";
                isOpen = true;
            }

            if (isOpen)
            {
                ContentDialog errorDialog = new ContentDialog()
                {
                    Title = "Insufficient Stats",
                    Content = errorMessage,
                    CloseButtonText = "Ok"
                };

                await errorDialog.ShowAsync();
            }
            else
            {
                
                Item newItem = (Item)(sender as FrameworkElement).DataContext;

                string sqlQuery = "";

                if (ViewModel.SelectedItem.Type == Models.ItemType.WEAPON)
                {
                    sqlQuery = "SELECT Id, Title FROM Item WHERE Equipped = true AND Type = 0";
                }

                if (ViewModel.SelectedItem.Type == Models.ItemType.ARMOR)
                {
                    sqlQuery = "SELECT Id, Title FROM Item WHERE Equipped = true AND Type = 2";
                }

                if (ViewModel.SelectedItem.Type == Models.ItemType.POTION)
                {
                    sqlQuery = "SELECT Id, Title FROM Item WHERE Equipped = true AND Type = 1";
                }

                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "QuestArc.db3");
                using (var dbConnection = new System.Data.SQLite.SQLiteConnection("Data Source = " + path))
                {
                    using (var dbcmd = new System.Data.SQLite.SQLiteCommand())
                    {
                        dbConnection.Open();
                        dbcmd.Connection = dbConnection;

                        dbcmd.CommandText = sqlQuery;
                        IDataReader reader = dbcmd.ExecuteReader();

                        string equippedId = null;
                        string title = "";

                        while (reader.Read())
                        {
                            equippedId = reader["Id"].ToString();
                            title = reader["Title"].ToString();
                        }

                        reader.Close();

                        if (!newItem.Title.Equals(title))
                        {
                            if (equippedId != null)
                            {
                                dbcmd.Parameters.AddWithValue("@id", equippedId);
                                int end = title.IndexOf("-");
                                dbcmd.Parameters.AddWithValue("@title", title.Substring(0, end));
                                dbcmd.CommandText = @"UPDATE Item SET Equipped = false WHERE Id = @id";
                                dbcmd.ExecuteNonQuery();
                                dbcmd.CommandText = @"UPDATE Item SET Title = @title WHERE Id = @Id";
                                dbcmd.ExecuteNonQuery();
                            }

                            title = newItem.Title + "- Equipped";
                            dbcmd.Parameters.AddWithValue("@description", newItem.Description);
                            dbcmd.Parameters.AddWithValue("@title", title);
                            dbcmd.CommandText = @"UPDATE Item SET Equipped = true WHERE Description = @description";
                            dbcmd.ExecuteNonQuery();
                            dbcmd.CommandText = @"UPDATE Item SET Title = @title WHERE Description = @description";
                            dbcmd.ExecuteNonQuery();
                        }
                        dbConnection.Close();
                    }
                    ViewModel.UpdateView();
                    this.Bindings.Update();
                }
            }
        }
    }
}
