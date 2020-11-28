using UnityEngine;
using UnityEngine.UI;
using Lean.Gui;
using TMPro;

public class AchievementGeneration : MonoBehaviour
{
    private const string LANGUAGE = "Language";
    public ScrollRect View;
    public GameObject Content;
    public GameObject Prefab;
    [SerializeField] Sprite StoryIcon;
    [SerializeField] Sprite FlashcardIcon;
    [SerializeField] Sprite MCQIcon;
    [SerializeField] Sprite PuzzleIcon;

    void Start()
    {
        User.FetchAchievementStorage();
        AchievementList.Achievements.Clear();
        AchievementList.BuildAchievements();

        GenerateButtonsFromList();
    }

    public void GenerateMenuItem(string title, AchievementType type, int difficulty, double progress, string description)
    {
        Sprite icon = StoryIcon;
        Color color = new Color(1f, 0f, 0.5f);
        switch (type)
        {
            case AchievementType.FLASHCARD:
                icon = FlashcardIcon;
                color = new Color(1f, 0.69f, 0f);
                break;
            case AchievementType.MCQ:
                icon = MCQIcon;
                color = new Color(0.3f, 0.8f, 0f);
                break;
            case AchievementType.PUZZLE:
                icon = PuzzleIcon;
                color = new Color(0.35f, 0.48f, 1f);
                break;
        }

        GameObject latestButton = Instantiate(Prefab);

        latestButton.transform.SetParent(Content.transform, false);

        latestButton = latestButton.transform.Find("AnimatedButton").gameObject;

        latestButton.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = title ?? "Untitled";

        latestButton.transform.Find("IconBackground").GetComponent<Image>().color = color;

        latestButton.transform.Find("IconBackground").transform.Find("Icon").GetComponent<Image>().sprite = icon;

        latestButton.transform.Find("Progress").GetComponent<Slider>().value = (float)progress;

        latestButton.GetComponent<Button>().onClick.AddListener(
          () => OnMenuItemClick(title, description));

        View.verticalNormalizedPosition = 1;
    }

    void OnMenuItemClick(string title, string description)
    {
        GameObject dialog = GameObject.Find("AchievementDialog");
        dialog.GetComponent<LeanWindow>().On = true;
        dialog.transform.Find("Panel").transform.Find("Text").GetComponent<TextMeshProUGUI>().text = description;
    }

    void GenerateButtonsFromList()
    {
        foreach (var item in AchievementList.Achievements)
        {
            GenerateMenuItem(item.Title, item.type, item.Difficulty, item.Progess, item.Description);
        }
    }

    private Sprite GetSprite(byte[] imageData)
    {
        Texture2D texture = new Texture2D(0, 0);
        texture.LoadImage(imageData);
        var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

        return sprite;
    }
}
