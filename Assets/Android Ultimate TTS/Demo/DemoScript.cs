using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoScript : MonoBehaviour
{

    public InputField inputText;
    public InputField customLang;
    public InputField defaultEngine;
    public InputField audioFileName;
    public Image speechStarted;
    public Image speechError;
    public Image speechEnd;
    public Dropdown languageSelection;
    public Dropdown ttsEngines;
    public Dropdown ttsEngineVoices;
    private string[] installedEngines;
    private string[] ttsVoices;

    // Start is called before the first frame update
    void Start()
    {


        if (Application.platform == RuntimePlatform.Android)
        {
            TextToSpeech.Instance.Initialize(TextToSpeech.Locale.ENGLISH_US , 1 , 0.75f , 1, (bool wasSuccessful) => 
            {
                if (wasSuccessful)
                {
                    TextToSpeech.Instance.RegisterUtteranceListeners(gameObject, "SpeechStarted", "SpeechError", "SpeechEnded");

                    List<Dropdown.OptionData> languageOptions = new List<Dropdown.OptionData>();

                    foreach (var value in System.Enum.GetValues(typeof(TextToSpeech.Locale)))
                    {
                        Dropdown.OptionData option = new Dropdown.OptionData(System.Enum.GetName(typeof(TextToSpeech.Locale), value));

                        languageOptions.Add(option);
                    }

                    languageSelection.ClearOptions();
                    languageSelection.AddOptions(languageOptions);


                    List<Dropdown.OptionData> engineOptions = new List<Dropdown.OptionData>();

                    installedEngines = TextToSpeech.Instance.GetInstalledEngines();

                    foreach (var value in installedEngines)
                    {
                        Dropdown.OptionData option = new Dropdown.OptionData(value);

                        engineOptions.Add(option);
                    }

                    ttsEngines.ClearOptions();
                    ttsEngines.AddOptions(engineOptions);

                    defaultEngine.text = TextToSpeech.Instance.GetDefaultEngine();

                    audioFileName.text = "MyAudioFile";
                }

                else
                {
                    TextToSpeech.Instance.Toast("Failed to initialize TTS engine", TextToSpeech.ToastLength.LENGTH_LONG);
                }
            });
          
        }
      
    }





    public void StartSpeaking()
    {

        TextToSpeech.Instance.Speak(inputText.text, (string error) =>
        {
            TextToSpeech.Instance.Toast("An error occured while speaking  " + error, TextToSpeech.ToastLength.LENGTH_LONG);
        });

        defaultEngine.text = TextToSpeech.Instance.GetDefaultEngine();

    }



    public void StopSpeaking()
    {
        TextToSpeech.Instance.StopSpeech();
    }



    public void SetVolume(float volume)
    {
        TextToSpeech.Instance.SetVolume(volume);
    }


    public void SetPitch(float pitch)
    {
        TextToSpeech.Instance.SetPitch(pitch);
    }


    public void SetSpeed(float speed)
    {
        TextToSpeech.Instance.SetSpeed(speed);
    }


    public void SetLanguage(int option)
    {
        TextToSpeech.Instance.SetLanguage((TextToSpeech.Locale)option);
        //string status = TextToSpeech.instance.SetLanguage((TextToSpeech.Locale)option);
        //var s = (TextToSpeech.Locale)option;
        //Debug.Log($"Status for \"{System.Enum.GetName(typeof(TextToSpeech.Locale), s)}\" is:  " + status + " is LANGUAGE available?  " + TextToSpeech.instance.IsLanguageAvailable((TextToSpeech.Locale)option));
    }



    public void SetEngine(int option)
    {
        bool ans = TextToSpeech.Instance.SetTTSEngineByName(installedEngines[option], false);
        Debug.Log("Set engine to \"" + installedEngines[option] + "\" successful ?   " +ans + "  is Google TTS installed?   " + TextToSpeech.Instance.IsGoogleTTSInstalled());
    }



    public void SetCustomLanguage()
    {
        if(!customLang.text.Contains(",")) { return; }

        string[] split = customLang.text.Split(',');
        split[0].Replace(" ", "");
        split[1].Replace(" ", "");

        TextToSpeech.Instance.SetLanguageFromCustomLocale(split[0], split[1]);

        //string status = TextToSpeech.instance.SetLanguageFromCustomLocale(split[0] , split[1]);
        //Debug.Log($"Status for \"{customLang.text}\" is:  " + status + " is Custom LANGUAGE available?  " + TextToSpeech.instance.IsCustomLanguageAvailable(split[0], split[1]));
    }



    public void GetVoices()
    {
        ttsVoices = TextToSpeech.Instance.GetVoices();

        List<Dropdown.OptionData> engineVoices = new List<Dropdown.OptionData>();

        foreach (var value in ttsVoices)
        {
            //Debug.Log("Voice name  " + value);
            Dropdown.OptionData option = new Dropdown.OptionData(value);

            engineVoices.Add(option);
        }

        ttsEngineVoices.ClearOptions();
        ttsEngineVoices.AddOptions(engineVoices);
    }


    public void SetSelectedVoice()
    {      
        bool ans = TextToSpeech.Instance.SetVoice(ttsVoices[ttsEngineVoices.value]);
        Debug.Log("Set voice to \"" + ttsVoices[ttsEngineVoices.value] + "\" Was successful ?   " + ans );
    }


    public void SetDefaultVoice()
    {
        TextToSpeech.Instance.SetDefaultVoice();
    }


    public void SynthesizeToFile()
    {
        TextToSpeech.Instance.SynthesizeToFile(inputText.text, audioFileName.text, (bool wasSuccessfull, string savedTo) => 
        {
            if (wasSuccessfull)
            {
                TextToSpeech.Instance.Toast("Successfully synthesize audio file to path " + savedTo, TextToSpeech.ToastLength.LENGTH_LONG);
            }
            else
            {
                TextToSpeech.Instance.Toast("Failed to synthesize audio file to path " + savedTo, TextToSpeech.ToastLength.LENGTH_LONG);
            }
        });
    }




    // utteranceId is a unique number that is associated with the text that was spoken
    // These IDs always start with 1 and add up by 1 all the way upto "9223372036854775806" after which it starts again from 1
    // So the ID for the first spoken sentence is definitely 1, for the second sentence 2 and so on ...
    private void SpeechStarted(string utteranceId)
    {
        TextToSpeech.Instance.Toast("Started speaking text with Utterance ID: " + utteranceId, TextToSpeech.ToastLength.LENGTH_LONG);
        Debug.Log("Started speaking text with Utterance ID: " + utteranceId);

        speechStarted.fillAmount = 1;
        speechError.fillAmount = 0;
        speechEnd.fillAmount = 0;
    }


    // utteranceId is a unique number that is associated with the text that was spoken
    // These IDs always start with 1 and add up by 1 all the way upto "9223372036854775806" after which it starts again from 1
    // So the ID for the first spoken sentence is definitely 1, for the second sentence 2 and so on ...
    private void SpeechError(string utteranceId)
    {
        TextToSpeech.Instance.Toast("An error occurred while trying to speak the text with Utterance ID: " + utteranceId, TextToSpeech.ToastLength.LENGTH_LONG);
        Debug.Log("An error occurred while trying to speak the text with Utterance ID: " + utteranceId);

        speechError.fillAmount = 1;
        speechStarted.fillAmount = 0;
        speechEnd.fillAmount = 0;
    }


    // utteranceId is a unique number that is associated with the text that was spoken
    // These IDs always start with 1 and add up by 1 all the way upto "9223372036854775806" after which it starts again from 1
    // So the ID for the first spoken sentence is definitely 1, for the second sentence 2 and so on ...
    private void SpeechEnded(string utteranceId)
    {
        TextToSpeech.Instance.Toast("End speaking text with Utterance ID: " + utteranceId, TextToSpeech.ToastLength.LENGTH_LONG);
        Debug.Log("End speaking text with Utterance ID: " + utteranceId);

        speechEnd.fillAmount = 1;
        speechError.fillAmount = 0;
        speechStarted.fillAmount = 0;
    }

}
