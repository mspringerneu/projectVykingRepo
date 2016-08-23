using UnityEngine;
using System.Collections;

public class TestPlayerController : MonoBehaviour {

	Rigidbody rigidbody;
	Vector3 velocity;
	public int speed;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		velocity = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized * speed;
	}

	void FixedUpdate () {
		rigidbody.MovePosition (rigidbody.position + velocity * Time.fixedDeltaTime);
	}
}
