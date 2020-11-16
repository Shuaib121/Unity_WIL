using TMPro;
using UnityEngine;

public class ChosenOption : MonoBehaviour
{
    [SerializeField] private string option;

    void Awake()//checks if a chosenoption objects exists, if true then do not destroy it
    {
        int chosenOptionCheck = FindObjectsOfType<ChosenOption>().Length;
        if (chosenOptionCheck > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetTitle(string chosenOption)// populates list with story pictures
    {
        option = chosenOption;
        Debug.Log(option);
    }

    public string GetTitle()
    {
        return option;
    }
}
