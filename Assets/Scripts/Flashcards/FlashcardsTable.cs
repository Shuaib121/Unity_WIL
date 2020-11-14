using SimpleSQL;
public class FlashcardsTable
{
    [PrimaryKey]
    public int ID { get; set; }
	public string FlashcardName { get; set; }

	public string FlashcardCategory { get; set; }
    // blobs are stored as byte arrays
    public byte[] ImageData { get; set; }


}
