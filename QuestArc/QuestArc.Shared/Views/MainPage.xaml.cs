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
using SQLite;
using QuestArc.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace QuestArc.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Type currentPage;
        public MainPage()
        {
            InitializeComponent();
            currentPage = typeof(HomePage);
            contentView.Navigate(currentPage);
            using (var db = TryCreateDatabase())
            {
                UpdateList(db);
            }
        }

        private static SQLiteConnection TryCreateDatabase()
        {
            // Get an absolute path to the database file
            var databasePath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "MyData.db");

            var exists = File.Exists(databasePath);

            var db = new SQLiteConnection(databasePath);

            if (!exists)
            {
                db.CreateTable<Quest>();
            }

            return db;
        }

        private void UpdateList(SQLiteConnection db)
        {
            //Quests.ItemsSource = db.Table<Quest>().Select(s => s.Title).ToList();
        }

        public static void AddQuest(SQLiteConnection db, string title)
        {
            var quest = new Quest()
            {
                Title = title
            };
            db.Insert(quest);
            Console.WriteLine("{0} == {1}", quest.Title, quest.Id);
        }

        void OnAppBarButtonTapped(object sender, RoutedEventArgs args)
        {
            if (sender is FrameworkElement element)
            {
                var tag = element.Tag.ToString();
                Type page = null;
                topBar.Visibility = Visibility.Collapsed;
                switch (tag)
                {
                    case "Home":
                        topBar.Visibility = Visibility.Visible;
                        page = typeof(HomePage);
                        break;
                    case "Character":
                        page = typeof(CharacterPage);
                        break;
                    case "Inventory":
                        page = typeof(InventoryPage);
                        break;
                    case "Quest Log":
                        page = typeof(QuestLogPage);
                        break;
                    case "Map":
                        page = typeof(MapPage);
                        break;
                }

                if (currentPage != page)
                {
                    currentPage = page;
                    contentView.Navigate(page);
                }
            }
        }
        void OnTopAppBarButtonTapped(object sender, RoutedEventArgs args)
        {
            if (sender is FrameworkElement element)
            {
                var tag = element.Tag.ToString();
                Type page = null;
                switch (tag)
                {
                    case "Month":
                        page = typeof(HomePage);
                        break;
                    case "Week":
                        page = typeof(HomeWeekPage);
                        break;
                    case "Day":
                        page = typeof(HomeDayPage);
                        break;
                }

                if (currentPage != page)
                {
                    currentPage = page;
                    contentView.Navigate(page);
                }
            }
        }
    }
}
