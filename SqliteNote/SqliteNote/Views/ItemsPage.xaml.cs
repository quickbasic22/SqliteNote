using SqliteNote.Models;
using SqliteNote.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
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

        private async void SearchBarControl_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchbar = sender as SearchBar;

            ItemsViewModel itemsviewmodel = searchbar.BindingContext as ItemsViewModel;

            ObservableCollection<Item> TheItems = itemsviewmodel.Items;

            string searchTerm = e.NewTextValue;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                TheItems.Clear();
                foreach (Item item in await App.Database.GetNotesAsync(true))
                {
                    TheItems.Add(item);
                }
            }
            else
            {
                TheItems.Clear();
                var allitems = await App.Database.GetNotesAsync(true);
                var filteredItems = allitems.Where(i => i.Text.ToLower().StartsWith(searchTerm.ToLower()));
                foreach (Item item in filteredItems)
                {
                    TheItems.Add(item);
                }
            }


        }
    }
}