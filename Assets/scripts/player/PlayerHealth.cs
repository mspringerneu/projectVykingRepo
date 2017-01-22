using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	private float maxHealth = 200f;
	public float currentHealth;

	public float resetAfterDeathTime = 5f;

	[SerializeField]
	private bool enableRegen;
	public float regenTimeout;
	public float regenTimer;
	public float regenIncrement;

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
		currentHealth = maxHealth;
		regenTimeout = 3.0f;
		regenTimer = 0f;
		regenIncrement = 1f;
		anim = GetComponent<Animator> ();
		healthBarScript = GameObject.FindGameObjectWithTag (Tags.hud).GetComponentInChildren<HealthBarScript> ();
		playerController = GetComponent<PlayerController> ();
		hash = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<HashIDs> ();
		sceneFadeInOut = GameObject.FindGameObjectWithTag (Tags.fader).GetComponent<SceneFadeInOut> ();
		lastPlayerSighting = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<LastPlayerSighting> ();
	}

	void Update() {

		if (currentHealth < maxHealth && enableRegen) {
			regenTimer += Time.deltaTime;
			if (regenTimer >= regenTimeout) {
				currentHealth += regenIncrement;
			}
		}
	}

	void ResetRegenTimer() {
		regenTimer = 0f;
	}

	void PlayerDying() {
		playerDead = true;
		anim.SetBool (hash.deadBool, true);
		AudioSource.PlayClipAtPoint (deathClip, transform.position);
	}

	void PlayerDead () {
		if (anim.GetCurrentAnimatorStateInfo(0).fullPathHash == hash.dyingState) {
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

	public float GetMaxHealth() {
		return maxHealth;
	}

	public float GetCurrentHealth() {
		return currentHealth;
	}

	// returns true if the damage kills the player (for use with animator)
	public bool TakeDamage(float hitPts) {
		bool killingBlow = false;
		currentHealth -= hitPts;
		if (currentHealth <= hitPts) {
			currentHealth = 0f;
			if (!playerDead) {
				PlayerDying ();
				killingBlow = true;
			} 
			else {
				PlayerDead ();
				LevelReset ();
			}
		} 
		else  {
			currentHealth -= hitPts;
			ResetRegenTimer ();
		}
		return killingBlow;
	}

	public void Heal(float hitPts) {
		float currentDamage = maxHealth - currentHealth;
		if (currentDamage < hitPts) {
			currentHealth = maxHealth;
		}
		else {
			currentHealth += hitPts;
		}
	}
}
