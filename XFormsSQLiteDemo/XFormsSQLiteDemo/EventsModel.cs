using SQLite;
using System;

namespace XFormsSQLiteDemo
{
    public class EventsModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime EventDate { get; set; }
        public bool IsDone { get; set; }
    }
}
