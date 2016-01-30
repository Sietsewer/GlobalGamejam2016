using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace LevelGrid{
	public class Grid : MonoBehaviour {
		public Tile[][] tileGrid;

		// Use this for initialization
		void Start () {
			String rs = "";
			buildGrid ();
			foreach (Tile[] ta in tileGrid) {
				foreach (Tile ti in ta) {
					rs += ti == null ? "O" : "X";
				}
				rs += "\n";
			}
			Debug.Log (rs);
		}

		/// <summary>
		/// Builds the grid.
		/// </summary>
		void buildGrid (){
			// Grab list of all Tiles in scene, then NOT order them by X and Y coordinates.
			List<Tile> tilesInScene = new List<Tile>();
			tilesInScene.AddRange ((Tile[])GameObject.FindObjectsOfType (typeof(Tile)));
			//tilesInScene = tilesInScene.OrderBy (x => x.transform.position.x).ThenBy (y => y.transform.position.y).ToList();

			// Grab grid max values
			int maxX = (int)Mathf.Round(tilesInScene.Max (x => x.transform.position.x));
			int maxZ = (int)Mathf.Round(tilesInScene.Max (z => z.transform.position.z));

			// Grab grid min values
			int minX = (int)Mathf.Round(tilesInScene.Min (x => x.transform.position.x));
			int minZ = (int)Mathf.Round(tilesInScene.Min (z => z.transform.position.z));

			// Calculate lengths arrays should be
			int lengthX = (int)Mathf.Abs (maxX - minX) + 1;
			int lengthZ = (int)Mathf.Abs (maxZ - minZ) + 1;

			// Dimension the grid
			tileGrid = new Tile[lengthX] [];
			for (int i = 0; i < tileGrid.Length; i++) {
				tileGrid [i] = new Tile[lengthZ];
			}

			// Iterate over all tiles in scene to:
			foreach (Tile t in tilesInScene) {
				// Snap all tiles to nearest integer
				t.transform.position = new Vector3 (
					Mathf.Round(t.transform.position.x),
					Mathf.Round(t.transform.position.y),
					Mathf.Round(t.transform.position.z)
				);

				// Determine indeces of tile
				int iX = (int)t.transform.position.x - minX;
				int iZ = (int)t.transform.position.z - minZ;

				// Check if cell hasn't been assigned yet
				if (tileGrid [iX] [iZ] != null) {
					// Destroy GameObject if it already exists
					GameObject.Destroy (tileGrid [iX] [iZ].gameObject);
				}

				// Fill TileGrid with... tiles
				tileGrid [iX] [iZ] = t;

				// Assign indeces to tile
				t.indexX = iX;
				t.indexZ = iZ;

			}
		}
	}
}
