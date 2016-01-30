using UnityEngine;
using System.Collections;

public class DoorLight : MonoBehaviour {

	public static float maxDist = 1.0f;
	public static float minIntensity = 0.0f;
	public static float maxIntensity = 3.76f;

	new public Light light;
	public Door door;

	void OnAwake(){
		// Look sideways for door
		door = gameObject.GetComponent <Door> ();
		// Look down for light
		light = gameObject.GetComponentInChildren <Light> ();


	}

	public void setLight (float distance, bool dontLight = false){
		DoorLight otherLight = door.linked.doorLight;

		if (dontLight) {
			otherLight.light.intensity = 0; 
			otherLight.enabled = false;
		} else {
			float intensity = Mathf.Clamp (distance, 0.0f, maxDist);
			intensity = (intensity * (maxIntensity - minIntensity)) + minIntensity;
			otherLight.light.intensity = intensity;
		}
	}
}
