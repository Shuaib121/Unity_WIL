using UnityEngine;
using UnityEngine.UI;
using Lean.Gui;
using TMPro;

public class AchievementGeneration : MonoBehaviour
{
    private const string LANGUAGE = "Language";
    public ScrollRect View;
    public GameObject Content;
    public LeanButton Prefab;
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

    public void GenerateMenuItem(string title, AchievementType type, int difficulty)
    {
        Sprite icon = StoryIcon;
        switch(type)
        {
            case AchievementType.FLASHCARD:
                icon = FlashcardIcon;
                break;
            case AchievementType.MCQ:
                icon = MCQIcon;
                break;
            case AchievementType.PUZZLE:
                icon = PuzzleIcon;
                break;
        }

        LeanButton latestButton = Instantiate(Prefab);
        latestButton.transform.SetParent(Content.transform, false);

        latestButton.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = title ?? "Untitled";

        latestButton.transform.Find("IconBackground").transform.Find("Icon").GetComponent<Image>().sprite = icon;

        //latestButton.transform.Find("Description").GetComponent<TextMeshProUGUI>().text = difficulty.ToString() ?? "";

        latestButton.OnClick.AddListener(
          () => OnMenuItemClick(title));

        View.verticalNormalizedPosition = 1;
    }

    void OnMenuItemClick(string title)
    {
        Debug.Log("click");
        GameObject dialog = GameObject.Find("AchievementDialog");
        dialog.GetComponent<LeanWindow>().On = true;
        dialog.transform.Find("Panel").transform.Find("Text").GetComponent<TextMeshProUGUI>().text = title;
    }

    void GenerateButtonsFromList()
    {
        foreach (var item in AchievementList.Achievements)
        {
            GenerateMenuItem(item.Title, item.type, item.Difficulty);
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
