using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFormsSQLiteDemo
{

    public class EventsData
    {
        SQLiteAsyncConnection _connection;

        public EventsData()
        {
            _connection = DependencyService.Get<ISQLite>().SQLiteConnection();
            _connection.CreateTableAsync<EventsModel>();
        }

        public Task<List<EventsModel>> GetItemsList()
        {
            return _connection.QueryAsync<EventsModel>("SELECT * FROM EventsModel ORDER BY EventDate DESC");
        }

        public Task<List<EventsModel>> GetItemDetails(int id)
        {
            return _connection.QueryAsync<EventsModel>("SELECT * FROM EventsModel WHERE Id=?",id);
        }

        public Task<int> AddItems(EventsModel eventsModel)
        {
            var eventDetails = GetItemDetails(eventsModel.Id).Result;

            if(eventDetails.Count == 0)
            {
                return _connection.InsertAsync(eventsModel);
            }

            else
            {
                eventsModel.Id = eventDetails[0].Id;
                return _connection.UpdateAsync(eventsModel);
            }
        }

        public Task DeleteItem(int id)
        {
            return _connection.QueryAsync<EventsModel>("DELETE FROM EventsModel WHERE Id=?", id);
        }
    }
}
