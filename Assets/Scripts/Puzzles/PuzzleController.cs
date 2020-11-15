using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    [SerializeField] Transform[] pictures;
    [SerializeField] GameObject winParticle;
    [SerializeField] AudioClip winSound;

    public static bool youWin;
    bool played = false;

    // Start is called before the first frame update
    void Start()
    {
        youWin = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfWon();
        PlayWinParticles();
    }

    private void CheckIfWon()
    {
        bool correct = true;
        foreach (Transform picture in pictures)
        {
            if (picture.rotation.z != 0)
            {
                correct = false;
            }
        }

        youWin = correct;
    }

    private void PlayWinParticles()
    {
        if(youWin)
        {
            if(!played)
            {
                winParticle.GetComponent<ParticleSystem>().Play();
                AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position , 0.5f);
                played = true;
            }

        }

    }
}
