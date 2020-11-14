using Lean.Gui;
using SimpleSQL;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FlashcardsDbController : MonoBehaviour
{
    // reference to the database manager in the scene
    public SimpleSQLManager dbManager;
    public GameObject screens;
    public List<Sprite> images;
    // Start is called before the first frame update
    void Start()
    {
        //dbManager.CreateTable<FlashcardsTable>();  //this will create a table using the FlashcardsTable class, should only be called once and cannot be called with other methods below

        //AddImage();  //Adds images to the db from a list of sprite paths

        //LoadImage();  //Loads images into the scene

        //DeleteImage(); //Delete all images from the db 

    }

    public void AddImage()
    {
        //var path = AssetDatabase.GetAssetPath(images[0]);
        List<string> paths = new List<string>();
        foreach(Sprite sprite in images)
        {
            paths.Add(AssetDatabase.GetAssetPath(sprite));
        }

        foreach(string path in paths)
        {
            // check that the path exists
            if (!File.Exists(path))
            {
                Debug.LogError("Path does not exist! ");
                return;
            }

            var id = 1;
            // read the bytes of the file from the path
            var imageData = File.ReadAllBytes(path);

            // get the next ID from the database
            var sql = "SELECT MAX(ID) + 1 ID FROM FlashcardsTable";
            bool recordExists;
            var result = dbManager.QueryFirstRecord<FlashcardsTable>(out recordExists, sql);
            if (recordExists)
            {
                id = result.ID;
            }

            // insert the image as a byte array
            sql = "INSERT INTO FlashcardsTable (ID, FlashcardName, FlashcardCategory, ImageData) VALUES (?, ?, ?, ?)";
            dbManager.Execute(sql, id, "SeaCards", "Sea Creatures", imageData);
        }
    }

    public void LoadImage()
    {
        // load data from database

        var allScreens = screens.GetComponentsInChildren<BoxCollider2D>(); // gets the panel component to set sprites
        int screenCounter = 0;

        var sql = "SELECT * FROM FlashcardsTable";
        var results = dbManager.Query<FlashcardsTable>(sql);
        SetActiveScreens(results.Count);
        // display results
        foreach (var result in results)
        {
            // set up a new texture element. The size is irrelevant since it will be overwritten
            var texture = new Texture2D(2, 2);
            // load image data from database blob (byte array)
            texture.LoadImage(result.ImageData);

            allScreens[screenCounter].GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            screenCounter++;
        }
    }

    public void DeleteImage()
    {
        var sql = "DELETE FROM FlashcardsTable WHERE FlashcardCategory = 'Sea Creatures' ";
        dbManager.Execute(sql);
    }

    //void SetScreens()
    //{
    //    var listSize = flashCards.Count;
    //    SetActiveScreens(listSize);
    //    var screens = GetComponentsInChildren<BoxCollider2D>(); // gets the panel component to set sprites

    //    for (int x = 0; x < listSize; x++)//loops through the screen array and sets all the storycards to be viewed
    //    {
    //        screens[x].gameObject.GetComponent<Image>().sprite = flashCards[x];
    //    }
    //}

    private static void SetActiveScreens(int listSize) // sets amount of screens to be used
    {
        FindObjectOfType<LeanConstrainAnchoredPosition>().HorizontalRectMin = -listSize + 1;
    }

}
