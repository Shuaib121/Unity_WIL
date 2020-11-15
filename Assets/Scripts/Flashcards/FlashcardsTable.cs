using SQLite4Unity3d;

public class FlashcardsTable
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public string FlashcardName { get; set; }
	public string Category { get; set; }

    //blobs are stored as byte arrays
    public byte[] ImageData { get; set; }

    //public override string ToString()
    //{
    //	return string.Format("[Person: Id={0}, Name={1},  Surname={2}, Age={3}]", Id, Name, Surname, Age);
    //}
}
