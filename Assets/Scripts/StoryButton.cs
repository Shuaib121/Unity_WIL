using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryButton : MonoBehaviour
{
    [SerializeField] List<Sprite> storyImages;
    public List<Sprite> GetImages()
    {
        return storyImages;
    }
}
