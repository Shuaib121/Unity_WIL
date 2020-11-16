
using SQLite4Unity3d;

public class SocialStoriesTable
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string CardName { get; set; }
    public string CardText { get; set; }
    public string CardCategory { get; set; }

    //blobs are stored as byte arrays
    public byte[] CardImage { get; set; }

}
