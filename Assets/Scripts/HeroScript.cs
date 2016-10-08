using UnityEngine;
using System.Collections;

public class HeroScript : MonoBehaviour {
	public GameObject alcFactory;
	public GameObject gameState;
	public int alcoholResistance = 0;
	public float jumpHigh = 200;

	private float alcoholDegree = 0;
	private bool isHeroAlive = true;
	private bool grounded = true;
	private int jumpCount = 0;
	private Animator anim;
	private AlcoholFactoryScript factoryScr;
	private GameStateScript gameStateScr;
	private bool isJumpingState {
		get { return isJumpingState; }
		set { anim.SetBool ("isJumping", value); }
	}

	void CheckHeroState(){
		if (alcoholDegree >= 100) {
			isHeroAlive = false;
		}
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		factoryScr = alcFactory.GetComponent<AlcoholFactoryScript> ();
		gameStateScr = gameState.GetComponent<GameStateScript> ();
	}
	
	// Update is called once per frame
	void Update(){
		
	}

	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.Space) && jumpCount != 2) {
			jumpCount++;
			grounded = false;
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpHigh / jumpCount));
			isJumpingState = true;
		}
		CheckHeroState ();
	}

	float GetAlcoholEffect(GameObject alcohol){
		AlcoholScript alcScr = alcohol.GetComponent<AlcoholScript> ();
		return alcScr.alcoEffect - alcoholResistance;
	}

	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.name == "land") {
			jumpCount = 0;
			grounded = true;
			isJumpingState = false;
		}
		if (c.gameObject.tag == "alcohol") {
			factoryScr.CreateAlcohol ();
			alcoholDegree += GetAlcoholEffect (c.gameObject);
			gameStateScr.SetGameSpeedByAlcohol (alcoholDegree);
			Destroy (c.gameObject);
		}
	}

	void OnGUI(){
		GUI.Box (new Rect (0, 0, 250, 25), "Alcohol resistance: " + alcoholResistance);
		GUI.Box (new Rect (0, 25, 250, 25), "Alcohol degree: " + alcoholDegree + " / 100 ppm.");
		GUI.Box (new Rect (0, 50, 250, 25), "Scores: " + gameStateScr.scores + " points");
		if (!isHeroAlive) {
			gameStateScr.ShowDialog ();
		}
	}
}
