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
	public partial class AddEventsPage : ContentPage
	{

        public static bool _isUpdate;
        public static int _eventsId;

		public AddEventsPage ()
		{
			InitializeComponent ();

            if (_isUpdate)
            {
                LoadEventsDetails();
            }

		}

        private void AddEvent()
        {
            var eventsModel = new EventsModel
            {
                Id = _eventsId,
                Title = entryTitle.Text,
                EventDate = dpEventDate.Date + tpEventTime.Time,
                Location = entryLocation.Text,
                IsDone = switchDone.IsToggled
            };

            var eventsData = new EventsData();
            eventsData.AddItems(eventsModel);

            if (_isUpdate)
            {
                DisplayAlert("Event", "Successfully updated!", "OK");
            }

            else
            {
                DisplayAlert("Event", "Successfully created!", "OK");
            }

            Navigation.PopAsync();
            
        }

        private void EditEvent()
        {
            var eventsModel = new EventsModel
            {
                Title = entryTitle.Text,
                EventDate = dpEventDate.Date + tpEventTime.Time,
                Location = entryLocation.Text,
                IsDone = switchDone.IsToggled
            };

            var eventsData = new EventsData();
            eventsData.AddItems(eventsModel);
            DisplayAlert("Event", "Successfull updated!", "OK");
            Navigation.PopAsync();

        }

        private void LoadEventsDetails()
        {
            var eventsData = new EventsData();
            var eventDetails = eventsData.GetItemDetails(_eventsId).Result;

            foreach(var items in eventDetails)
            {
                entryTitle.Text = items.Title;
                dpEventDate.Date = items.EventDate.Date;
                tpEventTime.Time = items.EventDate.TimeOfDay;
                entryLocation.Text = items.Location;
                switchDone.IsToggled = items.IsDone;
            }

        }

        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            AddEvent();
        }
    }
}