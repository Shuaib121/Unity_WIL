using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void StoryScene()
    {
        StartCoroutine(DelayNextScene("Story")); //loads the story scene to display chosen story
    }

    public void MainStoryScene()
    {
        StartCoroutine(DelayNextScene("NormalStories")); //loads the story scene to display chosen story
    }

    public void StorySelectionScene() //loads the story selection screen
    {
        if(FindObjectOfType<ChosenOption>())
        {
            Destroy(FindObjectOfType<ChosenOption>());
        }

        StartCoroutine(DelayNextScene("StorySelection"));
    }

    public void MainMenu()//loads main menu
    {
        var optionObject = FindObjectsOfType<ChosenOption>();
        foreach(var option in optionObject)
        {
            Destroy(option.gameObject);
        }

        StartCoroutine(DelayNextScene("Main Menu"));
    }

    public void MCQScene()//loads MCQScene
    {
        StartCoroutine(DelayNextScene("MCQ"));
    }

    public void MCQSelectionScene()//loads MCQSelectionScene
    {
        StartCoroutine(DelayNextScene("MCQSelection"));
    }


    public void FlashcardsScene()//loads flashcard scene
    {
        StartCoroutine(DelayNextScene("Flashcards"));
    }

    public void FlashSelection() //loads flashselection scene
    {
        StartCoroutine(DelayNextScene("FlashSelection"));
    }
    public void PuzzleScene()//loads puzzle scene
    {
        StartCoroutine(DelayNextScene("Puzzle"));
    }
    private IEnumerator DelayNextScene(string scene) //delays sceneloading
    {
        yield return new WaitForSeconds(0.05f);

        SceneManager.LoadScene(scene);
    }
}
