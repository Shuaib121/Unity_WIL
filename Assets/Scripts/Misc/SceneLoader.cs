using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject loadingAnimation;
    private AsyncOperation operation;
    void Awake()
    {
        Application.targetFrameRate = 80;
    }
    public void LoadSceneByName(string scene)
    {
        StartCoroutine(DelayNextScene(scene));
    }

    public void StoryScene()
    {
        StartCoroutine(DelayNextScene("Story")); //loads the story scene to display chosen story
    }

    public void StorySelectionScene() //loads the story selection screen
    {
        if (FindObjectOfType<ChosenOption>())
        {
            Destroy(FindObjectOfType<ChosenOption>());
        }

        StartCoroutine(DelayNextScene("StorySelection"));
    }

    public void NormalStoryScene() //loads the normal story selection screen
    {
        if (FindObjectOfType<ChosenOption>())
        {
            Destroy(FindObjectOfType<ChosenOption>());
        }

        StartCoroutine(DelayNextScene("NormalStories"));
    }

    public void MainMenu()//loads main menu
    {
        var optionObject = FindObjectsOfType<ChosenOption>();
        foreach (var option in optionObject)
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

    public void JigsawPuzzleScene()//loads puzzle scene
    {
        StartCoroutine(DelayNextSceneLoader("JigsawPuzzle"));
    }

    public void SelectionScene()//loads puzzle scene
    {
        StartCoroutine(DelayNextScene("Selection"));
    }

    private IEnumerator DelayNextScene(string scene) //delays sceneloading
    {
        operation = SceneManager.LoadSceneAsync(scene);

        yield return new WaitForSeconds(0.05f);
    }

    private IEnumerator DelayNextSceneLoader(string scene)
    {
        //SceneManager.UnloadSceneAsync("Main Menu");
        operation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            loadingAnimation.SetActive(true);

            if (operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }

        //loadingAnimation.SetActive(false);
    }
}
