using UnityEngine;
using UnityEngine.UI;
using Lean.Gui;
using TMPro;

public class DynamicInstantiation : MonoBehaviour
{
    private const string LANGUAGE = "Language";
    public ScrollRect View;
    public GameObject Content;
    public GameObject Prefab;

    void Start()
    {
        GenerateButtonsFromList();
    }

    public void GenerateMenuItem(string title, Sprite icon, string scene)
    {

        var latestButton = Instantiate(Prefab);
        latestButton.transform.SetParent(Content.transform, false);

        latestButton = latestButton.transform.Find("AnimatedButton").gameObject;

        latestButton.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = title ?? "Untitled";

        latestButton.transform.Find("IconBackground").GetComponent<Image>().sprite = icon;

        //latestButton.transform.Find("Description").GetComponent<TextMeshProUGUI>().text = description ?? "";

        latestButton.GetComponent<Button>().onClick.AddListener(
           () => OnMenuItemClick(scene, title));

        View.verticalNormalizedPosition = 1;
    }

    void OnMenuItemClick(string scene, string title)
    {
        GameObject.Find("Logic").GetComponent<ChosenOption>().SetTitle(title);
        GameObject.Find("Logic").GetComponent<SceneLoader>().LoadSceneByName(scene);
    }

    void GenerateButtonsFromList()
    { 
        var stateController = FindObjectOfType<StateController>();
        int index = stateController.GetIndex();
        if(index == 0)
        {
            foreach (var btn in stateController.GetFlashTitles())
            {
                if(btn.Language == PlayerPrefs.GetInt(LANGUAGE))
                {
                    var sprite = GetSprite(btn.Icon);
                    GenerateMenuItem(btn.FlashcardTitle, sprite, "Flashcards");
                }
            }
        }

        if (index == 1)
        {
            foreach (var btn in stateController.GetSocialTitles())
            {
                Debug.Log(btn.Language + "    " + PlayerPrefs.GetInt(LANGUAGE));
                if (btn.Language == PlayerPrefs.GetInt(LANGUAGE))
                {
                    var sprite = GetSprite(btn.Icon);
                    GenerateMenuItem(btn.StoryTitles, sprite, "Story");
                }
            }
        }

        if (index == 2)
        {
            foreach (var btn in stateController.GetStoryTitles())
            {
                if (btn.Language == PlayerPrefs.GetInt(LANGUAGE))
                {
                    var sprite = GetSprite(btn.Icon);
                    GenerateMenuItem(btn.StoryName, sprite, "MegaBook");
                }
            }
        }

        if (index == 3)
        {
            foreach (var btn in stateController.GetMcqTitles())
            {
                if (btn.Language == PlayerPrefs.GetInt(LANGUAGE))
                {
                    var sprite = GetSprite(btn.Icon);
                    GenerateMenuItem(btn.MCQName, sprite, "MCQ");
                }

            }
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
