using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour {

	private float maxMana = 150f;
	public float currentMana;

	[SerializeField]
	private bool enableRegen;
	public float regenTimeout;
	public float regenTimer;
	public float regenIncrement;

	private bool isDepleted;
	public float depletionTimeout;
	public float depletionRegenIncrement;

	void Awake() {
		currentMana = maxMana;
		regenTimeout = 3.0f;
		regenTimer = 0f;
		regenIncrement = 1.0f;
		isDepleted = false;
		depletionTimeout = 2.0f;
		depletionRegenIncrement = 5.0f;
	}

	void Update() {
		// if dying or dead
		if(currentMana < maxMana) {
			if (isDepleted && enableRegen) {
				if (regenTimer >= depletionTimeout) {
					currentMana += depletionRegenIncrement;
				}
			}
			else {
				if (regenTimer >= regenTimeout && enableRegen) {
					currentMana += regenIncrement;
				}
			}
			regenTimer += Time.deltaTime;
		}
		else {
			isDepleted = false;
		}
	}

	void ResetRegenTimer() {
		regenTimer = 0f;
	}

	public float GetMaxMana() {
		return maxMana;
	}

	public float GetCurrentMana() {
		return currentMana;
	}

	public bool CheckMana(float spellCost) {
		return !isDepleted && currentMana >= spellCost;
	}

	// returns true if the player has enough mana to attack (for use in animator)
	public void UseMana(float spellCost) {
		if (currentMana == spellCost) {
			currentMana = 0f;
			isDepleted = true;
			ResetRegenTimer ();
		} 
		else {
			if (!isDepleted) {
				currentMana -= spellCost;
				ResetRegenTimer ();
			}
		}

	}

	public void DrawMana(float magicPts) {
		float currentMP = maxMana - currentMana;
		if (currentMP < magicPts) {
			currentMana = maxMana;
		}
		else {
			currentMana += magicPts;
		}
	}
}
