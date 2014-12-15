using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;            // The speed that the player will move at.
	
	Vector3 movement;                   // The vector to store the direction of the player's movement.
	Animator anim;                      // Reference to the animator component.
	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
	int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
	float camRayLength = 100f;          // The length of the ray from the camera into the scene.
	
	public GUIText mutationText;
	public int mutationPoints;

	private int slowTimer = 0;
	// Use this for initialization
	void Start () {
		mutationPoints = 0;
	}
	void Awake ()
	{
		// Create a layer mask for the floor layer.
		floorMask = LayerMask.GetMask ("Floor");
		
		playerRigidbody = GetComponent <Rigidbody> ();
		if (Application.loadedLevel == 1) {
			//transform.rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
		}
		else {
			//transform.rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;
		}
	}
	
	void Update() {
		if (Application.loadedLevel == 5
		    ) {
			if (transform.position.y <= 0) {
				Application.LoadLevel (3);

			}			rigidbody.velocity = transform.forward * 3.0f;


		}
		if (Application.loadedLevelName == "Level 2") {
			if (transform.position.y <= 0) {
				Application.LoadLevel (3);
				
			}	

		}

	}
	void FixedUpdate ()
	{
		if (Application.loadedLevelName == "Level 3") {


			Vector3 pose = transform.position;
			if (Input.GetKeyDown("d")) {
				if (transform.position.x >= -1
				    && transform.position.x <= 1) {
					pose.x = 5.7f;
				}
				else if (transform.position.x <= -5.3) {
					pose.x = 0;

				}
			}
			if (Input.GetKeyDown("a")) {
				if (transform.position.x >= -1
				    && transform.position.x <= 1) {
					pose.x = -6;
				}
				else if (transform.position.x >= 5.5) {
					pose.x = 0;
				}

			}
			transform.position = pose;
		}
		else {
			// Store the input axes.
			float h = Input.GetAxisRaw ("Horizontal");
			float v = Input.GetAxisRaw ("Vertical");
			
			Move (h, v);
			
			// Turn the player to face the mouse cursor.
			Turning ();

			if(slowTimer > 0)
			{
				slowTimer--;
			}
			else
			{

			}
		}
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Wall") {
		} 
		if (other.tag == "Capsule") {
			mutationPoints += 1;
			Destroy (other.gameObject);
			mutationText.text = "Blood Capsules: " + mutationPoints;
			speed +=.15f;
		} 
	}
	void Move (float h, float v)
	{
		// Set the movement vector based on the axis input.
		movement.Set (h, 0f, v);
		
		// Normalise the movement vector and make it proportional to the speed per second.
		movement = movement.normalized * speed * Time.deltaTime;

		if(slowTimer > 0) movement *= 0.5f;
		
		// Move the player to it's current position plus the movement.
		playerRigidbody.MovePosition (transform.position + movement);
		
	}

	void Turning ()
	{
		// Create a ray from the mouse cursor on screen in the direction of the camera.
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		// Create a RaycastHit variable to store information about what was hit by the ray.
		RaycastHit floorHit;
		
		// Perform the raycast and if it hits something on the floor layer...
		if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
		{
			// Create a vector from the player to the point on the floor the raycast from the mouse hit.
			Vector3 playerToMouse = floorHit.point - transform.position;
			
			// Ensure the vector is entirely along the floor plane.
			playerToMouse.y = 0f;
			
			// Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			
			// Set the player's rotation to this new rotation.
			playerRigidbody.MoveRotation (newRotation);
		}
	}
	
	public void AddSlow()
	{
		slowTimer = 120;
	}
}