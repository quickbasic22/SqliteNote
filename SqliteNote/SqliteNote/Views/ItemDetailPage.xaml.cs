using SqliteNote.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SqliteNote.Views
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