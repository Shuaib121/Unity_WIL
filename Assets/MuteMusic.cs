using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteMusic : MonoBehaviour
{
    private int musicCheck;

    // Start is called before the first frame update
    void Start()
    {
        musicCheck = PlayerPrefs.GetInt("MuteMusic");

        if (musicCheck == 1)
        {
            GetComponent<AudioSource>().enabled = false;
        }
    }

}
