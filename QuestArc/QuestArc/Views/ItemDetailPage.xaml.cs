using QuestArc.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace QuestArc.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}