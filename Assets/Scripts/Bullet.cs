using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public GameObject sparkles;

	public float speed;
	public float lifeTime;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward*speed*Time.deltaTime);
	}

	void OnCollisionEnter(Collision collision){
		//Instantiate (sparkles, collision.contacts, collision.contacts.);
	}
}
