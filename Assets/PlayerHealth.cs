using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 100;                            // The amount of health the player starts the game with.
	public int currentHealth;                                   // The current health the player has.
	public GUIText healthText;
	                 
	PlayerMovement playerMovement;                              // Reference to the player's movement.
	PlayerShooting playerShooting;                              // Reference to the PlayerShooting script.
	bool isDead;                                                // Whether the player is dead.
	bool damaged;                                               // True when the player gets damaged.
	
	
	void Awake ()
	{
		// Setting up the references.
		
		playerMovement = GetComponent <PlayerMovement> ();
		playerShooting = GetComponentInChildren <PlayerShooting> ();
		
		// Set the initial health of the player.
		currentHealth = startingHealth;
	}
	
	void OnTriggerEnter (Collider other)
	{
		// If the entering collider is the player...
		if (other.tag == "EnemyBolt") {
			
			Destroy(other.gameObject);
			TakeDamage(10);
		} 
		if (other.tag == "Enemy") {
			TakeDamage(10);
		} 
		if (other.tag == "Capsule" && currentHealth < 100) {
			TakeDamage(-5);
		}
	}
	IEnumerator MyMethod2() {
		yield return new WaitForSeconds(3);
		Application.LoadLevel ("GameOver");

		
		
	}
	void Update ()
	{
		// If the player has just been damaged...
		if(damaged)
		{

		}
		// Otherwise...
		else
		{
			
		}
		
		// Reset the damaged flag.
		damaged = false;
		if (isDead) {
			transform.Translate (-Vector3.up * 2.5f * Time.deltaTime);

				}
	}
	
	
	public void TakeDamage (int amount)
	{
		// Set the damaged flag so the screen will flash.
		damaged = true;
		
		// Reduce the current health by the damage amount.
		currentHealth -= amount;

		healthText.text = "Health: " + currentHealth;
		// If the player has lost all it's health and the death flag hasn't been set yet...
		if(currentHealth <= 0 && !isDead)
		{
			// ... it should die.
			GetComponent <Rigidbody> ().isKinematic = true;
			Death ();
			StartCoroutine (MyMethod2());
		}

		if(Application.loadedLevelName == "Level 5")
		{
			playerMovement.AddSlow();
		}
	}
	
	
	void Death ()
	{
		// Set the death flag so this function won't be called again.
		isDead = true;
		playerMovement.enabled = false;
		playerShooting.enabled = false;
	}       
}