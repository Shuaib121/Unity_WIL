using UnityEngine;
using System.Collections;

namespace WIL.DrawingAndColoring.Logic
{
	[DisallowMultipleComponent]
	public class AudioSources : MonoBehaviour
	{

		/// <summary>
		/// The loading canvas instance.
		/// </summary>
		public static AudioSources audioSourcesInstance;
	
		// Use this for initialization
		void Awake ()
		{
			if (audioSourcesInstance == null) {
				audioSourcesInstance = this;
				DontDestroyOnLoad (gameObject);
			} else {
				Destroy (gameObject);
			}
		}
	}
}
