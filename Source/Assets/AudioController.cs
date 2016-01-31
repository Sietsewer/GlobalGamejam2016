using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource) )]
public class AudioController : MonoBehaviour {

	AudioSource audioSource;

	public AudioClip[] soundTracks;

	// Use this for initialization
	void Awake () {
		audioSource = GetComponent<AudioSource>(); 
	}

	void Start () {
		if (soundTracks != null) {
			audioSource.clip = soundTracks[Random.Range(0, soundTracks.Length - 1)];
			audioSource.loop = true;
			audioSource.Play();
		}
	}
}
