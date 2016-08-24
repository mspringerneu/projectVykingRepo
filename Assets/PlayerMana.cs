using UnityEngine;
using System.Collections;

public class PlayerMana : MonoBehaviour {

	public float maxMana = 150f;
	public float manaRegenTimer = 2.5f;
	public float manaRegenIncrement = 0.5f;

	public float playerMana;
	private float waitTimer;
	private bool waitingForRegen;
	private bool regenerating;

	// Use this for initialization
	void Start () {
		playerMana = maxMana;
		waitTimer = 0f;
		waitingForRegen = false;
		regenerating = false;
	}
	
	// Update is called once per frame


	void Update () {
		// see if player is below the mana threshold
		if (playerMana < maxMana) {
			waitingForRegen = true;
			if (waitTimer >= manaRegenTimer) {
				regenerating = true;
				manaRegenTimer = 2.5f;
				playerMana += manaRegenIncrement;
				if (playerMana >= maxMana) {
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

	public float GetPlayerMana() {
		return playerMana;
	}
		
	public void DecrementMana (float amount) {
		if (amount >= 0) {
			ResetTimer ();
			if (playerMana >= amount) {
				playerMana -= amount;
				if (playerMana <= 5f) {
					manaRegenTimer = 5f;
				}
			}
			waitingForRegen = true;
		}
	}
}
