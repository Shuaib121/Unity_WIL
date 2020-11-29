using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleImage : MonoBehaviour
{
    [SerializeField] Texture2D jigsawPuzzleImage;
    [SerializeField] GameObject rotationPuzzleImage;
    // Start is called before the first frame update
    public Texture2D GetImage()
    {
        return jigsawPuzzleImage;
    }

    public void SetImage(Texture2D puzzleImage)
    {
       this.jigsawPuzzleImage = puzzleImage;
    }

    public GameObject GetRotationImage()
    {
        return rotationPuzzleImage;
    }

    public void SetRotationImage(GameObject image)
    {
        rotationPuzzleImage = image;
    }

}
