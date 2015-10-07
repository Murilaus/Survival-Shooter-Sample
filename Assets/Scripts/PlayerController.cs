using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject camera;
	public Rigidbody rb;

	public float cameraSensitivity;

	public float speed;

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

		//Rotates the player
		float rotationY = Input.GetAxis ("Mouse X");
		Vector3 playerRotation = transform.up * rotationY;

		RotatePlayer (playerRotation);

		//Rotates the camera
		float rotationX = Input.GetAxis ("Mouse Y");
		Vector3 cameraRotation = Vector3.right * -rotationX;

		RotateCamera (cameraRotation);
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

}
