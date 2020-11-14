using System.Collections.Generic;
using UnityEngine;


public class StoryPictures : MonoBehaviour
{
    public List<Sprite> storyImages;

    void Awake()//checks if a storypicture objects exists, if true then do not destroy it
    {
        int storyImageCheck = FindObjectsOfType<StoryPictures>().Length;
        if (storyImageCheck > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PopluateStoryCards(StoryButton button)// populates list with story pictures
    {
        storyImages = button.GetImages();
    }

    public List<Sprite> GetStoryCards()//returns list with story pictures
    {
        return storyImages;
    }
}
