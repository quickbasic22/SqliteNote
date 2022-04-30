using SqliteNote.Models;
using SqliteNote.ViewModels;
using SqliteNote.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            
            _viewModel.Items.Remove(item);
        }
    }
}