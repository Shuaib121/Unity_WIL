using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbacusSetup : MonoBehaviour
{
    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
    }

    private void OnDestroy()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
