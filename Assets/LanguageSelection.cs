using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSelection : MonoBehaviour
{
    private const string LANGUAGE = "Language";
    private const int ENGLISH = 1;
    private const int AFRIKAANS = 2;
    [SerializeField] GameObject languagePopup;

    private void Start()
    {
        if (!PlayerPrefs.HasKey(LANGUAGE))
        {
            languagePopup.SetActive(true);
        }
    }
    public void SetEnglish()
    {
        PlayerPrefs.SetInt(LANGUAGE, ENGLISH);
    }

    public void SetArikaans()
    {
        PlayerPrefs.SetInt(LANGUAGE, AFRIKAANS);
    }
}
