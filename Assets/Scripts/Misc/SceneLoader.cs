using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject loadingAnimation;
    private AsyncOperation operation;
    void Awake()
    {
        Application.targetFrameRate = 90;
    }
    public void LoadSceneByName(string scene)
    {
        StartCoroutine(DelayNextScene(scene));
    }

    public void StoryScene()
    {
        StartCoroutine(DelayNextScene("Story")); //loads the story scene to display chosen story
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
        Screen.orientation = ScreenOrientation.Portrait;
        var optionObject = FindObjectsOfType<ChosenOption>();
        foreach (var option in optionObject)
        {
            Destroy(option.gameObject);
        }

        StartCoroutine(DelayNextScene("Main Menu"));
    }

    public void MainMenuFromColouringBook()//loads main menu
    {
        Destroy(GameObject.Find("DrawCanvas"));
        Screen.orientation = ScreenOrientation.Portrait;
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


    public void FlashcardsScene()//loads flashcard scene
    {
        StartCoroutine(DelayNextScene("Flashcards"));
    }

    public void PuzzleScene()//loads puzzle scene
    {
        StartCoroutine(DelayNextScene("Puzzle"));
    }

    public void PuzzleSelectionScene()//loads puzzle scene
    {
        Screen.orientation = ScreenOrientation.Portrait;
        StartCoroutine(DelayNextScene("PuzzleSelection"));
    }
    public void RotationPuzzleSelectionScene()//loads puzzle scene
    {
        StartCoroutine(DelayNextScene("RotationPuzzleSelection"));
    }

    public void WordGameScene()//loads word game scene
    {

        int language = PlayerPrefs.GetInt("Language");

        if(language == 1)
        {
            StartCoroutine(DelayNextScene("EnglishWordGame"));
        }
        else
        {
            StartCoroutine(DelayNextScene("AfrikaansWordGame"));
        }

    }
    public void JigsawPuzzleScene(GameObject puzzleObject )//loads jigsaw puzzle scene
    {
        Screen.orientation = ScreenOrientation.Landscape;
        FindObjectOfType<PuzzleImage>().SetImage(puzzleObject.GetComponent<JigPuzzleButton>().GetImage());
        StartCoroutine(DelayNextSceneLoader("JigsawPuzzle"));
    }

    public void CreateJigsawPuzzleScene()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        StartCoroutine(DelayNextSceneLoader("JigsawPuzzle"));
    }

    public void MathsGameScene()//loads math game scene
    {
        StartCoroutine(DelayNextSceneLoader("MathsGame"));
    }

    public void AbacusScene()//loads math game scene
    {
        StartCoroutine(DelayNextSceneLoader("Abacus"));
    }


    public void SelectionScene()//loads selection scene
    {
        StartCoroutine(DelayNextSceneLoader("Selection"));
    }

    public void DrawingGame()//loads drawing scene
    {
        Screen.orientation = ScreenOrientation.Landscape;
        StartCoroutine(DelayNextSceneLoader("DrawingAlbum"));
    }

    private IEnumerator DelayNextScene(string scene) //delays sceneloading
    {
        yield return new WaitForSeconds(0.10f);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(scene);
    }

    private IEnumerator DelayNextSceneLoader(string scene)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        loadingAnimation.SetActive(true);

        operation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
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
    }
}
