using SQLite4Unity3d;

public class StorycardsTitles
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string StoryTitles{ get; set; }
}
