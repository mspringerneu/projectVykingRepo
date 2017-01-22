using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Timers;

public class StaminaBarScript : MonoBehaviour {
	[SerializeField]
	private Image content;
	private float sbWidth = 150f;
	// ensures that the script works if maxStamina changes
	private float scalar;

	private PlayerStamina playerStamina;
	private float maxStamina;
	private float currentStamina;
	// Use this for initialization
	void Start () {
		playerStamina = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<PlayerStamina>();
		maxStamina = playerStamina.GetMaxStamina();
		currentStamina = maxStamina;

	}

	// Update is called once per frame
	void Update () {
		currentStamina = playerStamina.GetCurrentStamina();
		if (currentStamina > 0) {
			// define deltaH proportionally to maxStamina and hbWidth
			scalar = currentStamina / maxStamina;
			print ("Scalar: " + scalar.ToString ());
			handleBar (scalar);
		}
	}

	private void handleBar(float scalar) {
		content.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, scalar * sbWidth);
		//content.rectTransform.Translate (new Vector3 (-offset, 0, 0));
	}

	/*
	[SerializeField]
	private float barTransform;
	[SerializeField]
	private Image content;
	private float stam = 120;

	public GameObject player;
	private float playerstam = 120; //player.GetComponent<PlayerController>().mana;
	public Canvas canvas;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		float newStam = player.GetComponent<PlayerController>().stamina;
		if (newStam > 0) {
			float deltaS = stam - player.GetComponent<PlayerController> ().stamina;
			if (deltaS > 0) {
				stam = newStam;
				handleBar (deltaS);
			}
		}
	}

	private void handleBar(float offset) {
		content.rectTransform.Translate (new Vector3 (-offset*2, 0, 0));
	}
	*/
}

