using UnityEngine;
using System.Collections;

public class PlayerStamina : MonoBehaviour {

	public float maxStamina = 150f;
	public float staminaRegenTimer = 2.5f;
	public float staminaRegenIncrement = 0.5f;

	public float playerStamina;
	private float waitTimer;
	private bool waitingForRegen;
	private bool regenerating;

	// Use this for initialization
	void Start () {
		playerStamina = maxStamina;
		waitTimer = 0f;
		waitingForRegen = false;
		regenerating = false;
	}

	// Update is called once per frame


	void Update () {
		// see if player is below the stamina threshold
		if (playerStamina < maxStamina) {
			waitingForRegen = true;
			if (waitTimer >= staminaRegenTimer) {
				regenerating = true;
				staminaRegenTimer = 2.5f;
				playerStamina += staminaRegenIncrement;
				if (playerStamina >= maxStamina) {
					ResetTimer ();
				}
			}
			else {
				waitingForRegen = true;
				waitTimer += Time.deltaTime;
			}
		}
		else {
			ResetTimer ();
		}

		// see if they have already waited for the regen delay
	}

	void Regenerate () {

	}

	void ResetTimer () {
		waitTimer = 0f;
		waitingForRegen = false;
		regenerating = false;
	}

	public float GetPlayerStamina() {
		return playerStamina;
	}

	public void DecrementStamina (float amount) {
		if (amount >= 0) {
			ResetTimer ();
			if (playerStamina >= amount) {
				playerStamina -= amount;
				if (playerStamina <= 5f) {
					staminaRegenTimer = 5f;
				}
			}
			waitingForRegen = true;
		}
	}
}