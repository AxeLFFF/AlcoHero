using UnityEngine;
using System.Collections;

public class AlcoholScript : MonoBehaviour {
	private GameStateScript gameStateScr;

	public GameObject gameState;
	public float alcoEffect;

	// Use this for initialization
	void Start () {
		gameState = GameObject.Find ("GameState");
		gameStateScr = gameState.GetComponent<GameStateScript> ();
	}

	void FixedUpdate(){
		transform.position = new Vector3 (transform.position.x - gameStateScr.gameSpeed, transform.position.y, transform.position.z);
		if (transform.position.x < -13) {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
