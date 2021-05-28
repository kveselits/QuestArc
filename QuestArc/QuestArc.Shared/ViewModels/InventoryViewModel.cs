using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Input;
using Microsoft.Data.Sqlite;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using QuestArc.Models;
using QuestArc.Services;
using WinUI = Microsoft.UI.Xaml.Controls;

namespace QuestArc.ViewModels
{
    public class InventoryViewModel : ObservableObject
    {
        private ICommand _itemInvokedCommand;
        private Item _selectedItem;
        private List<Item> _weaponList;
        private List<Item> _armorList;
        private List<Item> _potionList;

        public Item SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        public List<Item> WeaponList
        {
            get => _weaponList;
            set => SetProperty(ref _weaponList, value);
        }

        public List<Item> ArmorList
        {
            get => _armorList;
            set => SetProperty(ref _armorList, value);
        }

        public List<Item> PotionList
        {
            get => _potionList;
            set => SetProperty(ref _potionList, value);
        }

        public SQLiteDatabase Db = App.Database;

        public ICommand ItemInvokedCommand => _itemInvokedCommand ?? (_itemInvokedCommand = new RelayCommand<WinUI.TreeViewItemInvokedEventArgs>(OnItemInvoked));

        public InventoryViewModel()
        {
            UpdateView();
        }

        public void UpdateView()
        {
            List<Item> weapons = new List<Item>();
            List<Item> armor = new List<Item>();
            List<Item> potions = new List<Item>();

            string sqlQuery = "SELECT * FROM Item";

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "QuestArc.db3");
            using (var dbConnection = (IDbConnection)new SqliteConnection("Data Source = " + path))
            {
                using (var dbcmd = dbConnection.CreateCommand())
                {
                    dbConnection.Open();

                    dbcmd.CommandText = sqlQuery;
                    IDataReader reader = dbcmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Item item = new Item(reader["Title"].ToString(), reader["Description"].ToString(), (int)(long)reader["ItemLevel"],
                            (int)(long)reader["BaseDamage"], (int)(long)reader["Health"], (int)(long)reader["Mana"], (int)(long)reader["Strength"],
                            (int)(long)reader["Stamina"], (int)(long)reader["Constitution"], (int)(long)reader["Dexterity"], (int)(long)reader["Wisdom"],
                            (int)(long)reader["Intelligence"], (int)(long)reader["Charisma"], (ItemType)(int)(long)reader["Type"]);

                        if (App.Database.CurrentCharacter.Id == (int)(long)reader["CharacterId"])
                        {

                            if (item.Type == ItemType.WEAPON)
                            {
                                weapons.Add(item);
                            }

                            if (item.Type == ItemType.ARMOR)
                            {
                                armor.Add(item);
                            }

                            if (item.Type == ItemType.POTION)
                            {
                                potions.Add(item);
                            }
                        }
                    }
                }
                dbConnection.Close();
            }

            this.WeaponList = weapons;
            this.ArmorList = armor;
            this.PotionList = potions;
        }


        private void OnItemInvoked(WinUI.TreeViewItemInvokedEventArgs args)
            => SelectedItem = (Item)args.InvokedItem;
    }
}
