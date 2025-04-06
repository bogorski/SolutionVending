using System.ComponentModel;
using Xamarin.Forms;
using AppMobileVending.ViewModels;

namespace AppMobileVending.Views
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