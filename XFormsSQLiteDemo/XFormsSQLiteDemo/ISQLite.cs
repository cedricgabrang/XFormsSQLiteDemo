using SQLite;

namespace XFormsSQLiteDemo
{
    public interface ISQLite
    {
        SQLiteAsyncConnection SQLiteConnection();
    }
}
