using UnityEngine;
using System.Collections;

public class SpellCircleEffect : MonoBehaviour {
	public AnimationCurve lightCurve = new AnimationCurve ();
	public Light light;
	public ParticleSystem smoke;
	public ParticleSystem circles;
	public ParticleSystem sparks;

	public float lightTime = 1.0f;


	void Awake(){
		StartCoroutine (startRoutine ());
	}

	IEnumerator startRoutine (){
		float t = 0.0f;
		while (t < lightTime) {
			t += Time.deltaTime;
			light.intensity = lightCurve.Evaluate (t);
			yield return null;
		}
	}
}
