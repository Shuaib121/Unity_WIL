using UnityEngine;
using UnityEngine.UI;

public class MusicIcon : MonoBehaviour
{
    [SerializeField] Sprite muted;
    [SerializeField] Sprite unmuted;
    private AudioSource mainMenuAudio;

    private void Start()
    {
        mainMenuAudio = FindObjectOfType<MenuMusic>().gameObject.GetComponent<AudioSource>();
        Mute();
    }
    public void Mute()
    {
        if (PlayerPrefs.GetInt("MuteMusic") == 1)
        {
            GetComponent<Image>().sprite = muted;
        }else
        {
            GetComponent<Image>().sprite = unmuted;
        }
    }

    public void MuteToggle()
    {
        int muted = PlayerPrefs.GetInt("MuteMusic");

        if(muted == 0)
        {
            PlayerPrefs.SetInt("MuteMusic", 1);
            mainMenuAudio.enabled = false;
        }
        else
        {
            PlayerPrefs.SetInt("MuteMusic", 0);
            mainMenuAudio.enabled = true;
        }

        Mute();
    }
}
