using SqliteNote.ViewModels;
using System;
using Xamarin.Forms;

namespace SqliteNote.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var swipeItem = (SwipeItem)sender;
            var item = swipeItem.BindingContext as Models.Item;

            App.Database.DeleteNoteAsync(item);
            _viewModel.Items.Remove(item);
        }
    }
}