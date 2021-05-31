using QuestArc.Models;
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

namespace QuestArc.Views
{
    public sealed partial class TaskDeleteModal : ContentDialog
    {
        public int Id { get; }
        public Quest Quest { get; }

        public TaskDeleteModal()
        {
            this.InitializeComponent();
        }
        public TaskDeleteModal(int id)
        {
            this.InitializeComponent();
            Id = id;
            if (id != 0)
            {
                var result = App.Database.GetQuestAsync(this.Id);
                if (result != null)
                {
                    Quest = result.Result;
                }
            }

        }



        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (Quest != null)
            {
                App.Database.DeleteQuestAsync(Quest);
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Hide();
        }
    }
}
