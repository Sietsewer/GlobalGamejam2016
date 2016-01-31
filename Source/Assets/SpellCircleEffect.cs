using UnityEngine;
using System.Collections;

public class SpellCircleEffect : MonoBehaviour {
	public AnimationCurve lightCurve = new AnimationCurve ();
	public AnimationCurve lightRange = new AnimationCurve ();
	public Light light;
	public ParticleSystem smoke;
	public ParticleSystem circles;
	public ParticleSystem sparks;

	public float lightTime = 1.0f;


	void OnEnable(){
		StartCoroutine (startRoutine ());
	}

	IEnumerator startRoutine (){
		float t = 0.0f;
		while (t < lightTime) {
			t += Time.deltaTime;
			light.intensity = lightCurve.Evaluate (t);
			light.range = lightRange.Evaluate (t);
			yield return null;
		}
		t = 0.0f;
	}

	void OnDisable(){
		StopAllCoroutines ();
	}
}
