using Lean.Gui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryScreens : MonoBehaviour
{
    [SerializeField] List<Sprite> storyCards;

    // Start is called before the first frame update
    void Start()
    {
        storyCards = FindObjectOfType<StoryPictures>().GetStoryCards();
        SetStoryScreens();
    }

    void SetStoryScreens()
    {
        var listSize = storyCards.Count;
        SetActiveScreens(listSize);
        var screens = GetComponentsInChildren<BoxCollider2D>(); // gets the panel component to set sprites

        for (int x = 0; x < listSize; x++)//loops through the screen array and sets all the storycards to be viewed
        {
            screens[x].gameObject.GetComponent<Image>().sprite = storyCards[x];
        }
    }

    private static void SetActiveScreens(int listSize) // sets amount of screens to be used
    {
        FindObjectOfType<LeanConstrainAnchoredPosition>().HorizontalRectMin = -listSize + 1;
    }
}
