using System.Collections.Generic;

public class AchievementList
{
    public static List<Achievement> Achievements = new List<Achievement>();

    public static List<Achievement> BuildAchievements()
    {
        //STORIES ACHIEVEMENTS
        new Achievement()
        {
            Title = "Reach for the sky",
            Description = "Read 1 book",
            Difficulty = 1,
            Progess = double.IsInfinity(User.BooksRead / 1.0) == true
                    ? 0 : (User.BooksRead / 1.0 * 100)
        };

        new Achievement()
        {
            Title = "Reach for the sky 5",
            Description = "Read 5 books",
            Difficulty = 2,
            Progess = double.IsInfinity(User.BooksRead / 5.0) == true
                    ? 0 : (User.BooksRead / 5.0 * 100)
        };

        new Achievement()
        {
            Title = "Reach for the sky 10",
            Description = "Read 10 books",
            Difficulty = 3,
            Progess = double.IsInfinity(User.BooksRead / 10.0) == true
                ? 0 : (User.BooksRead / 10.0 * 100)
        };

        new Achievement()
        {
            Title = "Reach for the sky 20",
            Description = "Read 20 books",
            Difficulty = 5,
            Progess = double.IsInfinity(User.BooksRead / 20.0) == true
                ? 0 : (User.BooksRead / 20.0 * 100)
        };

        //FLASHCARD ACHIEVEMENTS
        new Achievement()
        {
            Title = "fc 1",
            Description = "1 button press",
            Difficulty = 1,
            Progess = double.IsInfinity(User.FlashcardButtonPress / 1.0) == true
                ? 0 : (User.FlashcardButtonPress / 1.0 * 100)
        };

        new Achievement()
        {
            Title = "fc 2",
            Description = "10 button press",
            Difficulty = 2,
            Progess = double.IsInfinity(User.FlashcardButtonPress / 10.0) == true
                ? 0 : (User.FlashcardButtonPress / 10.0 * 100)
        };

        new Achievement()
        {
            Title = "fc 3",
            Description = "20 button press",
            Difficulty = 3,
            Progess = double.IsInfinity(User.FlashcardButtonPress / 20.0) == true
                ? 0 : (User.FlashcardButtonPress / 20.0 * 100)
        };

        new Achievement()
        {
            Title = "fc 4",
            Description = "30 button press",
            Difficulty = 4,
            Progess = double.IsInfinity(User.FlashcardButtonPress / 30.0) == true
                ? 0 : (User.FlashcardButtonPress / 30.0 * 100)
        };

        //MCQ ACHIEVEMENTS
        new Achievement()
        {
            Title = "mcq 1",
            Description = "5 total correct answers",
            Difficulty = 1,
            Progess = double.IsInfinity(User.MCQCorrectCount / 5.0) == true
                ? 0 : (User.MCQCorrectCount / 5.0 * 100)
        };

        new Achievement()
        {
            Title = "mcq 2",
            Description = "20 total correct answers",
            Difficulty = 2,
            Progess = double.IsInfinity(User.MCQCorrectCount / 20.0) == true
                ? 0 : (User.MCQCorrectCount / 20.0 * 100)
        };

        new Achievement()
        {
            Title = "mcq 3",
            Description = "1 pefect score",
            Difficulty = 3,
            Progess = double.IsInfinity(User.MCQPerfectCount / 1.0) == true
        ? 0 : (User.MCQPerfectCount / 1.0 * 100)
        };

        new Achievement()
        {
            Title = "mcq 4",
            Description = "3 pefect scores",
            Difficulty = 5,
            Progess = double.IsInfinity(User.MCQPerfectCount / 3.0) == true
                ? 0 : (User.MCQPerfectCount / 3.0 * 100)
        };

        //PUZZLE ACHIEVEMENTS
        new Achievement()
        {
            Title = "puzzle 1",
            Description = "1 puzzle",
            Difficulty = 2,
            Progess = double.IsInfinity(User.PuzzleCount / 1.0) == true
                ? 0 : (User.PuzzleCount / 1.0 * 100)
        };

        new Achievement()
        {
            Title = "puzzle 2",
            Description = "2 puzzle",
            Difficulty = 3,
            Progess = double.IsInfinity(User.PuzzleCount / 2.0) == true
                ? 0 : (User.PuzzleCount / 2.0 * 100)
        };

        new Achievement()
        {
            Title = "puzzle 3",
            Description = "3 puzzle",
            Difficulty = 4,
            Progess = double.IsInfinity(User.PuzzleCount / 3.0) == true
                ? 0 : (User.PuzzleCount / 3.0 * 100)
        };

        new Achievement()
        {
            Title = "puzzle 4",
            Description = "5 puzzle",
            Difficulty = 5,
            Progess = double.IsInfinity(User.PuzzleCount / 5.0) == true
                ? 0 : (User.PuzzleCount / 5.0 * 100)
        };

        return Achievements;
    }
}
