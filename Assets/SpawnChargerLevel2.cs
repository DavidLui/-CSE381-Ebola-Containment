using UnityEngine;
using System.Collections;

public class SpawnChargerLevel2 : MonoBehaviour {
	public Transform transform1;
	public GameObject charger;
	public GameObject fastCharger;
	// Use this for initialization
	void Start () {
	
	}
	GameController gameController;
	public GameObject GameControllerObject;
	void Awake ()
	{

		gameController = GameControllerObject.GetComponent <GameController> ();
	}

	// Update is called once per frame
	void Update () {
		float random = Random.Range(-1.0F, 1.0F);
		if (random > 0 && random < .02) {
			Instantiate (charger, transform1.position, transform1.rotation);
		}
		if (gameController.yellow == true) {
			if (random > 0.2 && random <= .215) {
				Instantiate (fastCharger, transform1.position, transform1.rotation);
			}

		}
	}
}
