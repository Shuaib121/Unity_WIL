using SQLite4Unity3d;
using UnityEngine;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;
public class FlashcardDataService : MonoBehaviour
{
	public List<Sprite> cards = new List<Sprite>();
	private SQLiteConnection _connection;

    public FlashcardDataService(string DatabaseName)
    {
#if UNITY_EDITOR
		var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);

#elif UNITY_STANDALONE_OSX
		var loadDb = Application.dataPath + "/Resources/Data/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
#else
	var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
	// then save to Application.persistentDataPath
	File.Copy(loadDb, filepath);

#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
		_connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

        Debug.Log("Final PATH: " + dbPath);
    }

    //public void CreateDB()
    //{
    //    _connection.DropTable<FlashcardsTable>();
    //    _connection.CreateTable<FlashcardsTable>();

    //    _connection.InsertAll(new[]{
    //        new FlashcardsTable{
				////Id = 1,
				//FlashcardName = "TEST",
    //            Category = "MORETEST",
    //        },
    //        new FlashcardsTable{
				////Id = 1,
				//FlashcardName = "TEST",
    //            Category = "MORETEST",
    //        },
    //        new FlashcardsTable{
				////Id = 1,
				//FlashcardName = "TEST",
    //            Category = "MORETEST",
    //        }

    //    });
    //}

    //public void AddImage()
    //{
    //	var path = imagePath.text.Trim();

    //	// check that the path exists
    //	if (!File.Exists(path))
    //	{
    //		Debug.LogError("Path does not exist! " + imagePath.text);
    //		return;
    //	}

    //	var id = 1;
    //	// read the bytes of the file from the path
    //	var imageData = File.ReadAllBytes(path);

    //	// get the next ID from the database
    //	var sql = "SELECT MAX(ID) + 1 ID FROM Images";
    //	bool recordExists;
    //	var result = dbManager.QueryFirstRecord<Images>(out recordExists, sql);
    //	if (recordExists)
    //	{
    //		id = result.ID;
    //	}

    //	// insert the image as a byte array
    //	sql = "INSERT INTO Images (ID, ImageData) VALUES (?, ?)";
    //	dbManager.Execute(sql, id, imageData);

    //	// reload images
    //	LoadImages();
    //}

 //   public IEnumerable<FlashcardsTable> GetFlashcard()
	//{
	//	return _connection.Table<FlashcardsTable>();
	//}

	//public TableQuery<byte[]> GetFlashcards()
	//{
	//	return _connection.Table<FlashcardsTable>().Select(x => x.ImageData);
	//}

	//public Person CreatePerson()
	//{
	//	var p = new Person
	//	{
	//		Name = "Johnny",
	//		Surname = "Mnemonic",
	//		Age = 21
	//	};
	//	_connection.Insert(p);
	//	return p;
	//}
}
