using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	public Transform shotSpawn;
	float timer;
	bool Aggro = false;
	public GameObject Player;
	public GameObject shot;
	public float timeBetweenBullets = 1.5f;
	EnemyHealth EnemyHealth;
	PlayerHealth playerHealth;
	float Health;
	// Use this for initialization
	void Start () {
		EnemyHealth = GetComponent <EnemyHealth> ();
		Health = EnemyHealth.currentHealth;	
		playerHealth = Player.GetComponent <PlayerHealth> ();
	}
	Vector3 movement;
	void OnTriggerEnter (Collider other)
	{
		// If the entering collider is the player...
		if (other.tag == "Bolt") {
			Aggro = true;
			transform.position -= transform.forward * Time.deltaTime * 5f;
		} 
	}
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevel == 1) {
						timer += Time.deltaTime;
						float distance = Vector3.Distance (Player.transform.position, transform.position);
						if (playerHealth.currentHealth <= 0) {
								Aggro = false;
						} else if (distance <= 10) {
								Aggro = true;
						}
						if (Aggro == true) {
								if (EnemyHealth.currentHealth > 0 && distance >= 11) {
										rigidbody.velocity = transform.forward * 3.0f;
								} else {
										rigidbody.velocity = transform.forward * 0.0f;
								}
				
								if ((timer >= timeBetweenBullets) && EnemyHealth.currentHealth > 0) {
										Shoot ();
										Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
								}
						}
				} else if (Application.loadedLevel == 5) {
					rigidbody.velocity = transform.forward * 5.0f;

				}
		if (Player != null) {
			transform.LookAt(Player.transform);
		}
		

	}
	void Shoot(){
		timer = 0f;
	
	}
}
