using UnityEngine;
using System.Collections;
using Player;
using InputManager;

namespace Player {
	public class PlayerController : InputController {

		public int player = 1;
		public float speed = 1.0f;

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
		
			transform.Translate( GetXAxis(player) * Time.deltaTime * speed, 0, GetYAxis(player) * Time.deltaTime * speed);

		}
	}
}