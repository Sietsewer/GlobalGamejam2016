using UnityEngine;
using System.Collections;

public class DoorLight : MonoBehaviour {

	public static float maxDist = 1.5f;
	public static float minIntensity = 0.5f;
	public static float maxIntensity = 5f;

	new public Light light;
	public Door door;

	void Awake(){
		// Look sideways for door
		door = gameObject.GetComponent <Door> ();
		// Look down for light
		light = gameObject.GetComponentInChildren <Light> ();
		light.enabled = false;

	}

	public void setLight (float distance, bool dontLight = false){
		DoorLight otherLight = door.linked.doorLight;

		if (dontLight) {
			otherLight.light.intensity = 0; 
			otherLight.light.enabled = false;
		} else {
			otherLight.light.enabled = true;
			float intensity = maxDist - Mathf.Clamp (distance, 0.0f, maxDist);
			intensity = (intensity * (maxIntensity - minIntensity)) + minIntensity;
			otherLight.light.intensity = intensity;
		}
	}
}
