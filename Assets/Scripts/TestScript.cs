using UnityEngine;
using UnityEngine.UI;
using static NativeGallery;
using TMPro;

public class TestScript : MonoBehaviour
{
	//[SerializeField] TextMeshProUGUI tmp;
	//[SerializeField] Image image;
	public GameObject cell;

	// Start is called before the first frame update
	void Start()
    {
        for (int i = 0; i < 5; i++)
		{
			GameObject item = Instantiate(cell).gameObject;
			GameObject content = GameObject.Find("Content");
			item.transform.SetParent(content.transform);
			item.transform.Find("Image").GetComponent<Image>().color = Color.black;
		}

	}

	public void PickImage(int maxSize)
	{

		Permission permission = GetImagesFromGallery((path) =>
		{
            for (int i = 0; i < path.Length; i++)
            {
				Texture2D texture = LoadImageAtPath(path[i], maxSize, false);
				GameObject item = Instantiate(cell).gameObject;
				GameObject content = GameObject.Find("Content");
				item.transform.SetParent(content.transform);
				item.transform.Find("Image").GetComponent<Image>().sprite =
					Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0f, 0f));
			}


			/*
			Debug.Log("Image path: " + path);
			tmp.text = path[0];
			if (path != null)
			{
				// Create Texture from selected image
				Texture2D texture = NativeGallery.LoadImageAtPath(path[0], maxSize);
				if (texture == null)
				{
					Debug.Log("Couldn't load texture from " + path);
					return;
				}

				image.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

			}*/
		}, "Select an image", "image/*");

		Debug.Log("Permission result: " + permission);
	}

	public void Finish()
    {
		GameObject content = GameObject.Find("Content");

        foreach (Transform child in content.transform)
        {
			string tts = child.Find("Image").GetChild(0).GetChild(0).Find("Text").GetComponent<TextMeshProUGUI>().text;
			Debug.Log(tts);
        }
	}

}
