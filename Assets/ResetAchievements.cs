using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetAchievements : MonoBehaviour
{
    // Start is called before the first frame update
    public void ResetAchievement()
    {
        User.BooksRead = 0;
        User.FlashcardButtonPress = 0;
        User.MCQCorrectCount = 0;
        User.MCQPerfectCount = 0;
        User.PuzzleCount = 0;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
