using UnityEngine;
using TMPro;
public class MenuItemTranslator : MonoBehaviour
{
    [SerializeField] string English;
    [SerializeField] string Afrikaans;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Language") == 1)
        {
            GetComponent<TextMeshProUGUI>().text = English;
        }else
        {
            GetComponent<TextMeshProUGUI>().text = Afrikaans;
        }
    }
}
