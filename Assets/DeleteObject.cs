using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    public GameObject gameObject;
    // Start is called before the first frame update
    public void Delete()
    {
        Destroy(gameObject.gameObject);
    }
}
