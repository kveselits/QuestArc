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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.UI;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace QuestArc.Views
{
    public sealed partial class HomePage : Page
    {

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
            return null;
        }

        private async void OnFlyOutButtonClickAsync(object sender, RoutedEventArgs e)
        {
            ContentDialog1 dialog = new ContentDialog1();
            await dialog.ShowAsync();
        }

        private void OnFlyoutCloseButtonClick(object sender, RoutedEventArgs e)
        {
            flyout.Hide();
        }

        private void CalendarView_OnCalendarViewDayItemChanging(
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
            item.PointerPressed += Item_PointerPressed;
        }

        private void Item_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            flyout = (Flyout)this.Resources["flyout"];
            flyout.ShowAt(element);
        }
    }
}