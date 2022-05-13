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
            var TheItems = await App.Database.GetNotesAsync(true);
            var items = TheItems.Where(t => t.Text.ToUpper().StartsWith(e.NewTextValue.ToUpper()));

            if (items.Any())
            {
                _viewModel.Items.Clear();
                foreach (var item in items)
                {
                    _viewModel.Items.Add(item);
                }
            }
            else
            {
                _viewModel.Items.Clear();
                _viewModel.Items.Add(new Item() { Text = "No Items" });
            }

            if (e.NewTextValue == "")
            {
                foreach (var item in TheItems)
                {
                    _viewModel.Items.Add(item);
                }
            }
           
            
        }
    }
} 