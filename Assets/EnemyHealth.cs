using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int startingHealth = 40;          // The amount of health the enemy starts the game with.
	public int currentHealth;                    // The current health the enemy has.
	public float sinkSpeed = 2.5f;           // The speed at which the enemy sinks through the floor when dead.

	CapsuleCollider capsuleCollider;     // Reference to the capsule collider.
	bool isDead;                                  // Whether the enemy is dead.
	bool isSinking;                               // Whether the enemy has started sinking through the floor.
	Rigidbody rigidBody;
	public GUIText enemyText;
	GameController gameController;
	public GameObject GameControllerObject;
	void Awake ()
	{
		capsuleCollider = GetComponent <CapsuleCollider> ();
		// Setting the current health when the enemy first spawns.
		currentHealth = startingHealth;
		rigidBody = GetComponent <Rigidbody> ();
		gameController = GameControllerObject.GetComponent <GameController> ();
	}

	void Update ()
	{
		// If the enemy should be sinking...
		if(isSinking)
		{
			// ... move the enemy down by the sinkSpeed per second.
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		// If the entering collider is the player...
		if (other.tag == "Player") {
			TakeDamage(10);
		} else if (other.tag == "Bolt") {
			Destroy (other.gameObject);
			TakeDamage (10);
			
	
		}
	}

	public void TakeDamage (int amount)
	{
		// If the enemy is dead...
		if(isDead)
			// ... no need to take damage so exit the function.
			return;
		
		// Reduce the current health by the amount of damage sustained.
		currentHealth -= amount;

		if(currentHealth <= 0)
		{
			gameController.enemyCount -= 1;
			enemyText.text = "Enemies: " + gameController.enemyCount;
			// ... the enemy is dead.
			Death ();
			if (gameController.enemyCount == 0) {
				gameController.enemyCount = -1;
				Instantiate (boss, boss.transform.position, boss.transform.rotation);
			}
			
		}
	}
	public GameObject boss;
	void Death ()
	{
		// The enemy is dead.
		isDead = true;
		
		// Turn the collider into a trigger so shots can pass through it.
		capsuleCollider.isTrigger = true;
		StartSinking ();
	
	}
	
	public void StartSinking ()
	{
	
		// Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
		GetComponent <Rigidbody> ().isKinematic = true;

		isSinking = true;
		
		// After 2 seconds destory the enemy.
		Destroy (gameObject, 2f);
	}
}