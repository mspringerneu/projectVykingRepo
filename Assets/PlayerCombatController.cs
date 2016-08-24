using UnityEngine;
using System.Collections;

public class PlayerCombatController : MonoBehaviour {

	// combat move costs
	public float swingCost = 10f;
	public float doubleSwingCost = 20f;
	public float blockDamageReduction = 0.9f;
	public float thorCost = 20f;
	public float logiCost = 20f;

	private PlayerHealth playerHealth;
	private PlayerStamina playerStamina;
	private PlayerMana playerMana;
	private Animator anim;
	private HashIDs hash;

	void Awake() {
		playerHealth = GetComponent<PlayerHealth> ();
		playerStamina = GetComponent<PlayerStamina> ();
		playerMana = GetComponent<PlayerMana> ();
		anim = GetComponent<Animator> ();
		hash = GameObject.FindWithTag (Tags.gameController).GetComponent<HashIDs> ();
	}

	public void combatMove (string attack)
	{
		switch (attack) {
		case "leftHandSwing":
			if (playerStamina.GetPlayerStamina() >= swingCost) {
				anim.SetTrigger (hash.leftHandSwingTrigger);
				playerStamina.DecrementStamina(swingCost);
			}
			break;
		case "rightHandSwing":
			if (playerStamina.GetPlayerStamina() >= swingCost) {
				anim.SetTrigger (hash.rightHandSwingTrigger);
				playerStamina.DecrementStamina(swingCost);
			}
			break;
		case "doubleVerticalSwing":
			if (playerStamina.GetPlayerStamina() >= doubleSwingCost) {
				anim.SetTrigger (hash.doubleVerticalSwingTrigger);
				playerStamina.DecrementStamina(doubleSwingCost);
			}
			break;
		case "block":
			if (playerStamina.GetPlayerStamina() >= 0) {
				anim.SetBool (hash.blockingBool, true);
			}
			break;
		case "unblock":
			if (playerStamina.GetPlayerStamina() >= 0) {
				anim.SetBool (hash.blockingBool, false);
			}
			break;
		default:
			break;
		}
	}

	public void castSpell (string spell)
	{
		float cost;
		switch (spell) {
		case "thorsThunder":
			if (playerMana.GetPlayerMana() >= thorCost) {
				anim.SetTrigger (hash.thorsThunderTrigger);
				playerMana.DecrementMana (thorCost);
			}
			break;
		case "logisFlame":
			if (playerMana.GetPlayerMana() >= logiCost) {
				anim.SetTrigger (hash.logisFlameTrigger);
				playerMana.DecrementMana (logiCost);
			}
			break;
		default:
			break;
		}
	}
}
