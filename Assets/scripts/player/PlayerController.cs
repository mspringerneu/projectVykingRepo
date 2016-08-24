using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	private Rigidbody2D rb;
	private HashIDs hash;
	private bool isMoving;
	public float speed;
	private Vector2 playerFacing;
	private Animator anim;
	private PlayerCombatController combatController;
	private PlayerMana playerMana;
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
		hash = GameObject.FindWithTag (Tags.gameController).GetComponent<HashIDs> ();
		playerMana = GetComponent<PlayerMana> ();
		combatController = GetComponent<PlayerCombatController> ();
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
			isMoving = true;
			anim.SetBool (hash.movingBool, isMoving);
			rb.AddForce (velocity);
		} 
		else {
			isMoving = false;
			anim.SetBool (hash.movingBool, isMoving);
		}

		getInput ();
	}

	private void getInput ()
	{
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			combatController.combatMove ("leftHandSwing");
		}

		if (Input.GetKeyDown (KeyCode.Mouse1)) {
			combatController.combatMove ("rightHandSwing");
		}

		if (Input.GetKeyDown (KeyCode.Mouse3)) {
			combatController.combatMove ("doubleVerticalSwing");
			health -= 15;
		}

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			combatController.combatMove ("block");
		}

		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			combatController.combatMove ("unblock");
		}

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			combatController.castSpell ("thorsThunder");
		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			combatController.castSpell ("logisFlame");
		}
	}
}
