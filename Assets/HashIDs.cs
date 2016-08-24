using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour {

	public int dyingState;
	public int deadBool;

	void Awake() {
		dyingState = Animator.StringToHash ("Base Layer.Dying");
		deadBool = Animator.StringToHash ("Dead");
	}
}
