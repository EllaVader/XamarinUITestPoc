using JanineTestApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace JanineTestApp.Views
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