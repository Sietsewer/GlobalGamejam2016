using UnityEngine;
using System.Collections;

public enum Diamond {
	blue,
	red
}

public class Altar : MonoBehaviour {

	public GameManagerSingleton gameManager;
	public Texture emptyTotum, BlueTotem, RedTotem, fullTotem;
	public Material material;

	void Awake(){
		material.mainTexture = emptyTotum;
	}

	//Triggered through the players
	public void DiamondRetrieved (Diamond diamond) {
		switch (diamond) {
		case Diamond.blue:

			if (material.mainTexture != RedTotem) {
				material.mainTexture = BlueTotem;
			} else {
				material.mainTexture = fullTotem;
				gameManager.TriggerResultPanel(Winner.Players);
			}

			break;
		case Diamond.red:
			Debug.Log ("debug");

			if (material.mainTexture != BlueTotem) {
				material.mainTexture = RedTotem;
			} else {
				material.mainTexture = fullTotem;
				gameManager.TriggerResultPanel(Winner.Players);
			}

			break;
		}

	}
}
