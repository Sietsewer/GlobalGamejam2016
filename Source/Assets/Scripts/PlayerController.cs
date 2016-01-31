using UnityEngine;
using System.Collections;
using Player;
using InputManager;
using LevelGrid;

namespace Player {
	[RequireComponent (typeof (InputController))]
	public class PlayerController : MonoBehaviour {

		public Tile currentTile;

		[HideInInspector]
		public int player = 1;

		public float speed = 1.0f;
		public float jumpForce = 10f;

		private bool _jumping = false;
		private Rigidbody _rigidbody;

		[HideInInspector]
		public GameObject inventory;
		InputController _inputController;

		private bool activated = false;

		private Animator _animator;

		public bool Shaman = false;

		public void Activate (InputController inputController) {
			_inputController = inputController;
			activated = true;
		}
			
		public bool justEnteredDoor = false;

		// Use this for initialization
		void Start () {
			_animator = GetComponent<Animator>();
			_rigidbody = GetComponent<Rigidbody>();
			inventory = null;

			Grid g = GameObject.FindObjectOfType<Grid> ();
			if (g != null) {
				currentTile = g.closestTo (transform.position);
			}
		}

		public bool forcedMove {
			get;
			set;
		}

		// Update is called once per frame
		void Update () {
			if (!activated)
				return;

			if (!forcedMove) {
				//player movement
				float xAxis = _inputController.GetXAxis ();
				float yAxis = _inputController.GetYAxis ();
				_rigidbody.velocity = Quaternion.Euler(0,45,0) * new Vector3(xAxis  * speed, 0, yAxis * speed);

				//movement animation
				_animator.SetFloat("Forward", Mathf.Clamp( Mathf.Abs( xAxis ) + Mathf.Abs( yAxis ), 0, 1));

				if (xAxis < 0) {
					transform.localRotation = Quaternion.Euler(0, -135, 0);
				} else {
					transform.localRotation = Quaternion.Euler(0, 45, 0);
				}

				//player jumping
				if (_inputController.JumpButtonPressed ()) {
					if (!_jumping) {
						Debug.Log ("Player " + player.ToString () + " jump");
						Jump ();
					}
				}

				//player hoebahoeba
				if (_inputController.ActionButtonPressed () ) {
					_animator.SetBool("Crazy", true);
				} else {
					_animator.SetBool("Crazy", false);
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
				if (inventory == null && !Shaman) {
					inventory = other.gameObject;
					other.gameObject.SetActive( false );
				}
				break;
			case "altar":
				//check if there is collectible to deliver
				if (inventory != null && !Shaman) {
					Destroy( inventory );

					if (inventory.name == "Collectible_Blue") {
						other.gameObject.GetComponent<Altar>().DiamondRetrieved(Diamond.blue);
					} else if (inventory.name == "Collectible_Red") {
						other.gameObject.GetComponent<Altar>().DiamondRetrieved(Diamond.red);
					} else {
						Debug.Log("Error. Name is not correct: " + inventory.name);
					}

					inventory = null;

					Debug.Log("Collectible delivered");
				}
				break;
			case "shaman":
				if (inventory != null && !Shaman) {

					inventory.gameObject.SetActive(true);
					inventory == null;

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
