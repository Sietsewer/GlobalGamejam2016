using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LevelGrid;

public class Door : MonoBehaviour {
	public Door linked;

	public bool canRandomLink = true;
	public Tile tile;

	// List of doors for fast references
	public static List<Door> allDoors = new List<Door>();

	public void Start(){
		if (canRandomLink && linked == null) {
			randomLink (this);
		}
	}


	public void Awake(){
		// Link tile in parent to door
		tile = transform.GetComponentInParent<Tile> ();

		// Build list of all doors
		allDoors.Add (this);

		// If door can be randomly linked, do so
		if (canRandomLink && linked == null)
			canidates.Add (this);
	}
		
	public void OnDestroy(){
		// When door is removed, remove it from the list
		allDoors.Remove (this);

		// Also remove it from link canidates
		if (canidates != null && linked == null && canRandomLink)
			canidates.Remove (this);
	}

	public void OnTriggerEnter(Collider other){

		//TODO: add portaling magicu
	}

	private static System.Random r = new System.Random();

	/// <summary>
	/// Randomly link door to other door that hasn't been assigned.
	/// </summary>
	/// <param name="tp">Tp.</param>
	public static void randomLink (Door tp){
		if (canidates.Count () == 2) {
			tp.linked = canidates [0] == tp ? canidates [1] : canidates [0];
		} else {
			
			List<Door> newCanidates = canidates
			.Where (a => a != tp)
			.Where (d => d.tile != tp.tile)
			.Where (e => !e.tile.linkedTiles.Contains (tp.tile)).ToList ();
			tp.linked = newCanidates.ElementAt (r.Next (0, newCanidates.Count ()));
		}
		tp.linked.linked = tp;

		tp.tile.linkedTiles.Add (tp.linked.tile);
		tp.linked.tile.linkedTiles.Add (tp.tile);
		Debug.DrawLine (tp.transform.position, tp.linked.transform.position, Color.red, float.MaxValue);

		canidates.Remove (tp);
		canidates.Remove (tp.linked);
	}

	private static List<Door> canidates = new List<Door>();
}