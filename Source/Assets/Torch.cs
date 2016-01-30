using UnityEngine;
using System.Collections;
using LevelGrid;
using Player;

public class Torch : MonoBehaviour {

	new Light light;
	//public Tile currentTile;
	public PlayerController playerChacter;
	// Use this for initialization

	void Awake () {
		playerChacter = gameObject.GetComponent<PlayerController> ();
		light = GetComponentInChildren<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerChacter!=null && playerChacter.currentTile != null) {
			foreach (Door d in playerChacter.currentTile.doors) {
				d.doorLight.setLight (Vector3.Distance (transform.position, d.transform.position));
			}
		}
	}
}
