using UnityEngine;
using System.Collections;

namespace InputManager {
	public class InputController : MonoBehaviour {

		int numberOfJoysticksConnected = 0;

		public void Init() {
			foreach(string name in Input.GetJoystickNames() ) {
				Debug.Log( name );
				numberOfJoysticksConnected++;
			}

			Debug.Log(numberOfJoysticksConnected.ToString() + " controllers connected");
		}

		public float GetXAxis(int player) {
			//2 controllers connected or 1 connected and player is 1
			if (numberOfJoysticksConnected >= 2 || (numberOfJoysticksConnected == 1 && player == 1)) {
				
				return Input.GetAxis("Horizontal_" + player.ToString() );

			} else if (numberOfJoysticksConnected == 1 && player == 2) {
				
				//Player 2 when there is 1 or less controllers
				if (Input.GetKey(KeyCode.LeftArrow)) {
					return -1;
				} else if (Input.GetKey(KeyCode.RightArrow)) {
					return 1;
				} else {
					return 0;
				}

			} else {
				switch (player) {

				case 1:

					if (Input.GetKey(KeyCode.LeftArrow)) {
						return -1;
					} else if (Input.GetKey(KeyCode.RightArrow)) {
						return 1;
					} else {
						return 0;
					}

				case 2:

					if (Input.GetKey(KeyCode.A)) {
						return -1;
					} else if (Input.GetKey(KeyCode.D)) {
						return 1;
					} else {
						return 0;
					}

				default:
					
					if (Input.GetKey(KeyCode.LeftArrow)) {
						return -1;
					} if (Input.GetKey(KeyCode.RightArrow)) {
						return 1;
					} else {
						return 0;
					}
				}
			}
		}

		public float GetYAxis(int player) {
			//2 controllers connected or 1 connected and player is 1
			if (numberOfJoysticksConnected >= 2 || (numberOfJoysticksConnected == 1 && player == 1)) {
				
				return Input.GetAxis("Vertical_" + player.ToString() );

			} else if (numberOfJoysticksConnected == 1 && player == 2) {
				
				//Player 2 when there is 1 or less controllers
				if (Input.GetKey(KeyCode.DownArrow)) {
					return -1;
				} else if (Input.GetKey(KeyCode.UpArrow)) {
					return 1;
				} else {
					return 0;
				}

			} else {
				
				switch (player) {

				case 1:

					if (Input.GetKey(KeyCode.DownArrow)) {
						return -1;
					} else if (Input.GetKey(KeyCode.UpArrow)) {
						return 1;
					} else {
						return 0;
					}

				case 2:

					if (Input.GetKey(KeyCode.S)) {
						return -1;
					} else if (Input.GetKey(KeyCode.W)) {
						return 1;
					} else {
						return 0;
					}

				default:

					if (Input.GetKey(KeyCode.DownArrow)) {
						return -1;
					} else if (Input.GetKey(KeyCode.UpArrow)) {
						return 1;
					} else {
						return 0;
					}

				}
			}
		}

		public bool JumpButtonPressed(int player) {
			if (numberOfJoysticksConnected >= 2 || (numberOfJoysticksConnected == 1 && player == 1)) {
				
				return Input.GetButtonDown("Jump_" + player.ToString());

			} else if (numberOfJoysticksConnected == 1 && player == 2) {

				//Player 2 when there is 1 or less controllers
				return Input.GetKey(KeyCode.L);

			} else {
				switch (player) {

				case 1:

					return Input.GetKey(KeyCode.L);

				case 2:

					return Input.GetKey(KeyCode.Space);

				default:

					return Input.GetKey(KeyCode.Space);

				}
			}
		}
	}
}
