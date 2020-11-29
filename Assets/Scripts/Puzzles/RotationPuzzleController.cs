using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPuzzleController : MonoBehaviour
{
    [SerializeField] List<Transform> pictures;
    [SerializeField] GameObject puzzles;
    [SerializeField] GameObject winParticle;
    [SerializeField] GameObject winDisplay;
    [SerializeField] AudioClip winSound;

    public static bool youWin;
    bool played = false;

    // Start is called before the first frame update
    void Start()
    {

        
        var tempPuzzle = FindObjectOfType<PuzzleImage>().GetRotationImage();
        puzzles = Instantiate(tempPuzzle, new Vector3(0.4f,1.05f, -5.639398f),Quaternion.identity);
        puzzles.SetActive(true);

        foreach (Transform child in puzzles.transform)
        {
            pictures.Add(child);
        }
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
                winDisplay.SetActive(true);
                AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position , 0.5f);
                played = true;
            }

        }

    }

    private void OnDestroy()
    {
        User.PuzzleCount++;
    }
}
