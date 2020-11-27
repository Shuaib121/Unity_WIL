using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleImage : MonoBehaviour
{
    [SerializeField] Texture2D puzzleImage;
    // Start is called before the first frame update
    public Texture2D GetImage()
    {
        return puzzleImage;
    }

    public void SetImage(Texture2D puzzleImage)
    {
       this.puzzleImage = puzzleImage;
    }
}
