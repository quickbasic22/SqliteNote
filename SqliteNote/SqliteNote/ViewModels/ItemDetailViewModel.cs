using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace SqliteNote.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private int itemId;
        private int id;
        private Models.Item item;
        private string text;
        private DateTime? date;
        private string description;
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public ItemDetailViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
        }

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public DateTime? Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public Models.Item Item
        {
            get => item;
            set => SetProperty(ref item, value);
        }

        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await App.Database.GetNoteAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Date = item.Date;
                Description = item.Description;
                Item = item;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item.Description = Description;
            Item.Text = Text;
            Item.Date = (DateTime)Date;

           var note = await App.Database.SaveNoteAsync(Item);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
