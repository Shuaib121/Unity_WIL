
using SQLite4Unity3d;

public class StoryTable
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string StoryName { get; set; }
    public string StoryText { get; set; }
    public int Language { get; set; }
    public byte[] Icon { get; set; }
}
