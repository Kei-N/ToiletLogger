using SQLite;

namespace ToiletLogger.Data;

public class SQLiteDatabase
{
    private SQLiteAsyncConnection Database;

    public SQLiteDatabase()
    {
    }

    private async Task Init()
    {
        if (Database is not null)
            return;

        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        await Database.CreateTableAsync<User>();
        await Database.CreateTableAsync<ToiletLog>();
    }

    public async Task<List<User>> GetUsersAsync()
    {
        await Init();
        return await Database.Table<User>().ToListAsync();
    }

    public async Task<List<ToiletLog>> GetToiletLogsAsync(Guid userId)
    {
        await Init();
        return await Database.Table<ToiletLog>().Where(i => i.UserId == userId)?.OrderByDescending(x => x.Date).ToListAsync();
    }

    public async Task SaveItemAsync<T>(T item)
    {
        await Init();
        await Database.InsertOrReplaceAsync(item);
    }

    public async Task DeleteItemAsync<T>(T item)
    {
        await Init();
        await Database.DeleteAsync(item);
    }

    public async Task DeleteAllItemAsync<T>()
    {
        await Database.DeleteAllAsync<T>();
    }
}