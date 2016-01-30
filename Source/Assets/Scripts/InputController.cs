using UnityEngine;
using System.Collections;
using Player;

namespace InputManager {
	public enum InputType {
		JoystickOne,
		JoystickTwo,
		JoystickThree,
		WASDSpace,
		ArrowsL,
		UHJKN
	}


	public class InputController : MonoBehaviour {

		private InputType _inputType;
		private bool initialised = false;

		public void Init( InputType inputType ) {

			_inputType = inputType;
			initialised = true;

			this.GetComponent<PlayerController>().Activate(this);

			Debug.Log(name + " initialised with control " + _inputType.ToString());
		}

		public float GetXAxis() 
		{
			if (!initialised) {
				Debug.Log("player controls not initialised for player " + this.gameObject.name + ". Try initialising in Awake");
				return 0f;
			}
			
			switch (_inputType) {

			case InputType.JoystickOne:

				return Input.GetAxis("Horizontal_1");

			case InputType.JoystickTwo:

				return Input.GetAxis("Horizontal_2");

			case InputType.JoystickThree:

				return Input.GetAxis("Horizontal_3");

			case InputType.WASDSpace:

				if (Input.GetKey(KeyCode.A)) 
				{
					return -1;
				} else if (Input.GetKey(KeyCode.D)) {
					return 1;
				} else {
					return 0;
				}

			case InputType.ArrowsL:

				if (Input.GetKey(KeyCode.LeftArrow)) 
				{
					return -1;
				} else if (Input.GetKey(KeyCode.RightArrow)) {
					return 1;
				} else {
					return 0;
				}

			case InputType.UHJKN:
			
				if (Input.GetKey(KeyCode.H)) 
				{
					return -1;
				} else if (Input.GetKey(KeyCode.K)) {
					return 1;
				} else {
					return 0;
				}

				default:

				Debug.Log("default hit for inputcontroller " + this.gameObject.name);
				return 0;

			}
		}

		public float GetYAxis() {

			if (!initialised) {
				Debug.Log("player controls not initialised for player " + this.gameObject.name + ". Try initialising in Awake");
				return 0f;
			}

			switch (_inputType) {

			case InputType.JoystickOne:

				return Input.GetAxis("Vertical_1");

			case InputType.JoystickTwo:

				return Input.GetAxis("Vertical_2");

			case InputType.JoystickThree:

				return Input.GetAxis("Vertical_3");

			case InputType.WASDSpace:

				if (Input.GetKey(KeyCode.S)) 
				{
					return -1;
				} else if (Input.GetKey(KeyCode.W)) {
					return 1;
				} else {
					return 0;
				}

			case InputType.ArrowsL:

				if (Input.GetKey(KeyCode.DownArrow)) 
				{
					return -1;
				} else if (Input.GetKey(KeyCode.UpArrow)) {
					return 1;
				} else {
					return 0;
				}

			case InputType.UHJKN:

				if (Input.GetKey(KeyCode.J)) 
				{
					return -1;
				} else if (Input.GetKey(KeyCode.U)) {
					return 1;
				} else {
					return 0;
				}
			default:

				Debug.Log("default hit for inputcontroller " + this.gameObject.name);
				return 0;

			}
		}

		public bool JumpButtonPressed() {

			if (!initialised) {
				Debug.Log("player controls not initialised for player " + this.gameObject.name + ". Try initialising in Awake");
				return false;
			}

			switch (_inputType) {

			case InputType.JoystickOne:

				return Input.GetButtonDown("Jump_1");

			case InputType.JoystickTwo:

				return Input.GetButtonDown("Jump_2");

			case InputType.JoystickThree:

				return Input.GetButtonDown("Jump_3");

			case InputType.WASDSpace:

				return Input.GetKey(KeyCode.Space);

			case InputType.ArrowsL:

				return Input.GetKey(KeyCode.L); 

			case InputType.UHJKN:

				return Input.GetKey(KeyCode.N);

			default:

				Debug.Log("default hit for inputcontroller " + this.gameObject.name);
				return false;

			}
		}
	}
}
