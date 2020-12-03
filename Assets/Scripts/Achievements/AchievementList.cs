using System.Collections.Generic;

public class AchievementList
{
    public static List<Achievement> Achievements = new List<Achievement>();

    public static List<Achievement> BuildAchievements()
    {
        //STORIES ACHIEVEMENTS
        new Achievement()
        {
            Title = "Book worm",
            AfrixTitle = "Boekwurm",
            Description = "Read 1 book",
            AfrixDescription = "Lees 1 boek",
            Difficulty = 1,
            Progess = double.IsInfinity(User.BooksRead / 1.0) == true
                    ? 0 : (User.BooksRead / 1.0 * 100),
            type = AchievementType.STORY
        };

        new Achievement()
        {
            Title = "Page turner",
            AfrixTitle = "Bladsydraaier",
            Description = "Read 5 books",
            AfrixDescription = "Lees 5 boeke",
            Difficulty = 2,
            Progess = double.IsInfinity(User.BooksRead / 5.0) == true
                    ? 0 : (User.BooksRead / 5.0 * 100),
            type = AchievementType.STORY
        };

        new Achievement()
        {
            Title = "Speed reader",
            AfrixTitle = "Spoedleser",
            Description = "Read 10 books",
            AfrixDescription = "Lees tien boeke",
            Difficulty = 3,
            Progess = double.IsInfinity(User.BooksRead / 10.0) == true
                ? 0 : (User.BooksRead / 10.0 * 100),
            type = AchievementType.STORY
        };

        new Achievement()
        {
            Title = "Bookmaster",
            AfrixTitle = "Boekmeester",
            Description = "Read 20 books",
            AfrixDescription = "Lees 20 boeke",
            Difficulty = 5,
            Progess = double.IsInfinity(User.BooksRead / 20.0) == true
                ? 0 : (User.BooksRead / 20.0 * 100),
            type = AchievementType.STORY
        };

        new Achievement()
        {
            Title = "Card dealer",
            AfrixTitle = "Kaarthandelaar",
            Description = "Press the flashcard button 1 time",
            AfrixDescription = "Druk die flitskaartknoppie 1 keer",
            Difficulty = 1,
            Progess = double.IsInfinity(User.FlashcardButtonPress / 1.0) == true
                ? 0 : (User.FlashcardButtonPress / 1.0 * 100),
            type = AchievementType.FLASHCARD
        };

        new Achievement()
        {
            Title = "Card master",
            AfrixTitle = "Kaartmeester",
            Description = "Press the flashcard button 20 times",
            AfrixDescription = "Druk die flitskaartknoppie 20 keer",
            Difficulty = 3,
            Progess = double.IsInfinity(User.FlashcardButtonPress / 20.0) == true
                ? 0 : (User.FlashcardButtonPress / 20.0 * 100),
            type = AchievementType.FLASHCARD
        };

        new Achievement()
        {
            Title = "The flash",
            AfrixTitle = "Die flits",
            Description = "Press the flashcard button 30 times",
            AfrixDescription = "Druk die flitskaartknoppie 30 keer",
            Difficulty = 4,
            Progess = double.IsInfinity(User.FlashcardButtonPress / 30.0) == true
                ? 0 : (User.FlashcardButtonPress / 30.0 * 100),
            type = AchievementType.FLASHCARD
        };

        //MCQ ACHIEVEMENTS
        new Achievement()
        {
            Title = "Chosen one",
            AfrixTitle = "Gekiesde een",
            Description = "Achieve 5 correct answers",
            AfrixDescription = "Bereik 5 korrekte antwoorde",
            Difficulty = 1,
            Progess = double.IsInfinity(User.MCQCorrectCount / 5.0) == true
                ? 0 : (User.MCQCorrectCount / 5.0 * 100),
            type = AchievementType.MCQ
        };

        new Achievement()
        {
            Title = "MCQ Master",
            AfrixTitle = "MCQ Meester",
            Description = "Achieve 20 correct answers",
            AfrixDescription = "Bereik 20 korrekte antwoorde",
            Difficulty = 2,
            Progess = double.IsInfinity(User.MCQCorrectCount / 20.0) == true
                ? 0 : (User.MCQCorrectCount / 20.0 * 100),
            type = AchievementType.MCQ
        };

        new Achievement()
        {
            Title = "Perfect score",
            AfrixTitle = "Perfekte telling",
            Description = "1 Pefect score",
            AfrixDescription = "1 Perfekte telling",
            Difficulty = 3,
            Progess = double.IsInfinity(User.MCQPerfectCount / 1.0) == true
        ? 0 : (User.MCQPerfectCount / 1.0 * 100),
            type = AchievementType.MCQ
        };

        new Achievement()
        {
            Title = "Perfection",
            AfrixTitle = "Volmaaktheid",
            Description = "3 Pefect scores",
            AfrixDescription = "3 Perfekte tellings",
            Difficulty = 5,
            Progess = double.IsInfinity(User.MCQPerfectCount / 3.0) == true
                ? 0 : (User.MCQPerfectCount / 3.0 * 100),
            type = AchievementType.MCQ
        };

        //PUZZLE ACHIEVEMENTS
        new Achievement()
        {
            Title = "Pieces!",
            AfrixTitle = "Stukke!",
            Description = "Complete 1 puzzle",
            AfrixDescription = "Voltooi 1 legkaart",
            Difficulty = 2,
            Progess = double.IsInfinity(User.PuzzleCount / 1.0) == true
                ? 0 : (User.PuzzleCount / 1.0 * 100),
            type = AchievementType.PUZZLE
        };

        new Achievement()
        {
            Title = "Puzzle mender",
            AfrixTitle = "Raaiselherstel",
            Description = "Complete 2 puzzles",
            AfrixDescription = "Voltooi 2 legkaarte",
            Difficulty = 3,
            Progess = double.IsInfinity(User.PuzzleCount / 2.0) == true
                ? 0 : (User.PuzzleCount / 2.0 * 100),
            type = AchievementType.PUZZLE
        };

        new Achievement()
        {
            Title = "Puzzle genius",
            AfrixTitle = "Legkaartgenie",
            Description = "Complete 3 puzzles",
            AfrixDescription = "Voltooi 3 legkaarte",
            Difficulty = 4,
            Progess = double.IsInfinity(User.PuzzleCount / 3.0) == true
                ? 0 : (User.PuzzleCount / 3.0 * 100),
            type = AchievementType.PUZZLE
        };

        new Achievement()
        {
            Title = "Puzzle master",
            AfrixTitle = "Legkaart meester",
            Description = "Complete 5 puzzles",
            AfrixDescription = "Voltooi 5 legkaarte",
            Difficulty = 5,
            Progess = double.IsInfinity(User.PuzzleCount / 5.0) == true
                ? 0 : (User.PuzzleCount / 5.0 * 100),
            type = AchievementType.PUZZLE
        };

        return Achievements;
    }
}
