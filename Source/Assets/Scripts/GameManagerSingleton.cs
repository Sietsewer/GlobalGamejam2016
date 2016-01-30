using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerSingleton : MonoBehaviour {

	//protect the init
	protected GameManagerSingleton() {}
	//Shared instance
	public static GameManagerSingleton sharedInstance;

	public float timer = 100;
	public Text timerText;
	bool started;

	void Awake () {

		// if the singleton hasn't been initialized yet
		if (sharedInstance != null && sharedInstance != this) 
		{
			Destroy(this.gameObject);
			return;
		}

		sharedInstance = this;
		DontDestroyOnLoad( this.gameObject );
	}

	// Use this for initialization
	void Start () {
		//Find is very slow.. 
		timerText = GameObject.Find("TimerText").GetComponent<Text>();

		//Game has started
		started = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!started)
			return;

		//Setting the timer text and 
		UpdateTimer();

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
}
