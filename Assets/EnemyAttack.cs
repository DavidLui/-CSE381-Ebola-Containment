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
		if (Application.loadedLevelName == "Level 3") {
			if (other.tag == "Player") {
				Destroy (gameObject);

			}
		}
		if (Application.loadedLevelName == "Level 2") {
			if (other.tag == "Player") {
				Destroy (gameObject);
				
			}
		}
		if (other.tag == "Bolt") {
			Aggro = true;
			transform.position -= transform.forward * Time.deltaTime * 5f;
		} 

	}

	void Awake() {
		if (Application.loadedLevel == 4) {
			transform.LookAt(Player.transform);	
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
								if (Player != null) {
									transform.LookAt(Player.transform);
								}
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
				
				}
		else if (Application.loadedLevel == 4) {

			rigidbody.velocity = transform.forward * 6.0f;
			if (gameObject.transform.position.y <= 1.2) {
				Destroy (gameObject);

			}
			StartCoroutine(MyMethod());

			
		}
		else if (Application.loadedLevel == 5) {
			float time = Time.timeSinceLevelLoad;
			rigidbody.velocity = transform.forward * (5.0f + (time / 50));
			Vector3 pose = transform.position;
			if ((pose.z + 5f) <= Player.transform.position.z) {
				Destroy (gameObject);
			}
		
		}

		

	}
	IEnumerator MyMethod() {
		Debug.Log("Before Waiting 2 seconds");
		yield return new WaitForSeconds(50);
		Application.LoadLevel ("Level 3 Loader");

		Debug.Log("After Waiting 2 Seconds");
	}
	void Shoot(){
		timer = 0f;
	
	}
}
