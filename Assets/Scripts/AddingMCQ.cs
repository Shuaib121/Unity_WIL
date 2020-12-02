using UnityEngine;
using UnityEngine.UI;
using static NativeGallery;
using TMPro;
using System.Collections.Generic;
using SQLite4Unity3d;
using System.Linq;

public class AddingMCQ : MonoBehaviour
{
	//[SerializeField] TextMeshProUGUI tmp;
	//[SerializeField] Image image;
	public GameObject cell;
	List<string> categories = new List<string>();

	// Start is called before the first frame update
	void Start()
    {
		DataService ds = new DataService("MainDatabase.db");
		List<MCQTitle> d = ds.GetMCQTitles().ToList();
		categories.Clear();

		foreach (var item in d)
		{
			if (item.Language == PlayerPrefs.GetInt("Language"))
			{
				categories.Add(item.MCQName);
			}
		}
		GameObject.Find("Dropdown").GetComponent<TMP_Dropdown>().ClearOptions();
		GameObject.Find("Dropdown").GetComponent<TMP_Dropdown>().AddOptions(categories);
	}

	public void AddItem()
    {
		GameObject item = Instantiate(cell).gameObject;
		GameObject content = GameObject.Find("Content");
		item.transform.SetParent(content.transform);
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
		//var dbPath = string.Format(@"Assets/StreamingAssets/{0}", "MainDatabase.db");
		var dbPath = string.Format("{0}/{1}", Application.persistentDataPath, "MainDatabase.db");
		var db = new SQLiteConnection(dbPath);
		db.CreateTable<MCQTable>();

		foreach (Transform child in content.transform)
        {
			string question = child.Find("Image").Find("Question").GetChild(0).Find("Text").GetComponent<TextMeshProUGUI>().text;
			string answerOne = child.Find("Image").Find("AnswerOne").GetChild(0).Find("Text").GetComponent<TextMeshProUGUI>().text;
			string answerTwo = child.Find("Image").Find("AnswerTwo").GetChild(0).Find("Text").GetComponent<TextMeshProUGUI>().text;
			string answerThree = child.Find("Image").Find("AnswerThree").GetChild(0).Find("Text").GetComponent<TextMeshProUGUI>().text;
			string answerFour = child.Find("Image").Find("AnswerFour").GetChild(0).Find("Text").GetComponent<TextMeshProUGUI>().text;
			TMP_Dropdown rightDropdown = child.Find("Image").Find("CorrectAnswer").GetComponent<TMP_Dropdown>();
			int correctIndex = rightDropdown.value;
			string correct = answerOne;

			switch(correctIndex)
            {
				case 1:
					correct = answerTwo;
					break;
				case 2:
					correct = answerThree;
					break;
				case 3:
					correct = answerFour;
					break;
				default:
					correct = answerOne;
					break;
            }

			TMP_Dropdown dropdown = GameObject.Find("Dropdown").GetComponent<TMP_Dropdown>();
			string category = dropdown.options[dropdown.value].text;

			//byte[] imageData = child.Find("Image").GetComponent<Image>().sprite.texture.EncodeToPNG();

			MCQTable mcq = new MCQTable()
			{
				question = question,
				optionOne = answerOne,
				optionTwo = answerTwo,
				optionThree = answerThree,
				optionFour = answerFour,
				answer = correct,
				testName = category
			};

			db.Insert(mcq);
		}
	}
}
