using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManaBarScript : MonoBehaviour {
	[SerializeField]
	private float barTransform;
	[SerializeField]
	private Image content;
	private float mana = 120;

	public GameObject player;
	private float playermana = 120; //player.GetComponent<PlayerController>().mana;
	public Canvas canvas;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		float newMana = player.GetComponent<PlayerController> ().mana;
		if (newMana > 0) {
			float deltaM = mana - player.GetComponent<PlayerController> ().mana;
			if (deltaM > 0) {
				mana = newMana;
				handleBar (deltaM);
			}
		}
	}

	private void handleBar(float offset) {
		content.rectTransform.Translate (new Vector3 (-offset*2, 0, 0));
	}
}
