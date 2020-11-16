using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryDBController : MonoBehaviour
{
    [SerializeField] Text storyText;
    private readonly DataService ds = new DataService("MainDatabase.db");
    List<StoryTable> stories = new List<StoryTable>();

    // Start is called before the first frame update
    void Start()
    {
        SetStoryText();
    }

    private void SetStoryText()
    {
        stories = ds.GetStory().ToList();

        foreach(var story in stories)
        {
            if(story.StoryName == "Little Red Riding Hood")
            {
                storyText.text = story.StoryText;
            }
        }
    }
}
