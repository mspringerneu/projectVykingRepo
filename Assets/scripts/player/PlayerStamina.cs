using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStamina : MonoBehaviour {

	private float maxStamina = 150f;
	public float currentStamina;

	public float regenTimeout;
	public float regenTimer;
	public float regenIncrement;

	private bool isExhausted;
	public float exhaustionTimeout;
	public float exhaustionRegenIncrement;

	void Awake() {
		currentStamina = maxStamina;
		regenTimeout = 1.0f;
		regenTimer = 0f;
		regenIncrement = 2.0f;
		isExhausted = false;
		exhaustionTimeout = 2.0f;
		exhaustionRegenIncrement = 1.0f;
	}

	void Update() {
		// if dying or dead
		if(currentStamina < maxStamina) {
			if (isExhausted) {
				if (regenTimer >= exhaustionTimeout) {
					currentStamina += exhaustionRegenIncrement;
				}
			}
			else {
				if (regenTimer >= regenTimeout) {
					currentStamina += regenIncrement;
				}
			}
			regenTimer += Time.deltaTime;
		}
		else {
			isExhausted = false;
		}
	}

	void ResetRegenTimer() {
		regenTimer = 0f;
	}

	public float GetMaxStamina() {
		return maxStamina;
	}

	public float GetCurrentStamina() {
		return currentStamina;
	}

	public bool HasStamina() {
		return !isExhausted && currentStamina > 0f;;
	}

	// returns true if the player has enough stamina to attack (for use in animator)
	public void UseStamina(float atkCost) {
		
		if (currentStamina <= atkCost) {
			currentStamina = 0f;
			isExhausted = true;
		} 
		else {
			currentStamina -= atkCost;
		}
		ResetRegenTimer ();
	}
}
