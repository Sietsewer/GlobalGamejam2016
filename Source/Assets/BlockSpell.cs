using UnityEngine;
using System.Collections;

public class BlockSpell : MonoBehaviour {

	public float range;
	public float coolDown = 1.0f;
	public float duration = 3.0f;
	public float lastCooldownStart = 0.0f;

	public void tryCast(){
		if(Time.time - lastCooldownStart > coolDown){
			lastCooldownStart = Time.time;
			closestDoor ().doorBlocker.blockDoor (duration);
		}
	}

	private Door closestDoor(){
		float closestRange = float.MaxValue;
		Door closestDoor = null;
		Vector3 posNow = transform.position;
		foreach (Door d in Door.allDoors) {
			float distance = Vector3.Distance (posNow, d.landingPosition.position);
			if (distance < closestRange) {
				closestRange = distance;
				closestDoor = d;
			}
		}
		return closestDoor;
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.F2)){
			tryCast ();
		}
	}
}
