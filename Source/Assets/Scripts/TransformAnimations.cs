using UnityEngine;
using System.Collections;
using Player;

public class TransformAnimations {
	public static void animatePlayer(PlayerController pc, Vector3 start, Vector3 end){
		pc.StartCoroutine (forcedMove_co (pc, start, end));
	}

	// Animates the PlayerCharcter with a smoothDamp
	static IEnumerator forcedMove_co (PlayerController pc, Vector3 begin, Vector3 end){
		Rigidbody rb = pc.GetComponent<Rigidbody> ();
		//rb.detectCollisions = false;
		rb.isKinematic = true;
		pc.forcedMove = true;
		Vector3 velocity = Vector3.zero;
		float smoothTime = Vector3.Distance (begin, end) / pc.speed;
		float currentDistance = Vector3.Distance (pc.transform.position, end);
		while (currentDistance > 0.05f){
			pc.transform.position = Vector3.SmoothDamp (pc.transform.position, end, ref velocity, smoothTime);
			yield return null;
			currentDistance = Vector3.Distance (pc.transform.position, end);
		}
		pc.forcedMove = false;
		//rb.detectCollisions = true;
		rb.isKinematic = false; 

	}
}
