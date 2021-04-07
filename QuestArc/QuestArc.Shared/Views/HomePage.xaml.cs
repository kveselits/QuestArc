using System;
using Windows.UI.Xaml;
using QuestArc.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;


using Windows.UI.Xaml.Navigation;
using QuestArc.Models;

namespace QuestArc.Views
{
    // For more info about the TreeView Control see
    // https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/tree-view
    // For other samples, get the XAML Controls Gallery app http://aka.ms/XamlControlsGallery
    public sealed partial class HomePage : Page
    {
        public HomeViewModel ViewModel { get; } = new HomeViewModel();

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

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }
    }
}
