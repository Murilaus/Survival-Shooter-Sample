using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject camera;
	public Rigidbody rb;

	public float cameraSensitivity;

	public float runSpeed;
	public float walkSpeed;
	public float speed;

	public float raycastLengh;
	public bool grounded;
	public float jumpIntensity;

	void Awake(){
		rb = GetComponent<Rigidbody> ();
	}

	void Update(){

		//Moves the player
		float moveX = Input.GetAxis ("Horizontal");
		float moveZ = Input.GetAxis ("Vertical");
		Vector3 movement = transform.right*moveX + transform.forward*moveZ;
		movement = movement.normalized;

		Move (movement);

		//Verifies if the player is grounded
		SetGrounded ();

		//Jump if player is grounded
		if(Input.GetButtonDown ("Jump")){
			Jump ();
		}

		//Rotates the player
		float rotationY = Input.GetAxis ("Mouse X");
		Vector3 playerRotation = transform.up * rotationY;

		RotatePlayer (playerRotation);

		//Rotates the camera
		float rotationX = Input.GetAxis ("Mouse Y");
		Vector3 cameraRotation = Vector3.right * -rotationX;

		RotateCamera (cameraRotation);

		//Changes the speed of the player
		if (Input.GetButton ("Run")) {
			speed = runSpeed;
		} else {
			speed = walkSpeed;
		}
	}

	public void Move(Vector3 movement){
		rb.MovePosition (rb.position + movement*speed*Time.deltaTime);
	}

	public void RotatePlayer(Vector3 rotation){
		transform.Rotate (rotation*cameraSensitivity*Time.deltaTime);
	}

	public void RotateCamera(Vector3 rotation){
		camera.transform.Rotate (rotation*cameraSensitivity*Time.deltaTime);
	}

	public void SetGrounded(){
		if (Physics.Raycast (transform.position, -transform.up, raycastLengh)) {
			grounded = true;
		} else {
			grounded = false;
		}
	}

	public void Jump(){
		if(grounded){
			rb.AddForce(new Vector3(0, jumpIntensity, 0));
		}
	}
}
