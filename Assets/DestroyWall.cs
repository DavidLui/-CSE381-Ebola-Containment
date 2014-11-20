using UnityEngine;
using System.Collections;

public class DestroyWall : MonoBehaviour {

	public GameObject capsule;

	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter (Collider other)
	{
		// If the entering collider is the player...
		if (other.tag == "Boss") {

		} 

	}
	// Update is called once per frame
	void Update () {
	
	}
}
