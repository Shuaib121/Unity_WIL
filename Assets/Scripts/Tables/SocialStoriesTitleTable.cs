using SQLite4Unity3d;

public class SocialStoriesTitleTable 
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string StoryTitles { get; set; }
    public int Language { get; set; }
}

