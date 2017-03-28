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
	private BoxCollider2D boxColl;
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
		boxColl = GetComponent<BoxCollider2D> ();
	}

	// Update is called once per frame
	void Update ()
	{
		//handleMovement ();
		// rotate to face mouse
		var mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation (transform.position - mousePos, Vector3.forward);
		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		rb.angularVelocity = 0;

		float input_x = Input.GetAxisRaw ("Horizontal");
		float input_y = Input.GetAxisRaw ("Vertical");
		Vector2 force_x = new Vector2 (transform.right.x, transform.right.y) * input_x * 6f;
		Vector2 force_y = new Vector2 (transform.up.x, transform.up.y) * input_y * 3f;
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
		if (Input.GetKey(KeyCode.W)) 
		{
			rb.AddForce(transform.up * speed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.S))
		{
			rb.AddForce(-transform.up * speed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.A))
		{
			rb.AddForce(-transform.right * speed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.D))
		{
			rb.AddForce(transform.right * speed * Time.deltaTime);
		}
	}

	private void getInput ()
	{
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			castSpell (Attacks.thorsThunder);
		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			castSpell (Attacks.logisFlame);
		}

		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			combatMove (Attacks.lhSwing);
		}

		if (Input.GetKeyDown (KeyCode.Mouse1)) {
			combatMove (Attacks.rhSwing);
		}

		if (Input.GetKeyDown (KeyCode.Mouse3)) {// && Input.GetKeyDown(KeyCode.Mouse1)) {
			combatMove (Attacks.dblSwing);
			pHealth.TakeDamage(0.1f);
		}

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			combatMove (Attacks.block);
		}

		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			combatMove (Attacks.unblock);
		}
	}

	private void combatMove (string attack)
	{
		float cost;
		switch (attack) {
		case "lhswing":
			cost = AtkCost.lhAxeSwing;
			if (pStamina.HasStamina()) {
				anim.SetTrigger (hash.lhSwingTrig);
				pStamina.UseStamina (cost);
			}
			break;
		case "rhswing":
			cost = AtkCost.rhAxeSwing;
			if (pStamina.HasStamina()) {
				anim.SetTrigger (hash.rhSwingTrig);
				pStamina.UseStamina(cost);
			}
			break;
		case "dblswing":
			cost = AtkCost.dblAxeSwing;
			if (pStamina.HasStamina()) {
				anim.SetTrigger (hash.dblVertSwingTrig);
				pStamina.UseStamina(cost);
			}
			break;
		case "block":
			cost = AtkCost.block;
			if (pStamina.HasStamina()) {
				anim.SetBool (hash.blockBool, true);
				pStamina.UseStamina(cost);
			}
			break;
		case "unblock":
			cost = AtkCost.block;
			if (pStamina.HasStamina()) {
				anim.SetBool (hash.blockBool, false);
				pStamina.UseStamina (cost);
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
			cost = AtkCost.thorsThunder;
			if (pMana.CheckMana(cost)) {
				anim.SetTrigger (hash.thorTrig);
				pMana.UseMana (cost);
			}
			break;
		case "logis_flame":
			cost = AtkCost.logisFlame;
			if (pMana.CheckMana(cost)) {
				anim.SetTrigger (hash.logiTrig);
				pMana.UseMana (cost);
			}
			break;
		default:
			break;
		}
	}

	void OnTriggerEnter2D (Collider2D coll) {
		print ("Triggered by collider of type: " + coll.GetType ().ToString ());
		if (coll.gameObject.CompareTag(Tags.swordEnemy) || coll.gameObject.CompareTag(Tags.axeEnemy)) {
		}
	}

	void OnCollisionEnter2D (Collision2D coll) {
		print ("Collision with collider of type: " + coll.GetType ().ToString ());
		if (coll.gameObject.CompareTag(Tags.swordEnemy) || coll.gameObject.CompareTag(Tags.axeEnemy)) {
		}
	}
}
