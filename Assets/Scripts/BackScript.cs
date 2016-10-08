using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackScript : MonoBehaviour {
	public GameObject gameState;
	public float startX, startY, width;
	const float globWidth = 19.2f;
	const float globHeight = 10.8f;

	private GameStateScript gameStateScr;
	private Text alcoholValue;
	private Text scores;

	// Use this for initialization
	void Start () {
		width = globWidth * transform.lossyScale.x;
		startX = transform.position.x;
		startY = transform.position.y;
		gameStateScr = gameState.GetComponent<GameStateScript> ();
	}

	void FixedUpdate(){
		transform.position = new Vector3 (transform.position.x - gameStateScr.gameSpeed, transform.position.y, transform.position.z);
		if (transform.position.x < startX - width) {
			transform.position = new Vector3 (startX, startY, transform.position.z);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
