using System;
using Windows.UI.Xaml;
using QuestArc.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

using Windows.UI.Xaml.Navigation;
using System.Collections.Generic;
using System.Collections;
using Windows.UI;
using System.IO;
using System.Data;
using Microsoft.Data.Sqlite;
using QuestArc.Models;

namespace QuestArc.Views
{
    // For more info about the TreeView Control see
    // https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/tree-view
    // For other samples, get the XAML Controls Gallery app http://aka.ms/XamlControlsGallery
    public sealed partial class HomePage : Page
    {
        public HomeViewModel ViewModel { get; } = new HomeViewModel();

        public Dictionary<string, ArrayList> dateMap = new Dictionary<string, ArrayList>();
        string newDate;
        int year = DateTime.Now.Date.Year;
        int month = DateTime.Now.Date.Month;
        int day = DateTime.Now.Date.Day;

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
            dialog.StartDate.Date = new DateTime(year, month, day);
            dialog.EndDate.Date = new DateTime(year, month, day);

            await dialog.ShowAsync();
        }

        private async void NonCalendarOnFlyOutButtonClickAsync(object sender, RoutedEventArgs e)
        {
            TaskCreationModal dialog = new TaskCreationModal();

            await dialog.ShowAsync();
        }

        private void OnGoToDayButtonClickAsync(object sender, RoutedEventArgs e)
        {
            flyout.Hide();
            DateTime endTime = new DateTime(year, month, day);
            App.Database.SaveQuestsAsync(App.Database.GetQuestsOnDateAsync(endTime));
            ViewModel.Db.CurrentCharacter.TempQuests = App.Database.GetQuestsOnDateAsync(endTime);
            string shortString = endTime.ToShortDateString();
            ViewModel.SelectedDay = shortString;
            Items.SelectedItem = DayPivot;
            this.Bindings.Update();
        }

        private async void OnEditButtonClickAsync(object sender, RoutedEventArgs e)
        {
            var id = ((Button)sender).Tag;
            TaskEditModal dialog = new TaskEditModal((int)id);
            await dialog.ShowAsync();
        }

        private async void OnDeleteButtonClickAsync(object sender, RoutedEventArgs e)
        {
            var id = ((Button)sender).Tag;
            TaskDeleteModal dialog = new TaskDeleteModal((int)id);
            await dialog.ShowAsync();
        }

        private async void OnCompleteButtonClickAsync(object sender, RoutedEventArgs e)
        {
            Quest quest = (Quest)(sender as FrameworkElement).DataContext;

            if (!quest.Status.Equals("Complete"))
            {
                string sqlQuery = "SELECT * FROM Character WHERE Id = " + quest.CharacterId;

                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "QuestArc.db3");
                using (var dbConnection = new System.Data.SQLite.SQLiteConnection("Data Source = " + path))
                {
                    using (var dbcmd = new System.Data.SQLite.SQLiteCommand())
                    {
                        dbConnection.Open();
                        dbcmd.Connection = dbConnection;

                        dbcmd.CommandText = sqlQuery;
                        IDataReader reader = dbcmd.ExecuteReader();

                        string characterId = null;
                        int points = 0;

                        while (reader.Read())
                        {
                            characterId = reader["Id"].ToString();
                            points = (int)(long)reader["UnallocatedPoints"];
                        }

                        reader.Close();

                        string difficulty = quest.Difficulty;
                        int numPoints = 0;

                        switch (difficulty)
                        {
                            case "Easy":
                                numPoints = 10 + points;
                                break;
                            case "Normal":
                                numPoints = 20 + points;
                                break;
                            case "Hard":
                                numPoints = 30 + points;
                                break;
                        }

                        dbcmd.Parameters.AddWithValue("@id", quest.Id);
                        dbcmd.Parameters.AddWithValue("@status", "Complete");
                        dbcmd.CommandText = @"UPDATE Quest SET Status = @status WHERE Id = @id";
                        dbcmd.ExecuteNonQuery();

                        dbcmd.Parameters.AddWithValue("@id", characterId);
                        dbcmd.Parameters.AddWithValue("@points", numPoints);
                        dbcmd.CommandText = @"UPDATE Character SET UnallocatedPoints = @points WHERE Id = @id";
                        dbcmd.ExecuteNonQuery();
                        dbConnection.Close();
                    }
                    this.Bindings.Update();
                }

                ContentDialog dialog = new ContentDialog();
                dialog.Title = "Quest Complete!";
                dialog.CloseButtonText = "Ok";
                await dialog.ShowAsync();

            } else
            {
                ContentDialog dialog = new ContentDialog();
                dialog.Title = "Quest is already Complete";
                dialog.CloseButtonText = "Ok";
                await dialog.ShowAsync();
            }
        }

        private void OnFlyoutCloseButtonClick(object sender, RoutedEventArgs e)
        {
            flyout.Hide();
        }

        private async void CalendarView_OnCalendarViewDayItemChanging(
            CalendarView sender,
            CalendarViewDayItemChangingEventArgs args)
        {
            int count = 0;
            var textBlock = FindFirstChildOfType<TextBlock>(args.Item);
            if (textBlock != null)
            {
                textBlock.HorizontalAlignment = HorizontalAlignment.Left;
                textBlock.VerticalAlignment = VerticalAlignment.Top;
            }

            var item = args.Item;

            List<string> columnData = new List<string>();

            string[] dates = args.Item.Date.ToString().Split('/', ' ');
            if (dates[0].Length == 1)
            {
                dates[0] = "0" + dates[0];
            }

            if (dates[1].Length == 1)
            {
                dates[1] = "0" + dates[1];
            }

            newDate = dates[2] + "-" + dates[0] + "-" + dates[1];

            string sqlQuery = "SELECT Title, StartTime, Status, Difficulty FROM Quest WHERE StartTime LIKE '%" + newDate + "%'";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "QuestArc.db3");
            using (var dbConnection = (IDbConnection)new SqliteConnection("Data Source = " + path))
            {
                using (var dbcmd = dbConnection.CreateCommand())
                {
                    dbConnection.Open();

                    dbcmd.CommandText = sqlQuery;
                    IDataReader reader = dbcmd.ExecuteReader();

                    if (dateMap.ContainsKey(newDate))
                    {
                        dateMap[newDate][0] = "";
                    }

                    //Read first result set
                    while (reader.Read())
                    {
                        string title = reader["Title"].ToString();
                        string startTime = reader["StartTime"].ToString().Split('T', '.')[1];
                        string status = reader["Status"].ToString();
                        string difficulty = reader["Difficulty"].ToString();

                        if (!dateMap.ContainsKey(newDate))
                        {
                            dateMap.Add(newDate, new ArrayList() { title + "\n  " + startTime + "\n  " + status, difficulty });
                            count++;
                        }
                        else
                        {
                            if (!title.Equals(null) || !title.Equals(""))
                            {
                                dateMap[newDate][0] += ("\n" + title + "\n  " + startTime + "\n  " + status);
                                count++;
                            }
                        }
                    }

                    List<Color> densityColors = new List<Color>();
                    foreach (string date in dateMap.Keys)
                    {

                        if (date.Contains(newDate))
                        {
                            for (int i = 0; i < count; i++)
                            {
                                densityColors.Add(Colors.Red);
                            }
                        }
                    }
                    args.Item.SetDensityColors(densityColors);
                }
            }
            item.PointerPressed += Item_PointerPressed;
        }

        private void Item_PointerPressed(Object sender, PointerRoutedEventArgs e)
        {
            Item_PointerPressedHelper((CalendarViewDayItem)sender, e);
        }

        private void Item_PointerPressedHelper(CalendarViewDayItem sender, PointerRoutedEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            flyout = (Flyout)this.Resources["flyout"];

            string[] dates = sender.Date.ToString().Split('/', ' ');
            if (dates[1].Length == 1)
            {
                dates[1] = "0" + dates[1];
            }
            if (dates[0].Length == 1)
            {
                dates[0] = "0" + dates[0];
            }
            string date = dates[2] + "-" + dates[0] + "-" + dates[1];

            year = int.Parse(dates[2]);
            month = int.Parse(dates[0]);
            day = int.Parse(dates[1]);

            if (dateMap.ContainsKey(date))
            {
                flyoutText.Text = (string)dateMap[date][0];
                GoToDayButton.Visibility = Visibility.Visible;
            }
            else
            {
                flyoutText.Text = "No Quests Today";
                GoToDayButton.Visibility = Visibility.Collapsed;
            }
            flyout.ShowAt(element);
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }
    }
}
