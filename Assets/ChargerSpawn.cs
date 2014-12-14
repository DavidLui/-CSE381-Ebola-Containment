using UnityEngine;
using System.Collections;

public class ChargerSpawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public Transform transform2;
	public Transform transform3;
	public Transform transform4;
	public Transform Player;
	public GameObject EnemyCharger;
	// Update is called once per frame
	void OnCollisionEnter (Collision other) {
		//Application.LoadLevel(6);
	
	
	}
	void Update () {
		if (transform.position.z > 57) {
			Application.LoadLevel ("Level 4 Loader");

		}
		Vector3 player = Player.position;
		Vector3 pos = transform.position;
		pos.z = player.z + 15f;
		transform.position = pos;
		float random = Random.Range(-1.0F, 1.0F);
		if (random > 0 && random < .01) {
			Instantiate (EnemyCharger, transform2.position, transform2.rotation);
		}
		if (random > .02 && random < .03) {
			Instantiate (EnemyCharger, transform3.position, transform3.rotation);
		}
		if (random > .04 && random < .05) {
			Instantiate (EnemyCharger, transform4.position, transform4.rotation);
		}

		
		
		
	}
	
}
