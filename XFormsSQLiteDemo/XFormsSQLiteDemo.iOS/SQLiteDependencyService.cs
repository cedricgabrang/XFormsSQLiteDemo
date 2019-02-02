using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using XFormsSQLiteDemo.iOS;

[assembly: Dependency(typeof(SQLiteDependencyService))]
namespace XFormsSQLiteDemo.iOS
{
    public class SQLiteDependencyService : ISQLite
    {
        public SQLiteAsyncConnection SQLiteConnection()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");
            return new SQLiteAsyncConnection(Path.Combine(libraryPath, "SQLiteDemo .db3"), false);
        }
    }
}