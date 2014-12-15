using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(15,30,45) * 3 * Time.deltaTime);
		rigidbody.velocity = transform.forward * 6.0f;
		if (gameObject.transform.position.y <= 2.5) {
			Destroy (gameObject);
			
		}
	}
}
