using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float playerHealth = 100f;
	public float resetAfterDeathTime = 5f;
	public AudioClip deathClip;

	private Animator anim;
	private PlayerMovement playerMovement;
	private HashIDs hash;
	private SceneFadeInOut sceneFadeInOut;
	private LastPlayerSighting lastPlayerSighting;
	private float timer;
	private bool playerDead;

	void Awake() {
		anim = GetComponent<Animator> ();
		playerMovement = GetComponent<playerMovement> ();
		hash = gameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<HashIDs> ();
		sceneFadeInOut = gameObject.FindGameObjectWithTag (Tags.fader).GetComponent<SceneFadeInOut> ();
		lastPlayerSighting = gameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<LastPlayerSighting> ();
	}

	void Update() {
		if(HealthBarScript <= 0) {
			if (!playerDead) {
				PlayerDying ();
			}
			else {}
			PlayerDead ();
			LevelReset ();
		}
	}

	void PlayerDying() {
		playerDead = true;
		anim.SetBool (hash.deadBool, true);
		AudioSource.PlayClipAtPoint (deathClip, transform.position);
	}

	void PlayerDead () {
		if (anim.GetCurrentAnimatorStateInfo(0).nameHash == hash.dyingState) {
			anim.SetBool (hash.deadBool, false);
		}

		anim.SetFloat (hash.speedFloat, 0f);
		playerMovement.enabled = false;
		lastPlayerSighting.position = lastPlayerSighting.resetPosition;
		audio.Stop ();
	}

	void LevelReset() {
		timer += Time.deltaTime;

		if (timer >= resetAfterDeathTime) {
			sceneFadeInOut.EndScene ();
		}
	}

	public void TakeDamage(float amount) {
		HealthBarScript -= amount;
	}
}
