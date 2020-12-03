using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    List<string> sceneNames = new List<string> { "Main Menu", "Selection", "PuzzleSelection", "RotationPuzzleSelection" };
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(PlayerPrefs.GetInt("MuteMusic") == 1)
        {
            return;
        }

        string sceneName = scene.name;

        if (!sceneNames.Contains(sceneName))
        {
            GetComponent<AudioSource>().enabled = false;
        }
        else
        {
            GetComponent<AudioSource>().enabled = true;
        }
    }

}
