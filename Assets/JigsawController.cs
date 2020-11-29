using System.Collections;
using System.Collections.Generic;
using VacuumShaders.TextureAdjustments;
using VacuumShaders.TextureExtensions;
using UnityEngine;

public class JigsawController : MonoBehaviour
{
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

                texture.ResizePro(1920, 1080);

                FindObjectOfType<PuzzleImage>().SetImage(texture);
            }
        }, "Select an image", "image/*");
        Debug.Log("Permission result: " + permission);
        FindObjectOfType<SceneLoader>().CreateJigsawPuzzleScene();
    }
}
