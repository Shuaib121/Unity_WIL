using UnityEngine;

public class User
{
    private static int _BooksRead;
    private static int _FlashcardButtonPress;
    private static int _MCQCorrectCount;
    private static int _MCQPerfectCount;
    private static int _PuzzleCount;

    public static void FetchAchievementStorage()
    {
        BooksRead = PlayerPrefs.GetInt("BooksRead");
        FlashcardButtonPress = PlayerPrefs.GetInt("FlashcardButtonPress");
        MCQCorrectCount = PlayerPrefs.GetInt("MCQCorrectCount");
        MCQPerfectCount = PlayerPrefs.GetInt("MCQPerfectCount");
        PuzzleCount = PlayerPrefs.GetInt("PuzzleCount");
    }

    public static int BooksRead
    {
        get => _BooksRead;

        set
        {
            _BooksRead = value;
            PlayerPrefs.SetInt("BooksRead", value);
            PlayerPrefs.Save();
        }
    }

    public static int FlashcardButtonPress
    {
        get => _FlashcardButtonPress;

        set
        {
            _FlashcardButtonPress = value;
            PlayerPrefs.SetInt("FlashcardButtonPress", value);
            PlayerPrefs.Save();
        }
    }

    public static int MCQCorrectCount
    {
        get => _MCQCorrectCount;

        set
        {
            _MCQCorrectCount = value;
            PlayerPrefs.SetInt("MCQCorrectCount", value);
            PlayerPrefs.Save();
        }
    }

    public static int MCQPerfectCount
    {
        get => _MCQPerfectCount;

        set
        {
            _MCQPerfectCount = value;
            PlayerPrefs.SetInt("MCQPerfectCount", value);
            PlayerPrefs.Save();
        }
    }

    public static int PuzzleCount
    {
        get => _PuzzleCount;

        set
        {
            _PuzzleCount = value;
            PlayerPrefs.SetInt("PuzzleCount", value);
            PlayerPrefs.Save();
        }
    }
}