﻿using UnityEngine;
using System.Collections;
using Player;
using InputManager;

namespace Player {
	public class PlayerController : InputController {

		public int player = 1;
		public float speed = 1.0f;
		public float jumpForce = 10f;

		private bool _jumping = false;
		private Rigidbody _rigidbody;

		public GameObject inventory;

		public bool justEnteredDoor = false;

		// Use this for initialization
		void Start () {
			_rigidbody = GetComponent<Rigidbody>();
			inventory = null;

			base.Init();
		}

		public bool forcedMove {
			get;
			set;
		}

		// Update is called once per frame
		void Update () {
			if (!forcedMove) {
				//player movement
				//transform.Translate (GetXAxis (player) * Time.deltaTime * speed, 0, GetYAxis (player) * Time.deltaTime * speed);
				_rigidbody.velocity = Quaternion.Euler(0,45,0) * new Vector3(GetXAxis (player)  * speed, 0, GetYAxis (player) * speed);
				//player jumping
				if (JumpButtonPressed (player)) {
					if (!_jumping) {
						Debug.Log ("Player " + player.ToString () + " jump");
						Jump ();
					}
				}
			}
		}

		void Jump() {
			_jumping = true;

			_rigidbody.AddForce(Vector3.up * jumpForce);
		}

		//Player in collision with floor reset jump to false
		void OnTriggerEnter(Collider other) {
			Debug.Log(other.name + " collisioned with " + gameObject.name);

			switch (other.tag) {
			case "floor":
				//Reset jumping
				_jumping = false;
				break;
			case "collectible":
				//Store collectible in inventory and destroy the world object
				if (inventory == null) {
					inventory = other.gameObject;
					other.gameObject.SetActive( false );
				}
				break;
			case "altar":
				//check if there is collectible to deliver
				if (inventory != null) {
					//TODO: Trigger point event
					Destroy( inventory );
					inventory = null;
					Debug.Log("Collectible delivered");
				}
				break;
			}
		}

		IEnumerator forcedMove_co (Vector3 begin, Vector3 end){
			Vector3 velocity = Vector3.zero;
			float smoothTime = Vector3.Distance (begin, end) * speed;
			float currentDistance = Vector3.Distance (transform.position, end);
			while (currentDistance > 0.05f){
				Vector3.SmoothDamp (transform.position, end, ref velocity, smoothTime);
				yield return null;
			}
		}
	}
}