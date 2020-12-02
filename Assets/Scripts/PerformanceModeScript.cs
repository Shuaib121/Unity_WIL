using UnityEngine;
using UnityEngine.UI;

public class PerformanceModeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("LowPerformance") == 1)
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 30;
        }
    }

    public void UpdatePerformanceMode()
    {
        if (GameObject.Find("TogglePerformance").GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("LowPerformance", 1);
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 30;
        }
        else
        {
            PlayerPrefs.SetInt("LowPerformance", 0);
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 90;
        }
    }
}
