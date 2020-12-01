﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace WIL.DrawingAndColoring.Logic
{
	[DisallowMultipleComponent]
	public class DrawingContents : MonoBehaviour {

		/// <summary>
		/// The parts colors of the shape.
		/// </summary>
		public Hashtable shapePartsColors = new Hashtable();

		/// <summary>
		/// The parts sorting order of the shape.
		/// </summary>
		public Hashtable shapePartsSortingOrder = new Hashtable();

		/// <summary>
		/// The current sorting order of Drawing Content.
		/// </summary>
		public int currentSortingOrder;

		/// <summary>
		/// The sorting order of the last filled/painted part.
		/// </summary>
		public int lastPartSortingOrder;

		void Start(){
			currentSortingOrder = 0;
		}
	}
}
