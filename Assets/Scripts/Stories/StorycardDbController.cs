using Lean.Gui;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class StorycardDbController : MonoBehaviour
{
    private readonly DataService ds = new DataService("MainDatabase.db");
    List<StorycardsTable> StoryCards = new List<StorycardsTable>();
    int Index = 0;

    void Start()
    {
        StoryCards = ds.GetStorycards().ToList();
        DisplayCurrentImage();
    }

    public void Next()
    {
        if (Index == StoryCards.Count - 1) return;
        Index++;
        DisplayCurrentImage();
    }

    public void Previous()
    {
        if (Index < 1) return;
        Index--;
        DisplayCurrentImage();
    }

    private void DisplayCurrentImage()
    {
        Transform image = GameObject.Find("CurrentCardBackground").gameObject.transform.Find("CurrentStoryCard");
        Texture2D texture = new Texture2D(0, 0);
        texture.LoadImage(StoryCards.ElementAt(Index).SCardImage); ;
        image.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }

    public void TtsSpeak()
    {
        string text = StoryCards.ElementAt(Index).SCardText;
        Debug.Log(text);
        FindObjectOfType<Speech>().SpeakCard(text);
    }
}
