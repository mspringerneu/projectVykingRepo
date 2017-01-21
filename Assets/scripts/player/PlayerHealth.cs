using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float health = 100f;
	public float resetAfterDeathTime = 5f;
	public AudioClip deathClip;

	private Animator anim;
	private HealthBarScript healthBarScript;
	private PlayerController playerController;
	private HashIDs hash;
	private SceneFadeInOut sceneFadeInOut;
	private LastPlayerSighting lastPlayerSighting;
	private float timer;
	private bool playerDead;

	void Awake() {
		anim = GetComponent<Animator> ();
		healthBarScript = GameObject.FindGameObjectWithTag (Tags.hud).GetComponentInChildren<HealthBarScript> ();
		playerController = GetComponent<PlayerController> ();
		hash = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<HashIDs> ();
		sceneFadeInOut = GameObject.FindGameObjectWithTag (Tags.fader).GetComponent<SceneFadeInOut> ();
		lastPlayerSighting = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<LastPlayerSighting> ();
	}

	void Update() {
		if(healthBarScript.getHealth() <= 0) {
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

		playerController.speed = 0f;
		playerController.enabled = false;
		lastPlayerSighting.position = lastPlayerSighting.resetPosition;
		GetComponent<AudioSource>().Stop ();
	}

	void LevelReset() {
		timer += Time.deltaTime;

		if (timer >= resetAfterDeathTime) {
			sceneFadeInOut.EndScene ();
		}
	}

	public void TakeDamage(float pctDamage) {
		
	}
}
