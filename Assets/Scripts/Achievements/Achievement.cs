public class Achievement
{
    public string Title;
    public string Description;
    public int Difficulty;
    public double Progess;
    public AchievementType type;

    public Achievement()
    {
        AchievementList.Achievements.Add(this);
    }
}
