using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace IndieStudio.DrawingAndColoring.Utility
{
	public class DirtyUtil
	{	
		public static void MarkSceneDirty ()
		{
			#if UNITY_EDITOR
				if(!EditorSceneManager.GetActiveScene().isDirty && !Application.isPlaying){
					EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene()); 
				}
			#endif
		}
	}
}