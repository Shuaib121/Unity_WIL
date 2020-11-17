using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StoryDBController : MonoBehaviour
{

    private readonly DataService ds = new DataService("MainDatabase.db");
    List<StoryTable> Story = new List<StoryTable>();
    int Index = 0;
    [SerializeField] Text storyText;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        var tempList = ds.GetStories().ToList();
        foreach (var story in tempList)
        {
            if (story.StoryName == FindObjectOfType<ChosenOption>().GetTitle())
            {
                storyText.text = story.StoryText;
            }
        }
    }
}
