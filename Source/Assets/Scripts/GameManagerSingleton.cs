using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum Winner {
	Shaman,
	Players
}

public class GameManagerSingleton : MonoBehaviour {
//
//	//protect the init
//	protected GameManagerSingleton() {}
//	//Shared instance
//	public static GameManagerSingleton sharedInstance;
//


	public float timer = 100;
	public Text timerText, resultText;
	public GameObject resultPanel;
	bool started, end;

	void Awake () {
//
//		// if the singleton hasn't been initialized yet
//		if (sharedInstance != null && sharedInstance != this) 
//		{
//			Destroy(this.gameObject);
//			return;
//		}
//
//		sharedInstance = this;
//		DontDestroyOnLoad( this.gameObject );

		resultPanel.SetActive(false);
	}

	// Use this for initialization
	void Start () {
		if (timerText == null) {
			//Find is very slow.. 
			timerText = GameObject.Find("TimerText").GetComponent<Text>();
		}

		timerText.gameObject.SetActive(false);
		end = false;
	}

	public void StartGame () {
		//Game has started
		timerText.gameObject.SetActive(true);
		started = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!started)
			return;

		//Setting the timer text 
		UpdateTimer();


		if (timer <= 0 && !end) {
			end = true;
			TriggerResultPanel(Winner.Shaman);
		}
	}


	void UpdateTimer () {
		if (timerText == null) 
			return;

		//update the time
		timer -= Time.deltaTime;
		int minutes = (int)Mathf.Floor(timer / 60);
		int seconds = (int)(timer % 60);

		//update the text
		timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
	}

	public void TriggerResultPanel (Winner winner) {

		resultPanel.SetActive(true);

		switch (winner) {
		case Winner.Players:
			resultText.text = "The Players Win!";
			break;
		case Winner.Shaman:
			resultText.text = "The Shaman Wins!";
			break;
		}

	}
}
