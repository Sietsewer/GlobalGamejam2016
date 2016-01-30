using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LevelGrid {
	[System.Serializable]
	public class Tile : MonoBehaviour {
		/*
		 * NW    NE
		 * 	  []
		 * SW    SE
		 */

		public List<Tile> linkedTiles = new List<Tile>();

		public Tile NorthEast;
		public Tile SouthEast;
		public Tile NorthWest;
		public Tile SouthWest;

		public int indexX = int.MaxValue;
		public int indexZ = int.MaxValue;

		public void init (Grid g){
			
		}
	}
}
