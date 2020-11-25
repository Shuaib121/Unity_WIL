﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGenerate : MonoBehaviour
{
    [SerializeField] GameObject generate;
    [SerializeField] GameObject loadingAnimation;
    private AsyncOperation operation;
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        generate.GetComponent<RuntimeGeneration>().GeneratePuzzle();
        //StartCoroutine(GeneratePuzzle());
    }

    private void OnDestroy()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    IEnumerator GeneratePuzzle()
    {
        yield return new WaitForSeconds(0.01f);
        generate.GetComponent<RuntimeGeneration>().GeneratePuzzle();
    }
}
