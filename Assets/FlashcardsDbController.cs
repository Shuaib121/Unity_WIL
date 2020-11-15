using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashcardsDbController : MonoBehaviour
{
    public GameObject screens;
    public Text DebugText;
    private FlashcardDataService ds = new FlashcardDataService("tempDatabase.db");
    void Start()
    {
        //StartSync();
        LoadImages();
    }

    private void StartSync()
    {
        ds.CreateDB();
        var flashcards = ds.GetFlashcard();
    }

    private void LoadImages()
    {
        var flashcards = ds.GetFlashcard();
        var screens = this.screens.GetComponentsInChildren<BoxCollider2D>();
        int screenCounter = 0;
        foreach (var card in flashcards)
        {
            DebugText.text += card.Id + " " + card.Category;

            var texture = new Texture2D(2, 2);
            texture.LoadImage(card.ImageData);

            screens[screenCounter].gameObject.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            screenCounter++;
        }
    }



}
