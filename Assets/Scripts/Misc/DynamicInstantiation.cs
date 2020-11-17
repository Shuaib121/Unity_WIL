using UnityEngine;
using UnityEngine.UI;
using Lean.Gui;
using TMPro;
using System.Collections.Generic;

public class DynamicInstantiation : MonoBehaviour
{
    private const string LANGUAGE = "Language";
    public ScrollRect View;
    public GameObject Content;
    public LeanButton Prefab;

    void Start()
    {
        GenerateButtonsFromList();
    }

    public void GenerateMenuItem(string title, string description, Image icon, string scene)
    {
        LeanButton latestButton = Instantiate(Prefab);
        latestButton.transform.SetParent(Content.transform, false);

        latestButton.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = title ?? "Untitled";

        latestButton.transform.Find("Description").GetComponent<TextMeshProUGUI>().text = description ?? "";

        latestButton.OnClick.AddListener(
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
                    GenerateMenuItem(btn.FlashcardTitle, null, null, "Flashcards");
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
                    GenerateMenuItem(btn.StoryTitles, null, null, "Story");
                }
            }
        }

        if (index == 2)
        {
            foreach (var btn in stateController.GetMcqTitles())
            {
                if (btn.Language == PlayerPrefs.GetInt(LANGUAGE))
                {
                    GenerateMenuItem(btn.MCQName, null, null, "MCQ");
                }

            }
        }
    }
}
