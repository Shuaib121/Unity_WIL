using UnityEngine;
using UnityEngine.UI;
using Lean.Gui;
using TMPro;

public class DynamicInstantiation : MonoBehaviour
{
    public ScrollRect View;
    public GameObject Content;
    public LeanButton Prefab;

    void Start()
    {
        GenerateMenuItem("Cleaning", "test description", null, "Story");
    }

    public void GenerateMenuItem(string title, string description, Image icon, string scene)
    {
        LeanButton latestButton = Instantiate(Prefab);
        latestButton.transform.SetParent(Content.transform, false);

        latestButton.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = title ?? "Untitled";

        latestButton.transform.Find("Description").GetComponent<TextMeshProUGUI>().text = description ?? "";

        latestButton.OnClick.AddListener(
           () => OnMenuItemClick(scene, title));

        View.verticalNormalizedPosition = 1;
    }

    void OnMenuItemClick(string scene, string title)
    {
        GameObject.Find("Logic").GetComponent<ChosenOption>().SetTitle(gameObject);
        GameObject.Find("Logic").GetComponent<SceneLoader>().LoadSceneByName(scene);
    }
}
