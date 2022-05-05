using SqliteNote.Models;
using SqliteNote.ViewModels;
using System;
using System.Collections.ObjectModel;
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

        private void SearchButton_Clicked(object sender, EventArgs e)
        {
            var collectionview = (CollectionView)sender;

            var item = collectionview.ItemsSource as ObservableCollection<Item>;

            

        }
    }
}