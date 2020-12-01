public class Achievement
{
    public string Title;
    public string AfrixTitle;
    public string Description;
    public string AfrixDescription;
    public int Difficulty;
    public double Progess;
    public AchievementType type;

    public Achievement()
    {
        AchievementList.Achievements.Add(this);
    }
}
