using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace QuestArc.Views
{
    public sealed partial class TaskEditModal : ContentDialog
    {
        private int _id;

        public String TaskTitle
        {
            get { return TaskTitle; }
            set { TaskTitle = value; }
        }
        public String Description
        {
            get { return Description; }
            set { Description = value; }
        }

        public ObservableCollection<string> Difficulties { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Statuses { get; set; } = new ObservableCollection<string>();
        public Quest Quest { get; private set; }

        public TaskEditModal()
        {
            Difficulties.Add("Easy");
            Difficulties.Add("Normal");
            Difficulties.Add("Hard");
            Statuses.Add("Todo");
            Statuses.Add("In Progress");
            Statuses.Add("Complete");
            this.InitializeComponent();
        }

        public TaskEditModal(int id)
        {
            Difficulties.Add("Easy");
            Difficulties.Add("Normal");
            Difficulties.Add("Hard");
            Statuses.Add("Todo");
            Statuses.Add("In Progress");
            Statuses.Add("Complete");
            this.InitializeComponent();
            this._id = id;
            Quest = App.Database.GetQuestAsync(this._id);
        }

        private void TaskEditModal_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Hide();
        }

        private void TaskEditModal_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            
            // Ensure the user title and description fields aren't empty. If a required field
            // is empty, set args.Cancel = true to keep the dialog open.
            if (string.IsNullOrEmpty(titleTextBox.Text))
            {
                args.Cancel = true;
                errorTextBlock.Text = "Title is required.";
            }
            else if (string.IsNullOrEmpty(descriptionTextBox.Text))
            {
                args.Cancel = true;
                errorTextBlock.Text = "Description is required.";
            }
            
            Quest.Title = titleTextBox.Text;
            Quest.StartTime = CombineDateAndTime(startDatePicker.Date.DateTime, startTimePicker.Time);
            Quest.EndTime = CombineDateAndTime(endDatePicker.Date.DateTime, endTimePicker.Time);
            Quest.Description = descriptionTextBox.Text;
            Quest.Difficulty = difficultyPicker.SelectedItem?.ToString();
            Quest.Status = statusPicker.SelectedItem?.ToString();
            Quest.AllDay = (bool)allDayPicker.IsChecked;
            

            App.Database.SaveQuestAsync(Quest, App.Database.GetArcAsync(1).Result);
        }

        private static DateTime CombineDateAndTime(DateTime dateObj, TimeSpan timeObj)
        {
            //get timespan from the date object
            TimeSpan spanInDate = dateObj.TimeOfDay;

            //subtract it to set date objects time to 0:00
            dateObj = dateObj.Subtract(spanInDate);

            //now add your newTime to date object
            var newDateTime = dateObj.Add(timeObj);

            //return new value
            return newDateTime;
        }
    }
}
