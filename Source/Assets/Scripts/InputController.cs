using UnityEngine;
using System.Collections;
using Player;

namespace InputManager {
	public enum InputType {
		JoystickOne,
		JoystickTwo,
		JoystickThree,
		WASDer,
		ArrowsLP,
		UHJKnm
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

//				Debug.Log(Input.GetAxisRaw("Horizontal_1").ToString());
				return Input.GetAxis("Horizontal_1");

			case InputType.JoystickTwo:

				return Input.GetAxis("Horizontal_2");

			case InputType.JoystickThree:

				return Input.GetAxis("Horizontal_3");

			case InputType.WASDer:

				if (Input.GetKey(KeyCode.A)) 
				{
					return -1;
				} else if (Input.GetKey(KeyCode.D)) {
					return 1;
				} else {
					return 0;
				}

			case InputType.ArrowsLP:

				if (Input.GetKey(KeyCode.LeftArrow)) 
				{
					return -1;
				} else if (Input.GetKey(KeyCode.RightArrow)) {
					return 1;
				} else {
					return 0;
				}

			case InputType.UHJKnm:
			
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

			case InputType.WASDer:

				if (Input.GetKey(KeyCode.S)) 
				{
					return -1;
				} else if (Input.GetKey(KeyCode.W)) {
					return 1;
				} else {
					return 0;
				}

			case InputType.ArrowsLP:

				if (Input.GetKey(KeyCode.DownArrow)) 
				{
					return -1;
				} else if (Input.GetKey(KeyCode.UpArrow)) {
					return 1;
				} else {
					return 0;
				}

			case InputType.UHJKnm:

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

		public bool ActionButtonPressed() {

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

			case InputType.WASDer:

				return Input.GetKey(KeyCode.E);

			case InputType.ArrowsLP:

				return Input.GetKey(KeyCode.L); 

			case InputType.UHJKnm:

				return Input.GetKey(KeyCode.N);

			default:

				Debug.Log("default hit for inputcontroller " + this.gameObject.name);
				return false;

			}
		}

		public bool SecondActionButtonPressed() {

			if (!initialised) {
				Debug.Log("player controls not initialised for player " + this.gameObject.name + ". Try initialising in Awake");
				return false;
			}

			switch (_inputType) {

			case InputType.JoystickOne:

				return Input.GetButtonDown("Fire2_1");

			case InputType.JoystickTwo:

				return Input.GetButtonDown("Fire2_2");

			case InputType.JoystickThree:

				return Input.GetButtonDown("Fire2_3");

			case InputType.WASDer:

				return Input.GetKey(KeyCode.R);

			case InputType.ArrowsLP:

				return Input.GetKey(KeyCode.P); 

			case InputType.UHJKnm:

				return Input.GetKey(KeyCode.M);

			default:

				Debug.Log("default hit for inputcontroller " + this.gameObject.name);
				return false;

			}
		}

		public bool JumpButtonPressed () {
			return false;
		}
	}
}
