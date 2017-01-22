using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {
	public float fovAngle = 110f;
	public bool playerInSight;
	public Vector3 personalLastSighting;

	private Animator anim;
	private LastPlayerSighting lastPlayerSighting;
	private GameObject player;
	private Animator playerAnim;
	private PlayerHealth playerHealth;
	private HashIDs hash;
	private Vector3 previousSighting;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		lastPlayerSighting = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<LastPlayerSighting> ();
		player = GameObject.FindGameObjectWithTag (Tags.player);
		playerAnim = player.GetComponent<Animator> ();
		playerHealth = player.GetComponent<PlayerHealth> ();
		hash = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<HashIDs> ();

		personalLastSighting = lastPlayerSighting.resetPosition;
		previousSighting = lastPlayerSighting.resetPosition;
	}

	// Update is called once per frame
	void Update () {
		if (lastPlayerSighting.position != previousSighting) {
			personalLastSighting = lastPlayerSighting.position;
		}

		previousSighting = lastPlayerSighting.position;

		if (playerHealth.GetCurrentHealth() > 0f) {
			anim.SetBool (hash.playerInSightBool, playerInSight);
		}
		else {
			anim.SetBool (hash.playerInSightBool, false);
		}
	}
}
