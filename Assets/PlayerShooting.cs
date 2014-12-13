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
		Debug.Log (timer);
		if (Input.GetButton ("Fire1") && timer>= timeBetweenBullets) {//Time.time > nextFire ) {
			directionText.text = "";
			Shoot();
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
	}
	
	void Shoot(){
		timer = 0f;
	
	}
}
