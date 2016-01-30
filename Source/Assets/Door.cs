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
		// Randomly link all portals
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
		// If there are two canidates left, just link them. No biggie if they are in the same room.
		if (canidates.Count () == 2) {
			tp.linked = canidates [0] == tp ? canidates [1] : canidates [0];
		} else {
			// Using Linq, check the following:
			List<Door> newCanidates = canidates
				.Where (a => a != tp) // Don't link with yourself
				.Where (d => d.tile != tp.tile) // Don't link in the same tile
				.Where (e => !e.tile.linkedTiles.Contains (tp.tile)).ToList (); // Don't link with a previously linked to tile
			tp.linked = newCanidates.ElementAt (r.Next (0, newCanidates.Count ())); // Select a random index of the collection
		}
		// Link door to door
		tp.linked.linked = tp;

		// Set up tile refrences
		tp.tile.linkedTiles.Add (tp.linked.tile);
		tp.linked.tile.linkedTiles.Add (tp.tile);

		// Debug line that represent a link
		Debug.DrawLine (tp.transform.position, tp.linked.transform.position, Color.red, float.MaxValue);

		// Remove from canidates
		canidates.Remove (tp);
		canidates.Remove (tp.linked);
	}

	// Canidates for door matching
	private static List<Door> canidates = new List<Door>();
}