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
