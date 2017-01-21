using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Timers;

public class StaminaBarScript : MonoBehaviour {
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
}

