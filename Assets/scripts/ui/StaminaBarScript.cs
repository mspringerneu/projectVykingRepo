using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StaminaBarScript : MonoBehaviour {
	[SerializeField]
	private float barTransform;
	[SerializeField]
	private Image content;
	//private float stamina = 120f;

	//public GameObject player;
	private float staminaBarWidth = 150f;
	private Vector3 initialPos;
	private Vector3 deltaPos;
	private PlayerStamina playerStamina;
	private float maxStamina;
	public float currentStamina;
	public Canvas canvas;
	// Use this for initialization
	void Start () {
		initialPos = content.transform.position;
		playerStamina = GameObject.FindWithTag (Tags.player).GetComponent<PlayerStamina> ();
		maxStamina = playerStamina.maxStamina;
		currentStamina = maxStamina;
	}

	// Update is called once per frame
	void Update () {
		currentStamina = playerStamina.GetPlayerStamina ();
		if (currentStamina != maxStamina) {
			deltaPos = new Vector3 (-GetXOffset (), 0, 0);
			content.transform.position = initialPos + deltaPos;
		}
		else {
			content.transform.position = initialPos;
		}
	}

	private float GetXOffset () {
		return (maxStamina - currentStamina) * (maxStamina / staminaBarWidth);
	}
}