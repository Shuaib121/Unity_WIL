using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoGenerate : MonoBehaviour
{

    [SerializeField] GameObject generate;
    [SerializeField] GameObject loadingAnimation;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        StartCoroutine(GeneratePuzzle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    IEnumerator GeneratePuzzle()
    {
        yield return new WaitForSeconds(0.01f);
        var job = new VelocityJob()
        {
            generate = this.generate
        };

        JobHandle jobHandle = job.Schedule();
        jobHandle.Complete();
        if (jobHandle.IsCompleted)
        {
            Debug.Log("Puzzle Loaded");
        }
    }

    struct VelocityJob : IJob
    {
        public GameObject generate;
        public void Execute()
        {
            generate.GetComponent<RuntimeGeneration>().GeneratePuzzle();
        }
    }

}
