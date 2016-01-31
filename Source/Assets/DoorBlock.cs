using UnityEngine;
using System.Collections;

public class DoorBlock : MonoBehaviour {

	Door door;
	public GameObject blockCollider;

	public bool isBlocked { get; private set;}

	void Awake(){
		door = GetComponent<Door> ();
	}
	// Use this for initialization
	void Start () {
	
	}

	public void blockDoor(float duration){
		if (!isBlocked && !door.linked.doorBlocker.isBlocked) {
			StartCoroutine (block (duration));
		}
	}

	private IEnumerator block(float duration){
		isBlocked = true;
		float startTime = Time.time;

		// Block doors
		blockCollider.SetActive (true);
		door.linked.doorBlocker.blockCollider.SetActive (true);


		// Wait until time is over
		while(Time.time - startTime < duration){
			yield return null;
		}

		// Unblock doors
		blockCollider.SetActive (false);
		door.linked.doorBlocker.blockCollider.SetActive (false);
		isBlocked = false;
	}
}
