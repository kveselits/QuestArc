using System;
using Windows.UI.Xaml;
using QuestArc.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using System.Threading.Tasks;

using Windows.UI.Xaml.Navigation;
using System.Collections.Generic;
using Windows.UI;
using QuestArc.Models;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using Microsoft.Data.Sqlite;
using QuestArc.Services;

namespace QuestArc.Views
{
    // For more info about the TreeView Control see
    // https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/tree-view
    // For other samples, get the XAML Controls Gallery app http://aka.ms/XamlControlsGallery
    public sealed partial class HomePage : Page
    {
        public HomeViewModel ViewModel { get; } = new HomeViewModel();
        public List<string> Title = new List<string>{"There are no Quests today" };
        public string Title1 { get; set; } = "There are no quest today";

        Flyout flyout;
        

        public HomePage()
        {
            InitializeComponent();
        }

        private T FindFirstChildOfType<T>(DependencyObject control) where T : DependencyObject
        {
            var childrenCount = VisualTreeHelper.GetChildrenCount(control);
            for (int childIndex = 0; childIndex < childrenCount; childIndex++)
            {
                var child = VisualTreeHelper.GetChild(control, childIndex);
                if (child is T typedChild)
                {
                    return typedChild;
                }
            }
            return default(T);
        }

        private async void OnFlyOutButtonClickAsync(object sender, RoutedEventArgs e)
        {
            TaskCreationModal dialog = new TaskCreationModal();
            await dialog.ShowAsync();
        }

        private async void OnEditButtonClickAsync(object sender, RoutedEventArgs e)
        {
            var id = ((Button)sender).Tag;
            TaskEditModal dialog = new TaskEditModal((int)id);
            await dialog.ShowAsync();
        }

        private void OnFlyoutCloseButtonClick(object sender, RoutedEventArgs e)
        {
            flyout.Hide();
        }

        private async void CalendarView_OnCalendarViewDayItemChanging(
            CalendarView sender,
            CalendarViewDayItemChangingEventArgs args)
        {
            var textBlock = FindFirstChildOfType<TextBlock>(args.Item);
            if (textBlock != null)
            {
                textBlock.HorizontalAlignment = HorizontalAlignment.Left;
                textBlock.VerticalAlignment = VerticalAlignment.Top;
            }

            var item = args.Item;
            
            List<string> columnData = new List<string>();

            string sqlQuery = "SELECT StartTime FROM Quest";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "QuestArc.db3");
            using (var dbConnection = (IDbConnection)new SqliteConnection("Data Source = " + path))
            {
                using (var dbcmd = dbConnection.CreateCommand())
                {
                    dbConnection.Open();

                    dbcmd.CommandText = sqlQuery;
                    IDataReader reader = dbcmd.ExecuteReader();

                    //Read first result set
                    while (reader.Read())
                    {
                        columnData.Add(reader["StartTime"].ToString());
                        Title.Add(reader["StartTime"].ToString());
                    }

                }

                foreach (string quest in columnData)
                {
                    string[] dates = args.Item.Date.ToString().Split('/', ' ');
                    if(dates[0].Length == 1)
                    {
                        dates[0] = "0" + dates[0];
                    }

                    if(dates[1].Length == 1)
                    {
                        dates[1] = "0" + dates[1];
                    }

                    string newDate = dates[2] + "-" + dates[0] + "-" + dates[1];
                    if (quest.Contains(newDate))
                    {
                        Title1 = newDate; //string.Join(", ", ((List<string>)Title).ToArray());

                        List<Color> densityColors = new List<Color>
                        {
                            Colors.Red
                        };
                        args.Item.SetDensityColors(densityColors);
                        // Render basic day items.
                        if (args.Phase == 0)
                        {
                            // Register callback for next phase.
                            args.Item.DataContext = newDate;
                        }

                    }
                }
            }
            item.PointerPressed += Item_PointerPressed;
        }

            private void Item_PointerPressed(object sender, PointerRoutedEventArgs e)
            {
                FrameworkElement element = sender as FrameworkElement;
                flyout = (Flyout)this.Resources["flyout"];
                flyoutText.Text = Title1;
                flyout.ShowAt(element);
            }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }
    }
}
