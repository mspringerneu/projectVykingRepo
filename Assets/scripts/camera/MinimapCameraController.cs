using UnityEngine;
using System.Collections;

public class MinimapCameraController : MonoBehaviour {

	public Transform target;
	public float smoothTime = 0.3f;

	int[] maxFollow = {-36, 36, -85, 85};  // [minX, maxX, minY, maxY]

	private Vector3 velocity = Vector3.zero;

	void Update () {
		Vector3 goalPos = target.position;
		goalPos.z = transform.position.z;
		transform.position = Vector3.SmoothDamp (EnsureBoundaries (transform.position), EnsureBoundaries (goalPos), ref velocity, smoothTime);
	}

	Vector3 EnsureBoundaries(Vector3 pos) {
		Vector3 vec = new Vector3 ();
		// ensure x boundary 
		if (pos.x < maxFollow[0]) {
			vec.x = maxFollow [0];
		}
		else if (pos.x > maxFollow[1]) {
			vec.x = maxFollow [1];
		}
		else {
			vec.x = pos.x;
		}

		// ensure y boundary
		if (pos.y < maxFollow[2]) {
			vec.y = maxFollow [2];
		}
		else if (pos.y > maxFollow[3]) {
			vec.y = maxFollow [3];
		}
		else {
			vec.y = pos.y;
		}

		vec.z = -15;
		return vec;
	}
}
