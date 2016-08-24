using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManaBarScript : MonoBehaviour {
	[SerializeField]
	private float barTransform;
	[SerializeField]
	private Image content;
	//private float mana = 120f;

	//public GameObject player;
	private float manaBarWidth = 150f;
	private Vector3 initialPos;
	private Vector3 deltaPos;
	private PlayerMana playerMana;
	private float maxMana;
	public float currentMana;
	public Canvas canvas;
	// Use this for initialization
	void Start () {
		initialPos = content.transform.position;
		playerMana = GameObject.FindWithTag (Tags.player).GetComponent<PlayerMana> ();
		maxMana = playerMana.maxMana;
		currentMana = maxMana;
	}

	// Update is called once per frame
	void Update () {
		currentMana = playerMana.GetPlayerMana ();
		if (currentMana != maxMana) {
			deltaPos = new Vector3 (-GetXOffset (), 0, 0);
			content.transform.position = initialPos + deltaPos;
		}
		else {
			content.transform.position = initialPos;
		}
	}

	private float GetXOffset () {
		return (maxMana - currentMana) * (maxMana / manaBarWidth);
	}
}
