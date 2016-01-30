using UnityEngine;
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

		// Use this for initialization
		void Start () {
			_rigidbody = GetComponent<Rigidbody>();
		}
		
		// Update is called once per frame
		void Update () {
		
			//player movement
			transform.Translate( GetXAxis(player) * Time.deltaTime * speed, 0, GetYAxis(player) * Time.deltaTime * speed);

			//player jumping
			if (JumpButtonPressed(player)) {
				if (!_jumping) {
					Debug.Log("Player " + player.ToString() + " jump");
					Jump();
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

			if (other.tag == "floor") {
				_jumping = false;
			}
		}
	}
}