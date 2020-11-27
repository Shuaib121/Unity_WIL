using UnityEngine;
public class TestAchievement : MonoBehaviour
{
    void Start()
    {
        //FETCH ACHIEVEMENTS FROM STORAGE
        User.FetchAchievementStorage();

        //GET AND SET ACHIEVEMENTS (AUTO SAVED TO PLAYERPREFS AFTER SETTING A VALUE)
        Debug.Log("Books read before is " + User.BooksRead);
        User.BooksRead++;
        Debug.Log("Books read after is " + User.BooksRead);

        //GENERATE ACHIEVEMENTS AND ADD TO LIST
        AchievementList.BuildAchievements();

        //FOREACH ACHIEVEMENT
        foreach (var item in AchievementList.Achievements)
        {
            Debug.Log(item.Progess);

            if (item.Progess >= 100)
            {
                //ACHIEVEMENT IS COMPLETE
            }
        }
    }
}
