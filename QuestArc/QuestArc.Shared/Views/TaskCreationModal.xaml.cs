﻿using QuestArc.Models;
using SQLite;
using System;
using System.Collections.ObjectModel;
using System.IO;
using Windows.UI.Xaml.Controls;


namespace QuestArc.Views
{
    public sealed partial class TaskCreationModal : ContentDialog
    {
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
        public ObservableCollection<string> Difficulties { get; set; }

        public TaskCreationModal()
        {
            Difficulties = new ObservableCollection<string>();

            this.InitializeComponent();

            Difficulties.Add("Easy");
            Difficulties.Add("Normal");
            Difficulties.Add("Hard");
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Hide();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            // Ensure the user name and password fields aren't empty. If a required field
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
            var quest = new Quest
            {
                Title = titleTextBox.Text,
                StartTime = CombineDateAndTime(startDatePicker.Date.DateTime, startTimePicker.Time),
                EndTime = CombineDateAndTime(endDatePicker.Date.DateTime, endTimePicker.Time),

                Description = descriptionTextBox.Text,
                Difficulty = difficultyPicker.SelectedItem?.ToString(),
                AllDay = (bool)allDayPicker.IsChecked,
                Status = "Todo"
            };
            App.Database.SaveQuestAsync(quest);
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
