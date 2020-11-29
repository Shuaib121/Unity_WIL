using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPuzzleSelection : MonoBehaviour
{
    public void SetPuzzle(GameObject puzzle)
    {
        FindObjectOfType<PuzzleImage>().SetRotationImage(puzzle);
    }
}
