using UnityEngine;
using System.Collections;

namespace LevelGrid {
	[System.Serializable]
	public class Tile : MonoBehaviour {
		/*
		 * NW    NE
		 * 	  []
		 * SW    SE
		 */

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
