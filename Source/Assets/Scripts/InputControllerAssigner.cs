using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Player;

namespace InputManager {
	public class InputControllerAssigner : MonoBehaviour {

		int numberOfJoysticksConnected = 0;
		List<InputType> availableInputs;
		List<InputController> players; 

		//The canvas which holds the choises
		public GameObject selectionPanel;


		void Awake() {
			//Find all the players in the scene
			UpdatePlayers();

			//Refresh the list of active inputs
			UpdateAvailableInput();

			Debug.Log(numberOfJoysticksConnected.ToString() + " controllers connected");
		}

		//Update available input list
		void UpdateAvailableInput () {

			numberOfJoysticksConnected = 0;
			availableInputs = new List<InputType>();

			for(; Input.GetJoystickNames().Length < numberOfJoysticksConnected; numberOfJoysticksConnected++) {

				switch (numberOfJoysticksConnected) {
				case 0: availableInputs.Add(InputType.JoystickOne);
					break;
				case 1: availableInputs.Add(InputType.JoystickTwo);
					break;
				case 2: availableInputs.Add(InputType.JoystickThree);
					break;
				default:
					Debug.Log("Maximum gamepad support reached");
					break;
				}
			}

			availableInputs.Add(InputType.ArrowsL);
			availableInputs.Add(InputType.UHJKN);
			availableInputs.Add(InputType.WASDSpace);

			Debug.Log("amount of available inputs: " + availableInputs.Count.ToString());
		}

		//Update available players list
		void UpdatePlayers () {

			players = new List<InputController>();


			if (FindObjectOfType<InputController>() != null) { 
				foreach(InputController controller in  FindObjectsOfType<InputController>()) {
					players.Add(controller);
				}
			}

			Debug.Log(players.Count.ToString() + " players active");
		}

		//TODO: Set inputType for the active players



		public void StartGame() {
			selectionPanel.SetActive(false);
			GameManagerSingleton.sharedInstance.StartGame();
		}
	}
}
