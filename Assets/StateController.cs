using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateController : MonoBehaviour
{
    private DataService ds = new DataService("MainDatabase.db");
    private List<FlashcardsTitleTable> flashTitles;
    private List<SocialStoriesTitleTable> socialStoryTitles;
    private List<StoryTable> storyTable;
    private List<MCQTitle> mcqTitles;
    [SerializeField] int index = 0;

    void Awake()
    {
        int stateCheck = FindObjectsOfType<StateController>().Length;
        if (stateCheck > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        flashTitles = ds.GetFlashcardTitles().ToList();
        socialStoryTitles = ds.GetStorycardTitles().ToList();
        storyTable = ds.GetStories().ToList();
        mcqTitles = ds.GetMCQTitles().ToList(); ;
    }

    public List<FlashcardsTitleTable> GetFlashTitles()
    {
        return flashTitles;
    }
    public List<SocialStoriesTitleTable> GetSocialTitles()
    {
        return socialStoryTitles;
    }
    public List<StoryTable> GetStoryTitles()
    {
        return storyTable;
    }
    public List<MCQTitle> GetMcqTitles()
    {
        return mcqTitles;
    }

    public void SetIndex(int selection)
    {
        index = selection;
    }

    public int GetIndex()
    {
        return index;
    }
}
