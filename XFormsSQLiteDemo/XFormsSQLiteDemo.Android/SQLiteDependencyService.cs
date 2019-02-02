using System.IO;
using SQLite;
using Xamarin.Forms;
using XFormsSQLiteDemo.Droid;

[assembly: Dependency(typeof(SQLiteDependencyService))]
namespace XFormsSQLiteDemo.Droid
{
    public class SQLiteDependencyService : ISQLite
    {
        public SQLiteAsyncConnection SQLiteConnection()
        {
            string path = System.Environment.
                GetFolderPath(System.Environment.SpecialFolder.Personal);
            return new SQLiteAsyncConnection(Path.Combine(path, "SQLiteDemo .db3"), false);
        }
    }
}