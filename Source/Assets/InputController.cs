using UnityEngine;
using System.Collections;

namespace InputManager {
	public class InputController : MonoBehaviour {

		public float GetXAxis(int player) {
			return Input.GetAxis("Horizontal_" + player.ToString() );
		}

		public float GetYAxis(int player) {
			return Input.GetAxis("Vertical_" + player.ToString() );
		}
			
	}
}
