using UnityEngine;
using System.Collections;
using Player;

public class StunSpell : MonoBehaviour {
	public GameObject stunEffectPrefab;
	public float coolDown = 2.0f;
	public float duration = 3.0f;
	private float spellStartTime = 0.0f;
	private float cooldownStartTime = 0.0f;

	private const string saferoomTag = "saferoom";

	private PlayerController player;

	private SpellState spellState = SpellState.ready;
	void Awake(){
		// Make instance of prefab
		spellObject = GameObject.Instantiate (stunEffectPrefab);
		spellObject.SetActive (false);
		player = gameObject.GetComponent <PlayerController> ();
	}

	public void tryCast(){
		switch (spellState) {
		case SpellState.ready:
			castSpell ();
			break;
		case SpellState.cooldown:
			break;
		case SpellState.cast:
			break;
		}
	}
	GameObject spellObject;
	private void castSpell(){
		cooldownStartTime = Time.time;
		StartCoroutine (spellCoroutine());
	}

	private IEnumerator spellCoroutine (){
		if (player.currentTile.tag == saferoomTag) {
			return true;
		}

		// Start cast period.
		spellState = SpellState.cast;
		spellStartTime = Time.time;

		// Set position of spell and activate it
		spellObject.transform.position = player.currentTile.effectPoint.position;

		spellObject.SetActive (true);

		// Loop until spell duration past
		yield return null;
		while(Time.time - spellStartTime < duration){
			yield return null;
		}

		// Turn off spell
		spellObject.SetActive (false);

		// Start cooldown period.
		spellState = SpellState.cooldown;

		// Set cooldown start time
		cooldownStartTime = Time.time;

		// Loop until cooldown past
		while(Time.time - cooldownStartTime < coolDown){
			yield return null;
		}

		// Set spell to ready
		spellState = SpellState.ready;
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.F1)){
			tryCast ();
		}
	}

	private enum SpellState{
		cast, cooldown, ready
	}
}
