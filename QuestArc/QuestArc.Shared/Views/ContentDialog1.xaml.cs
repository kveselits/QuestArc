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
    public sealed partial class ContentDialog1 : ContentDialog
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
        public ContentDialog1()
        {
            this.InitializeComponent();
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
                errorTextBlock.Text = "User name is required.";
            }
            else if (string.IsNullOrEmpty(passwordTextBox.Text))
            {
                args.Cancel = true;
                errorTextBlock.Text = "Password is required.";
            }
        }
    }
}
