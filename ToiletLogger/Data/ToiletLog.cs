using SQLite;

namespace ToiletLogger.Data;

/// <summary>
/// トイレ記録
/// </summary>
public class ToiletLog
{
    [PrimaryKey, AutoIncrement]
    public Guid Id { get; set; }

    public ToiletType ToiletType { get; set; }

    public DateTime Date { get; set; }

    public Guid UserId { get; set; }
}
