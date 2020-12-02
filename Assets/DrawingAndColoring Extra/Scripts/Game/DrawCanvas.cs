using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace WIL.DrawingAndColoring.Logic
{
    [DisallowMultipleComponent]
    public class DrawCanvas : MonoBehaviour
    {

        public static DrawCanvas instance;

        // Use this for initialization
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                //Set up the render camera of the Canvas
                Canvas canvas = instance.GetComponent<Canvas>();
                if (canvas.worldCamera == null)
                {
                    canvas.worldCamera = Camera.main;
                }
                Destroy(gameObject);
            }
        }
    }
}
