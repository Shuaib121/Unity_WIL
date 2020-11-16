
using SQLite4Unity3d;

public class FlashcardsTitleTable 
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string FlashcardTitle { get; set; }
}
