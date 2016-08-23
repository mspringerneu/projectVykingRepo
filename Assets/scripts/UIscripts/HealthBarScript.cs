using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {
	[SerializeField]
	private float barTransform;
	[SerializeField]
	private Image content;
	private float health = 150;

	public GameObject player;
	private float playerhealth = 150; //player.GetComponent<PlayerController>().health;
	public Canvas canvas;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float newHealth = player.GetComponent<PlayerController> ().health;
		if (newHealth > 0) {
			float deltaH = health - player.GetComponent<PlayerController> ().health;
			if (deltaH > 0) {
				health = newHealth;
				handleBar (deltaH);
			}
		}
	}

	private void handleBar(float offset) {
		content.rectTransform.Translate (new Vector3 (-offset*2, 0, 0));
	}
}
