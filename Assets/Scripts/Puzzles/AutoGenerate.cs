using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGenerate : MonoBehaviour
{
    [SerializeField] GameObject generate;
    [SerializeField] GameObject loadingAnimation;
    private AsyncOperation operation;

    void Start()
    {
        generate.GetComponent<RuntimeGeneration>().image = FindObjectOfType<PuzzleImage>().GetImage();
        generate.GetComponent<RuntimeGeneration>().GeneratePuzzle();
        //StartCoroutine(GeneratePuzzle());
    }

    private void OnDestroy()
    {
        User.PuzzleCount++;
    }

    IEnumerator GeneratePuzzle()
    {
        yield return new WaitForSeconds(0.01f);
        generate.GetComponent<RuntimeGeneration>().GeneratePuzzle();
    }
}
