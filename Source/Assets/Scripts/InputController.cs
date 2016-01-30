using UnityEngine;
using System.Collections;

namespace InputManager {
	public class InputController : MonoBehaviour {

		void Start() {
			foreach(string name in Input.GetJoystickNames() ) {
				Debug.Log( name );
			}
		}

		public float GetXAxis(int player) {
			return Input.GetAxis("Horizontal_" + player.ToString() );
		}

		public float GetYAxis(int player) {
			return Input.GetAxis("Vertical_" + player.ToString() );
		}

		public bool JumpButtonPressed(int player) {
			return Input.GetButtonDown("Jump_" + player.ToString());
		}
	}
}
