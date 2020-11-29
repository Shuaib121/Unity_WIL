using SQLite4Unity3d;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static NativeGallery;

public class TestScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tmp; //tmp for testing purposes
    [SerializeField] Image image;
    [SerializeField] TMP_Dropdown dropdownMenu;

    private readonly DataService ds = new DataService("MainDatabase.db");
    private List<FlashcardsTable> flashcards = new List<FlashcardsTable>();
    private SQLiteConnection db;
    private List<ImageText> images = new List<ImageText>();
    // Start is called before the first frame update
    void Start()
    {
        db = ds.GetConnection();
        Initialize();

        dropdownMenu.onValueChanged.AddListener(delegate
        {
            tmp.text = dropdownMenu.options[dropdownMenu.value].text;
        });

    }

    //A class just to store the image and its text
    private class ImageText
    {
        public Texture2D image;
        public string imageText;

        public ImageText(Texture2D image, string imageText) 
        {
            this.image = image;
            this.imageText = imageText;
        }
    }

    //Populates the dropdown menu with flashcard titles so it can be used as the category when inserting
    public void Initialize()
    {
        dropdownMenu.ClearOptions();
        var tempList = ds.GetFlashcardTitles().ToList();
        List<string> options = new List<string>();
        foreach (var card in tempList)
        {
            options.Add(card.FlashcardTitle);
        }

        dropdownMenu.AddOptions(options);
    }

    //Asks the user to pick an image form their gallery and saves it in a string(path)
    public void PickImage(int maxSize) 
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                // Create Texture from selected image
                Texture2D texture = NativeGallery.LoadImageAtPath(path, maxSize, false);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }
                images.Add(new ImageText(texture,""));
                image.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            }
        }, "Select an image", "image/*");
        Debug.Log("Permission result: " + permission);
    }

    //turns an image into a flashcard, currently does not get the text for it but that can be done with a parameter
    private void UpdateImageList()
    {
        flashcards.Clear();
        int counter = 0;
        tmp.text = "POPULATING";
        foreach (var image in images)
        {
            byte[] imageData = image.image.EncodeToPNG();
            var currentCategory = dropdownMenu.options[dropdownMenu.value].text;
            tmp.text = "select count(*) from FlashcardsTable where Category = '" + currentCategory + "'";

            var categoryCount = db.ExecuteScalar<int>("select count(*) from FlashcardsTable where Category = '" + currentCategory + "'");
            FlashcardsTable card = new FlashcardsTable();
            card.FlashcardName = currentCategory + categoryCount++;
            card.FlashcardText = image.imageText;
            card.Category = currentCategory;
            card.ImageData = imageData;

            counter++;
            flashcards.Add(card);
        }

    }

    //Inserts cards into the database
    public void InsertCardsToDB()
    {
        tmp.text = "Insterting";
        int counter = 0;
        foreach (var card in flashcards)
        {
            db.Insert(card);
            counter++;
        }
        tmp.text = "Insterted: " + counter;
    }


}
