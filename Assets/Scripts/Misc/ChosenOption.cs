using Lean.Gui;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChosenOption : MonoBehaviour
{
    private string option;

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

    private void Start()
    {

    }

    public void SetTitle(GameObject chosenOption)// populates list with story pictures
    {
        option = chosenOption.GetComponentInChildren<TextMeshProUGUI>().text;
        Debug.Log(option);
    }

    public string GetTitle()
    {
        return option;
    }
}
