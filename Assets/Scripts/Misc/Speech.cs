using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speech : MonoBehaviour
{
    private void Awake()
    {

    }
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            SetupTts();
        }
    }

    private void SetupTts()
    {
        TextToSpeech.instance.Initialize();
        TextToSpeech.instance.SetLanguage(TextToSpeech.Locale.ENGLISH_UK);
        TextToSpeech.instance.SetVolume(0.5f);
        TextToSpeech.instance.SetPitch(0.75f);
        TextToSpeech.instance.SetSpeed(0.8f);
    }

    public void SpeakCard(string text)
    {
        TextToSpeech.instance.StopSpeech();
        if (!TextToSpeech.instance.IsSpeaking())
        {
            TextToSpeech.instance.Speak(text);
        }
    }
}
