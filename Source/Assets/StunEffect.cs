using UnityEngine;
using System.Collections;
using Player;
using System.Collections.Generic;

public class StunEffect : MonoBehaviour {
	public PlayerController player;

	public List<PlayerController> stunnedPlayers = new List<PlayerController> ();

	private const string shamanTag = "shaman";

	void OnTriggerEnter(Collider other){
		player = other.GetComponentInChildren<PlayerController> ();
		if (player != null && other.tag != shamanTag) {
			player.stunned = true;
			stunnedPlayers.Add (player);
		}
	}

	void OnDisable (){
		clearStuns ();
	}
	void OnDestroy(){
		clearStuns ();
	}

	private void clearStuns(){
		foreach (PlayerController pc in stunnedPlayers) {
			pc.stunned = false;
		}
		stunnedPlayers.Clear();
	}
}
