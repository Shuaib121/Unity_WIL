using UnityEngine;
using UnityEngine.UI;

public class UpdateCheckBoxes : MonoBehaviour
{
    // Start is called before the first frame update

    public void UpdateBoxes()
    {
        if (PlayerPrefs.GetInt("EditMode") == 1)
        {
            GameObject.Find("Toggle").GetComponent<Toggle>().isOn = true;
        }

        if (PlayerPrefs.GetInt("LowPerformance") == 1)
        {
            GameObject.Find("TogglePerformance").GetComponent<Toggle>().isOn = true;
        }
    }
}
