using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {
	public Transform shotSpawn;
	public GameObject shot;
	public float timeBetweenBullets;
	public GUIText directionText;
	float timer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (Input.GetButton ("Fire1") && timer>= timeBetweenBullets) {//Time.time > nextFire ) {
			directionText.text = "";
			if (Application.loadedLevelName == "Level 2") { 
				//transform.position += transform.forward * Time.deltaTime * 17f;
				
			}
			else {


			
			Shoot();
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			transform.position -= transform.forward * Time.deltaTime * 7f;
			}
		}
	}
	
	void Shoot(){
		timer = 0f;
	
	}
}
