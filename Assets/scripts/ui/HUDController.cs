using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {
	private PlayerController player;
	private GameObject healthBar;
	private GameObject staminaBar;
	private GameObject manaBar;

	// width of bar (stamina and mana bars have same width as health, but are scaled)

	// timeout for stamina regeneration
	[SerializeField]
	private float sbTimeout;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<PlayerController> ();
		healthBar = GameObject.FindGameObjectWithTag(Tags.healthBar);
		staminaBar = GameObject.FindGameObjectWithTag(Tags.staminaBar);
		manaBar = GameObject.FindGameObjectWithTag(Tags.manaBar);
	}




	
	// Update is called once per frame
	void Update () {
		
	}


}
