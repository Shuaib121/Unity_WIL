
using SQLite4Unity3d;

public class StorycardsTable
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string SCardName { get; set; }
    public string SCardText { get; set; }
    public string SCardCategory { get; set; }

    //blobs are stored as byte arrays
    public byte[] SCardImage { get; set; }

    //public override string ToString()
    //{
    //	return string.Format("[Person: Id={0}, Name={1},  Surname={2}, Age={3}]", Id, Name, Surname, Age);
    //}
}
