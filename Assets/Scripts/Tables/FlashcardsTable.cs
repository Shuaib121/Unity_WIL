using SQLite4Unity3d;

public class FlashcardsTable
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public string FlashcardName { get; set; }
    public string FlashcardText { get; set; }
    public string Category { get; set; }

    //blobs are stored as byte arrays
    public byte[] ImageData { get; set; }

}
