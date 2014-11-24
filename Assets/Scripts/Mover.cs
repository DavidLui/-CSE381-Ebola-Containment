using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public float speed;
	public GameObject capsule;
	// Use this for initialization
	void Start () {
		rigidbody.velocity = transform.forward * speed;
	}
	void OnTriggerEnter (Collider other)
	{
		// If the entering collider is the player...
		if (other.tag == "Wall") {
			Destroy(gameObject);
		} else if (other.tag == "DestructableWall") {
					
			Destroy (gameObject);
			Destroy (other.gameObject);
			float random = Random.Range(-1.0F, 1.0F);
			if (random >= 0) {
				Instantiate (capsule, other.transform.position, other.transform.rotation);

			}
		
		} else if (other.tag == "Bolt" ) {
			Destroy (gameObject);
			
		}

	}

}
