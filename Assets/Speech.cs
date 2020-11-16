using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speech : MonoBehaviour
{
    // Start is called before the first frame update
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
        TextToSpeech.instance.SetLanguage(TextToSpeech.Locale.ENGLISH_US);
        TextToSpeech.instance.SetVolume(0.5f);
        TextToSpeech.instance.SetPitch(0.75f);
        TextToSpeech.instance.SetSpeed(1f);

        TextToSpeech.instance.Speak("Initialized");
    }

    public void SpeakCard(string text)
    {
        if (!TextToSpeech.instance.IsSpeaking())
        {
            TextToSpeech.instance.Speak(text);
        }
    }
}
