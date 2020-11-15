using Lean.Gui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorycardDbController : MonoBehaviour
{
    public GameObject screens;
    private DataService ds = new DataService("MainDatabase.db");
    private string storyTitle;

    // Start is called before the first frame update
    void Start()
    {
        storyTitle = FindObjectOfType<ChosenOption>().GetTitle();
        LoadImages();
    }

    private void LoadImages()
    {
        var flashcards = ds.GetStorycards();
        var screens = this.screens.GetComponentsInChildren<BoxCollider2D>();
        int screenCounter = 0;
        foreach (var card in flashcards)
        {
            if (card.SCardCategory == storyTitle)
            {
                var texture = new Texture2D(2, 2);
                texture.LoadImage(card.SCardImage);

                screens[screenCounter].gameObject.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                screenCounter++;
            }

            SetActiveScreens(screenCounter);
        }
    }

    private static void SetActiveScreens(int listSize) // sets amount of screens to be used
    {
        FindObjectOfType<LeanConstrainAnchoredPosition>().HorizontalRectMin = -listSize + 1;
    }
}
