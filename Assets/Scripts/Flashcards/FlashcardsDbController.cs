using Lean.Gui;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class FlashcardsDbController : MonoBehaviour
{
    private readonly DataService ds = new DataService("MainDatabase.db");
    List<FlashcardsTable> FlashCards = new List<FlashcardsTable>();
    int Index = 0;


    void Start()
    {
        //FlashCards = ds.GetFlashcard().ToList();
        Initialize();
        DisplayCurrentImage();
    }

    public void Initialize()
    {
        var tempList = ds.GetFlashcard().ToList();
        foreach (var card in tempList)
        {
            if (card.Category == FindObjectOfType<ChosenOption>().GetTitle())
            {
                FlashCards.Add(card);
            }
        }
    }

    public void Next()
    {
        if (Index == FlashCards.Count - 1) return;
        Index++;
        DisplayCurrentImage();
        User.FlashcardButtonPress++;
    }

    public void Previous()
    {
        if (Index < 1) return;
        Index--;
        DisplayCurrentImage();
    }

    private void DisplayCurrentImage()
    {
        Transform image = GameObject.Find("CurrentPictureShape").gameObject.transform.Find("CurrentFlashCard");
        Texture2D texture = new Texture2D(0, 0);
        texture.LoadImage(FlashCards.ElementAt(Index).ImageData);;
        image.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }

    public void TtsSpeak()
    {
        string text = FlashCards.ElementAt(Index).FlashcardText;
        FindObjectOfType<Speech>().SpeakCard(text);
    }
}
