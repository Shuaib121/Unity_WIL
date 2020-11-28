using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static NativeGallery;

public class TestScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tmp;
	[SerializeField] Image image;
	// Start is called before the first frame update
	void Start()
    {
        
    }

	public void PickImage(int maxSize)
	{

		NativeGallery.Permission permission = NativeGallery.GetImagesFromGallery((path) =>
		{
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
			}
		}, "Select an image", "image/*");

		Debug.Log("Permission result: " + permission);
	}

}
