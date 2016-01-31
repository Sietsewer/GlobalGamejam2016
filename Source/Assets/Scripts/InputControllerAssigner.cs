using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Player;

namespace InputManager {
	public class InputControllerAssigner : MonoBehaviour {

		int numberOfJoysticksConnected = 0;
		List<InputType> availableInputs;
		List<InputController> players; 

		//The canvas which holds the choises
		public GameObject selectionPanel;
		public Dropdown ddPlayer1, ddPlayer2, ddPlayer3;
		public Text text1, text2, text3;
		public Text startButton;
		public GameManagerSingleton gameManagerSingleton;

		void Awake() {
			selectionPanel.SetActive(true);

			//Find all the players in the scene
			UpdatePlayers();

			//Refresh the list of active inputs
			UpdateAvailableInput();

			Debug.Log(numberOfJoysticksConnected.ToString() + " controllers connected");

			//Refresh dropdown list
			ddPlayer1.ClearOptions();
			ddPlayer2.ClearOptions();
			ddPlayer3.ClearOptions();
			UpdateDropDowns();

			for (int i = 0; i <= players.Count - 1; i++) {

				switch (i) {

				case 0:
					text1.text = players[0].name;
					break;
				case 1:
					text2.text = players[1].name;
					break;
				case 2:
					text3.text = players[2].name;
					break;
				default:
					Debug.Log("Error");
					break;

				}

			}
		}

		//Update available input list
		void UpdateAvailableInput () {

			numberOfJoysticksConnected = 0;
			availableInputs = new List<InputType>();

			for(; numberOfJoysticksConnected + 1 <= Input.GetJoystickNames().Length; numberOfJoysticksConnected++) {

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

			availableInputs.Add(InputType.ArrowsLP);
			availableInputs.Add(InputType.UHJKnm);
			availableInputs.Add(InputType.WASDer);

			Debug.Log("amount of available inputs: " + availableInputs.Count.ToString());
//			NotSelectedInputs = new List<InputType>(availableInputs);
		}

		void UpdateDropDowns () {

			List<string> names = new List<string>();

			foreach (InputType type in availableInputs) {
				names.Add(type.ToString());
			}

			ddPlayer1.AddOptions(names);
			ddPlayer2.AddOptions(names);
			ddPlayer3.AddOptions(names);

			ddPlayer1.value = 0;
			ddPlayer2.value = 1;
			ddPlayer3.value = 2;
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

		public void StartGame() 
		{
			if (ddPlayer1.value != ddPlayer2.value && ddPlayer2.value != ddPlayer3.value && ddPlayer3.value != ddPlayer1.value) {

				for (int i = 0; i <= players.Count - 1; i++) {
					
					switch (i) {

					case 0:
						players[0].Init(availableInputs[ddPlayer1.value]);
						break;
					case 1:
						players[1].Init(availableInputs[ddPlayer2.value]);
						break;
					case 2:
						players[2].Init(availableInputs[ddPlayer3.value]);
						break;
					default:
						Debug.Log("Error");
						break;

					}

				}

				selectionPanel.SetActive(false);
				gameManagerSingleton.StartGame();
			} else {
				startButton.text = "Please select different controls";
			}
		}
	}
}
