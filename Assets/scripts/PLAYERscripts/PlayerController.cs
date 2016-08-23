using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	Rigidbody2D rb;
	public float speed;
	private Vector2 playerFacing;
	Animator anim;
	[SerializeField]
	public float health = 150;
	[SerializeField]
	public float stamina = 120;
	[SerializeField]
	public float mana = 120;


	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// rotate to face mouse
		var mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation (transform.position - mousePos, Vector3.forward);
		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		rb.angularVelocity = 0;

		//movement
		Vector2 velocity = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical")) * speed;
		if (velocity.x != 0 || velocity.y != 0) {
			anim.SetBool ("isMoving", true);
			rb.AddForce (velocity);
		} else
			anim.SetBool ("isMoving", false);

		getInput ();
	}

	private void getInput ()
	{
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
				//anim.SetBool ("isCombat", true);
				//anim.SetTrigger ("thor");
				//mana -= 30;
				castSpell ("thor");
				//anim.SetBool ("isCombat", false);
				//anim.SetBool ("isDblVertSwing", true);
				//anim.SetBool ("isDblVertSwing", false);
		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			//anim.SetBool ("isCombat", true);
			//anim.SetTrigger ("thor");
			//mana -= 30;
			castSpell ("flame");
			//anim.SetBool ("isCombat", false);
			//anim.SetBool ("isDblVertSwing", true);
			//anim.SetBool ("isDblVertSwing", false);
		}

		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			combatMove ("lhswing");
			//anim.SetBool ("isCombat", true);
			//anim.SetTrigger ("LHSwing");
			//anim.SetBool ("isCombat", false);
			//anim.SetBool ("isDblVertSwing", true);
			//anim.SetBool ("isDblVertSwing", false);
		}

		if (Input.GetKeyDown (KeyCode.Mouse1)) {
			combatMove ("rhswing");
			//anim.SetBool ("isCombat", true);
			//anim.SetTrigger ("RHSwing");
			//anim.SetBool ("isCombat", false);
			//anim.SetBool ("isDblVertSwing", true);
			//anim.SetBool ("isDblVertSwing", false);
		}

		if (Input.GetKeyDown (KeyCode.Mouse3)) {// && Input.GetKeyDown(KeyCode.Mouse1)) {
			combatMove ("dvswing");
			//anim.SetBool ("isCombat", true);
			//anim.SetTrigger ("DblVertSwTrig");
			health -= 15;
			//anim.SetBool ("isCombat", false);
			//anim.SetBool ("isDblVertSwing", true);
			//anim.SetBool ("isDblVertSwing", false);
		}

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			combatMove ("block");
			//anim.SetBool ("isCombat", true);
			//anim.SetBool ("Block", true);
			//anim.SetBool ("isDblVertSwing", true);
			//anim.SetBool ("isDblVertSwing", false);
		}

		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			combatMove ("unblock");
			//anim.SetBool ("isCombat", true);
			//anim.SetBool ("Block", false);
			//anim.SetBool ("isDblVertSwing", true);
			//anim.SetBool ("isDblVertSwing", false);
		}

		//anim.SetBool("isDblVertSwing", false);
	}

	private void combatMove (string attack)
	{
		float cost;
		switch (attack) {
		case "lhswing":
			cost = 10;
			if (stamina >= cost) {
				anim.SetTrigger ("LHSwing");
				stamina -= cost;
			}
			break;
		case "rhswing":
			cost = 10;
			if (stamina >= cost) {
				anim.SetTrigger ("RHSwing");
				stamina -= cost;
			}
			break;
		case "dvswing":
			cost = 20;
			if (stamina >= cost) {
				anim.SetTrigger ("DblVertSwTrig");
				stamina -= cost;
			}
			break;
		case "block":
			cost = 0;
			if (stamina >= cost) {
				anim.SetBool ("Block", true);
				stamina -= cost;
			}
			break;
		case "unblock":
			cost = 0;
			if (stamina >= cost) {
				anim.SetBool ("Block", false);
				stamina -= cost;
			}
			break;
		default:
			break;
		}
	}

	private void castSpell (string spell)
	{
		float cost;
		switch (spell) {
		case "thor":
			cost = 30;
			if (mana >= cost) {
				anim.SetTrigger ("thor");
				mana -= cost;
			}
			break;
		case "flame":
			cost = 30;
			if (mana >= cost) {
				anim.SetTrigger ("flame");
				mana -= cost;
			}
			break;
		default:
			break;
		}
	}
}
