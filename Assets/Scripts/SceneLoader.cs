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

    public void StorySelectionScene() //loads the story selection screen
    {
        if(FindObjectOfType<StoryPictures>())
        {
            Destroy(FindObjectOfType<StoryPictures>());
        }

        StartCoroutine(DelayNextScene("StorySelection"));
    }

    public void MainMenu()//loads main menu
    {
        StartCoroutine(DelayNextScene("Main Menu"));
    }

    public void FlashcardsScene()//loads flashcard scene
    {
        StartCoroutine(DelayNextScene("Flashcards"));
    }

    public void PuzzleScene()//loads puzzle scene
    {
        StartCoroutine(DelayNextScene("Puzzle"));
    }
    private IEnumerator DelayNextScene(string scene) //delays sceneloading
    {
        yield return new WaitForSeconds(0.2f);

        SceneManager.LoadScene(scene);
    }
}
