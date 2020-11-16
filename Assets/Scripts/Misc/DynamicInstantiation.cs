using UnityEngine;
using UnityEngine.UI;
using Lean.Gui;

public class DynamicInstantiation : MonoBehaviour
{
    public ScrollRect View;
    public GameObject Content;
    public LeanButton Prefab;

    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            LeanButton latestButton = Instantiate(Prefab);
            latestButton.transform.SetParent(Content.transform, false);
            //latestButton.transform.Find("Text").GetComponent<Text>().text = Random.Range(1, 100).ToString();
            latestButton.OnClick.AddListener(
                () => CustomClick(latestButton.transform.Find("Text").GetComponent<Text>().text));
        }
        View.verticalNormalizedPosition = 1;
    }

    void CustomClick(string text)
    {
        Debug.Log("IT WORKS - " + text);
    }
}
