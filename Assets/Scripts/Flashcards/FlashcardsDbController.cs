using Lean.Gui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashcardsDbController : MonoBehaviour
{
    public GameObject screens;
    private FlashcardDataService ds = new FlashcardDataService("MainDatabase.db");
    private string flashTitle;
    void Start()
    {
        flashTitle = FindObjectOfType<ChosenOption>().GetTitle();
        LoadImages();
    }

    private void LoadImages()
    {
        var flashcards = ds.GetFlashcard();
        var screens = this.screens.GetComponentsInChildren<BoxCollider2D>();
        int screenCounter = 0;
        foreach (var card in flashcards)
        {
            if (card.Category == flashTitle)
            {
                var texture = new Texture2D(2, 2);
                texture.LoadImage(card.ImageData);

                screens[screenCounter].gameObject.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                screenCounter++;
            }
        }

        SetActiveScreens(screenCounter);
    }

    private static void SetActiveScreens(int listSize) // sets amount of screens to be used
    {
        FindObjectOfType<LeanConstrainAnchoredPosition>().HorizontalRectMin = -listSize + 1;
    }

}
