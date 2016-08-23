using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {

	public Transform target;
	public float smoothTime = 0.3f;
	Vector3 deltaPos;
	Vector3 lastPos;

	private Vector3 velocity = Vector3.zero;

	void Start () {
		lastPos = target.position;
	}

	void Update () {
		Vector3 goalPos = target.position;
		deltaPos = goalPos - lastPos;
		goalPos.z = transform.position.z;
		//deltaPos = AdjustForMovement (deltaPos);
		transform.position = Vector3.SmoothDamp (transform.position, goalPos, ref velocity, smoothTime);
	}

	/*
	Vector3 AdjustForMovement(Vector3 delta) {
		Vector3 adjustmentVector = new Vector3 ();
		adjustmentVector.x = delta.x > 0 ? 3 : delta.x < 0 ? -3 : 0;
		adjustmentVector.y = delta.y > 0 ? 3 : delta.y < 0 ? -3 : 0;
		adjustmentVector.z = 0;
		return adjustmentVector;
	}
	*/
}
