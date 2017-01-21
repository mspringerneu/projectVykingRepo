using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	Rigidbody2D rb;
	public float speed;
	private Vector2 playerFacing;
	private Animator anim;
	private HashIDs hash;
	private PlayerHealth pHealth;
	private PlayerStamina pStamina;
	private PlayerMana pMana;
	private SpriteRenderer spriteRenderer;
	private float rotation;

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
		hash = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<HashIDs> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		pHealth = GetComponent<PlayerHealth> ();
		pStamina = GetComponent<PlayerStamina> ();
		pMana = GetComponent<PlayerMana> ();
	}

	// Update is called once per frame
	void Update ()
	{
		handleMovement ();
		// rotate to face mouse
		var mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation (transform.position - mousePos, Vector3.forward);
		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		rb.angularVelocity = 0;

		float input_x = Input.GetAxisRaw ("Horizontal");
		float input_y = Input.GetAxisRaw ("Vertical");
		Vector2 force_x = new Vector2 (transform.right.x, transform.right.y) * input_x;
		Vector2 force_y = new Vector2 (transform.up.x, transform.up.y) * input_y;
		Vector2 combined_force = new Vector2((force_x.x + force_y.x), (force_x.y + force_y.y)) * speed * Time.deltaTime;

		if (combined_force.magnitude > 0f) {
			print ("Combined force: " + combined_force.ToString ());
			anim.SetBool (hash.movingBool, true);
			rb.AddForce (combined_force);
		} 
		else {
			print ("Player not moving");
			rb.AddForce(new Vector2(0f, 0f));
			anim.SetBool (hash.movingBool, false);
		}

		getInput ();
	}

	private void handleMovement() {
		if (Input.GetKey(KeyCode.W)) {

			rb.AddForce(transform.up * speed * Time.fixedDeltaTime);

		}

		if (Input.GetKey(KeyCode.S))
		{
			rb.AddForce(-transform.up * speed * Time.fixedDeltaTime);
		}

		if (Input.GetKey(KeyCode.A))
		{
			rb.AddForce(-transform.right * speed * Time.fixedDeltaTime);
		}

		if (Input.GetKey(KeyCode.D))
		{
			rb.AddForce(transform.right * speed * Time.fixedDeltaTime);
		}
	}

	private void getInput ()
	{
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
				//anim.SetBool ("isCombat", true);
				//anim.SetTrigger ("thor");
				//mana -= 30;
				castSpell ("thors_thunder");
				//anim.SetBool ("isCombat", false);
				//anim.SetBool ("isDblVertSwing", true);
				//anim.SetBool ("isDblVertSwing", false);
		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			//anim.SetBool ("isCombat", true);
			//anim.SetTrigger ("thor");
			//mana -= 30;
			castSpell ("logis_flame");
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
				anim.SetTrigger (hash.lhSwingTrig);
				stamina -= cost;
			}
			break;
		case "rhswing":
			cost = 10;
			if (stamina >= cost) {
				anim.SetTrigger (hash.rhSwingTrig);
				stamina -= cost;
			}
			break;
		case "dvswing":
			cost = 20;
			if (stamina >= cost) {
				anim.SetTrigger (hash.dblVertSwingTrig);
				stamina -= cost;
			}
			break;
		case "block":
			cost = 0;
			if (stamina >= cost) {
				anim.SetBool (hash.blockBool, true);
				stamina -= cost;
			}
			break;
		case "unblock":
			cost = 0;
			if (stamina >= cost) {
				anim.SetBool (hash.blockBool, false);
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
		case "thors_thunder":
			cost = 30;
			if (mana >= cost) {
				anim.SetTrigger (hash.thorTrig);
				mana -= cost;
			}
			break;
		case "logis_flame":
			cost = 30;
			if (mana >= cost) {
				anim.SetTrigger (hash.logiTrig);
				mana -= cost;
			}
			break;
		default:
			break;
		}
	}
}
