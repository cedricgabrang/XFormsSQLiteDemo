using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFormsSQLiteDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EventsListPage : ContentPage
	{
        private int _selectedItemIndex;

		public EventsListPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadItems();
        }

        private void LoadItems()
        {
            var eventsData = new EventsData();
            var result = eventsData.GetItemsList().Result;
            listViewEvent.ItemsSource = result;
            stackActionButtons.IsEnabled = false;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            AddEventsPage._isUpdate = false;
            Navigation.PushAsync(new AddEventsPage());
        }

        private void ListViewEvent_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = (EventsModel)e.Item;
            _selectedItemIndex = selectedItem.Id;
            AddEventsPage._eventsId = _selectedItemIndex;
            stackActionButtons.IsEnabled = true;
            
        }

        private void btnEdit_Clicked(object sender, EventArgs e)
        {
            AddEventsPage._isUpdate = true;
            Navigation.PushAsync(new AddEventsPage());
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
           
            var action = await DisplayAlert("Confirm", "Delete this item?", "Yes", "No");
            if (action)
            {
                var eventsData = new EventsData();
                await eventsData.DeleteItem(_selectedItemIndex);
                LoadItems();
            }

        }
    }
}