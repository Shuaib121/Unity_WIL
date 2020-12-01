using UnityEngine;
using UnityEngine.UI;
using static NativeGallery;
using TMPro;
using System.Collections.Generic;
using SQLite4Unity3d;
using System.Linq;

public class TestScript : MonoBehaviour
{
	//[SerializeField] TextMeshProUGUI tmp;
	//[SerializeField] Image image;
	public GameObject cell;
	List<string> categories = new List<string>();

	// Start is called before the first frame update
	void Start()
    {
		DataService ds = new DataService("MainDatabase.db");
		List<FlashcardsTitleTable> d = ds.GetFlashcardTitles().ToList();
		categories.Clear();

		foreach (var item in d)
		{
			if (item.Language == PlayerPrefs.GetInt("Language"))
			{
				categories.Add(item.FlashcardTitle);
			}
		}

		for (int i = 0; i < 5; i++)
		{
			GameObject item = Instantiate(cell).gameObject;
			GameObject content = GameObject.Find("Content");
			item.transform.SetParent(content.transform);
			item.transform.Find("Image").GetComponent<Image>().color = Color.black;

			item.transform.Find("Image").Find("Dropdown").GetComponent<TMP_Dropdown>().ClearOptions();
			item.transform.Find("Image").Find("Dropdown").GetComponent<TMP_Dropdown>().AddOptions(categories);
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
					Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

				item.transform.Find("Image").Find("Dropdown").GetComponent<TMP_Dropdown>().ClearOptions();
				item.transform.Find("Image").Find("Dropdown").GetComponent<TMP_Dropdown>().AddOptions(categories);
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
		var dbPath = string.Format(@"Assets/StreamingAssets/{0}", "MainDatabase.db");
		var db = new SQLiteConnection(dbPath);
		db.CreateTable<FlashcardsTable>();

		foreach (Transform child in content.transform)
        {
			string english = child.Find("Image").Find("English").GetChild(0).Find("Text").GetComponent<TextMeshProUGUI>().text;
			TMP_Dropdown dropdown = child.Find("Image").Find("Dropdown").GetComponent<TMP_Dropdown>();
			string category = dropdown.options[dropdown.value].text;

			byte[] imageData = child.Find("Image").GetComponent<Image>().sprite.texture.EncodeToPNG();

			FlashcardsTable s = new FlashcardsTable()
			{
				Category = category,
				FlashcardName = english,
				FlashcardText = english,
				ImageData = imageData
			};
			db.Insert(s);
		}
	}
}
