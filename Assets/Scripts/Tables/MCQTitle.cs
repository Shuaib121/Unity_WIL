
using SQLite4Unity3d;

public class MCQTitle
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string MCQName { get; set; }
    public int Language { get; set; }
    public byte[] Icon { get; set; }
}
