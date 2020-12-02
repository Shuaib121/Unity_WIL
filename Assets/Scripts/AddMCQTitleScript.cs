using UnityEngine;
using UnityEngine.UI;
using static NativeGallery;
using TMPro;
using System.Collections.Generic;
using SQLite4Unity3d;
using System.Linq;
using System;
using Lean.Gui;

public class AddMCQTitleScript : MonoBehaviour
{
	public GameObject cell;

	// Start is called before the first frame update
	void Start()
    {
	}

	public void AddItem()
    {
		GameObject item = Instantiate(cell).gameObject;
		GameObject content = GameObject.Find("Content");
		item.transform.SetParent(content.transform);
	}

	public void PickImage(int maxSize)
	{
		Permission permission = GetImageFromGallery((path) =>
		{
			Texture2D texture = LoadImageAtPath(path, maxSize, false);
			GameObject item = Instantiate(cell).gameObject;
			GameObject content = GameObject.Find("Content");
			item.transform.SetParent(content.transform);
			item.transform.Find("Image").GetComponent<Image>().sprite =
				Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

		}, "Select an image", "image/*");
	}

	public void Finish()
    {
		GameObject content = GameObject.Find("Content");

		//UNITY EDITOR DB PATH
		//var dbPath = string.Format(@"Assets/StreamingAssets/{0}", "MainDatabase.db");
		var dbPath = string.Format("{0}/{1}", Application.persistentDataPath, "MainDatabase.db");

		var db = new SQLiteConnection(dbPath);
		db.CreateTable<FlashcardsTable>();

		foreach (Transform child in content.transform)
		{
			string caption = child.Find("Image").Find("Caption").GetChild(0).Find("Text").GetComponent<TextMeshProUGUI>().text;

			byte[] imageData = child.Find("Image").GetComponent<Image>().sprite.texture.EncodeToPNG();

			MCQTitle title = new MCQTitle()
			{
				MCQName = caption,
				Icon = imageData,
				Language = PlayerPrefs.GetInt("Language")
			};

			db.Insert(title);
		}
		/*
		try
        {

		}
		catch(Exception exception)
        {
			GameObject.Find("ConfirmDialog").GetComponent<LeanWindow>().On = true;
			GameObject.Find("ConfirmDialog").transform.Find("Panel").Find("Text").GetComponent<TextMeshProUGUI>().text = exception.Message;
        }
		*/
	}
}
