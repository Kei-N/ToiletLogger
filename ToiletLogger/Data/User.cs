using SQLite;

namespace ToiletLogger.Data;

public class User
{
    [PrimaryKey, AutoIncrement]
    public Guid Id { get; set; }

    public string Name { get; set; }
}