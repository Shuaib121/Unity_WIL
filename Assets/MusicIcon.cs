using UnityEngine;
using UnityEngine.UI;

public class MusicIcon : MonoBehaviour
{
    [SerializeField] Sprite muted;
    [SerializeField] Sprite unmuted;

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
}
