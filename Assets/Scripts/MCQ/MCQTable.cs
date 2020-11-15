using SQLite4Unity3d;

public class MCQTable
{

    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string testName { get; set; }
    public string question { get; set; }
    public string optionOne { get; set; }
    public string optionTwo { get; set; }
    public string optionThree { get; set; }
    public string optionFour { get; set; }
    public string answer { get; set; }

}
