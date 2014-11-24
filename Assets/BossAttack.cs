using UnityEngine;
using System.Collections;

public class BossAttack : MonoBehaviour {
	Transform playerTransform;
	public Transform shotSpawn;
	public Transform shotSpawn2;
	public Transform shotSpawn3;
	public Transform shotSpawn4;
	public Transform shotSpawn5;
	public Transform shotSpawn6;
	public Transform shotSpawn7;
	public GameObject shot;
	public int BossHP;
	// Use this for initialization
	void Start () {
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		BossHP = 100;
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(playerTransform);
		if (BossHP <= 60) {
			Application.LoadLevel (0);
		}
	}
	public GameObject capsule;
	void OnCollisionEnter (Collision other) {
			
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			Instantiate (shot, shotSpawn.position, shotSpawn2.rotation);
			Instantiate (shot, shotSpawn.position, shotSpawn3.rotation);
			Instantiate (shot, shotSpawn.position, shotSpawn4.rotation);
			Instantiate (shot, shotSpawn.position, shotSpawn5.rotation);
			Instantiate (shot, shotSpawn.position, shotSpawn6.rotation);
			Instantiate (shot, shotSpawn.position, shotSpawn7.rotation);

			StartCoroutine(MyMethod());
			
	
	
	}
	void OnTriggerEnter (Collider other) {
		if (other.tag == "DestructableWall") {
			Destroy (other.gameObject);

		}
		if (other.gameObject.tag == "Bolt") {
			BossHP -= 10;
			Destroy (other.gameObject);
		}
		if (other.gameObject.tag == "Capsule") {
		float random = Random.Range(-1.0F, 1.0F);
		if (random >= 0) {
			Instantiate (capsule, other.transform.position, other.transform.rotation);

		}
		}
		
	}
	IEnumerator MyMethod() {
		Debug.Log("Before Waiting 2 seconds");
		yield return new WaitForSeconds(2);
		rigidbody.velocity = Vector3.up * 20 + transform.forward * 3.0f;

		Debug.Log("After Waiting 2 Seconds");
	}
		
	
}
