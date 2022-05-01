using SqliteNote.Models;
using SqliteNote.ViewModels;
using Xamarin.Forms;

namespace SqliteNote.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}