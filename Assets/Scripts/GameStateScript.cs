using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class GameStateScript : MonoBehaviour {
	public float gameSpeed = 0.1f;
	public int scores { get; protected set; }
	public bool gameOnPause;

	public void SetGameSpeedByAlcohol(float alcDegree){
		if (alcDegree > 100){
			gameSpeed = 0.2f;
			return;
		}
		if (alcDegree <= 0) {
			gameSpeed = 0.1f;
			return;
		}
		gameSpeed = 0.1f + alcDegree / 1000;
	}

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		gameOnPause = false;
	}

	void FixedUpdate(){
		scores += Convert.ToInt32(!gameOnPause) * (int) Math.Round (Time.fixedDeltaTime * gameSpeed * 500, 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RestartGame(){
		int sceneIndex = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (sceneIndex);
	}

	public void ShowDialog(){
		Time.timeScale = 0;
		gameOnPause = true;
		GUI.Window (0, new Rect (200, 200, Screen.width / 2 - 100, Screen.height / 2 - 100), DrawWindow, "WAISTED");
	}

	public void DrawWindow(int id){
		if (GUI.Button (new Rect (100, 30, 100, 30), "Restart now")) {
			RestartGame ();
		}
	}
}