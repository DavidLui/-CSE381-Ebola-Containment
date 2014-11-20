using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 100;                            // The amount of health the player starts the game with.
	public int currentHealth;                                   // The current health the player has.
	public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
	public GUIText healthText;
	
	Animator anim;                                              // Reference to the Animator component.
                              
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
			TakeDamage(-1);
		}
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
			Death ();
		}
	}
	
	
	void Death ()
	{
		// Set the death flag so this function won't be called again.
		isDead = true;
		Application.LoadLevel ("GameOver");
		playerMovement.enabled = false;
		playerShooting.enabled = false;
	}       
}