using UnityEngine;
using UnityEngine.UI;

public class EditModeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("EditMode") == 1)
        {
            GameObject.Find("EditMode").transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        }
    }

    public void ChangeMode()
    {
        if (GameObject.Find("Toggle").GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("EditMode", 1);
            GameObject.Find("EditMode").transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("EditMode", 0);
            GameObject.Find("EditMode").transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        }
        Debug.Log(PlayerPrefs.GetInt("EditMode"));
    }
}
