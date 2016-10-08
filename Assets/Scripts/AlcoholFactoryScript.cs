using UnityEngine;
using System.Collections;

public class AlcoholFactoryScript : MonoBehaviour {
	public GameObject beer;
	public GameObject coctail;
	public GameObject shot;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("CreateAlcohol", 5, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreateAlcohol(){
		int n = Random.Range (0, 3);
		switch (n) {
		case 0:
			Instantiate (beer.gameObject);
			break;
		case 1:
			Instantiate (coctail.gameObject);
			break;
		case 2:
			Instantiate (shot.gameObject);
			break;
		default:
			Instantiate (beer.gameObject);
			break;
		}
	}
}
