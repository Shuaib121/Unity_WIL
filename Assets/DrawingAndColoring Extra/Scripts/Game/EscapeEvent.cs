using UnityEngine;
using System.Collections;


namespace WIL.DrawingAndColoring.Logic
{
	using UnityEngine;
	using System.Collections;
	using UnityEngine.Events;

	/// <summary>
	/// Escape or Back event
	/// </summary>
	[DisallowMultipleComponent]
	public class EscapeEvent : MonoBehaviour
	{
		/// <summary>
		/// On escape/back event
		/// </summary>
		public UnityEvent escapeEvent;

		void Update ()
		{
			if (Input.GetKeyDown (KeyCode.Escape)) {
				OnEscapeClick ();
			}
		}

		/// <summary>
		/// On Escape click event.
		/// </summary>
		public void OnEscapeClick ()
		{
			escapeEvent.Invoke ();
		}
	}
}