using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorybookManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        var story = Instantiate(Resources.Load(FindObjectOfType<ChosenOption>().GetTitle()) as GameObject);
        story.SetActive(true);

        var bookBulder = story.GetComponentInChildren<MegaBookBuilder>();

        FindObjectOfType<MegaBookControl>().book = bookBulder;
        FindObjectOfType<MegaBookMouseControl>().book = bookBulder;


    }

    private void OnDestroy()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
