using UnityEngine;
using UnityEngine.UI;

public class MusicIcon : MonoBehaviour
{
    [SerializeField] Sprite muted;
    [SerializeField] Sprite unmuted;


    private void Start()
    {
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
        }
        else
        {
            PlayerPrefs.SetInt("MuteMusic", 0);
        }

        Mute();
    }
}
