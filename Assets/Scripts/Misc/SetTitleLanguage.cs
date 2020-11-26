using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetTitleLanguage : MonoBehaviour
{
    private const string LANGUAGE = "Language";
    private const int ENGLISH = 1;
    private const int AFRIKAANS = 2;
    [SerializeField] TextMeshProUGUI flashText;
    [SerializeField] TextMeshProUGUI socialStoryText;
    [SerializeField] TextMeshProUGUI mcqText;
    [SerializeField] TextMeshProUGUI puzzleText;

    private void Start()
    {
        UpdateLanguage();
    }

    public void SetEnglish()
    {
        flashText.text = "Flashcards";
        socialStoryText.text = "Social Stories";
        mcqText.text = "Multiple Choice\nTests";
        puzzleText.text = "Puzzles";
    }

    public void SetAfrikaans()
    {
        flashText.text = "Flitskaarte";
        socialStoryText.text = "Sociale Stories";
        mcqText.text = "Meervoudige\nKeusetoetse";
        puzzleText.text = "Ruigels";
    }

    public void UpdateLanguage()
    {
        if(PlayerPrefs.GetInt(LANGUAGE) == ENGLISH)
        {
            SetEnglish();
        }

        if (PlayerPrefs.GetInt(LANGUAGE) == AFRIKAANS)
        {
            SetAfrikaans();
        }
    }
}
