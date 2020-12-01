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
    [SerializeField] TextMeshProUGUI fantasyStoryText;
    [SerializeField] TextMeshProUGUI mcqText;
    [SerializeField] TextMeshProUGUI puzzleText;
    [SerializeField] TextMeshProUGUI jigsawPuzzleText;
    [SerializeField] TextMeshProUGUI colouringBookText;
    [SerializeField] TextMeshProUGUI mathsGameText;
    [SerializeField] TextMeshProUGUI wordsGameText;
    [SerializeField] TextMeshProUGUI abacusText;

    private void Start()
    {
        UpdateLanguage();
    }

    public void SetEnglish()
    {
        flashText.text = "Flashcards";
        socialStoryText.text = "Social Stories";
        fantasyStoryText.text = "Fantasy Stories";
        mcqText.text = "Multiple Choice\nTests";
        puzzleText.text = "Rotation Puzzles";
        jigsawPuzzleText.text = "Jigsaw Puzzles";
        colouringBookText.text = "Colouring Book";
        mathsGameText.text = "Maths Game";
        wordsGameText.text = "Words Game";
        abacusText.text = "Abacus";
    }

    public void SetAfrikaans()
    {
        flashText.text = "Flitskaarte";
        socialStoryText.text = "Sosiale Verhale";
        fantasyStoryText.text = "Fantasieverhale";
        mcqText.text = "Meervoudige\nKeusetoetse";
        puzzleText.text = "Rotasie Legkaarte";
        jigsawPuzzleText.text = "Legkaarte";
        colouringBookText.text = "Inkleurboek";
        mathsGameText.text = "Wiskunde Spel";
        wordsGameText.text = "Woordspel";
        abacusText.text = "Telraam";
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
