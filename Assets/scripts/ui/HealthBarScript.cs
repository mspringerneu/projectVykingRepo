using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {
	[SerializeField]
	private float barTransform;
	[SerializeField]
	private Image content;
	private float hbWidth = 150f;
	// ensures that the script works if maxHealth changes
	private float scalar;

	public GameObject player;
	private float maxHealth;
	private float playerHealth; //player.GetComponent<PlayerController>().health;
	public Canvas canvas;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag (Tags.player);
		maxHealth = player.GetComponent<PlayerHealth> ().GetMaxHealth();
		playerHealth = maxHealth;

	}
	
	// Update is called once per frame
	void Update () {
		playerHealth = player.GetComponent<PlayerHealth> ().GetCurrentHealth();
		if (playerHealth > 0) {
			// define deltaH proportionally to maxHealth and hbWidth
			scalar = playerHealth / maxHealth;
			print ("Scalar: " + scalar.ToString ());
			if (scalar != 1) {
				handleBar (scalar);
			}
		}
	}

	private void handleBar(float scalar) {
		
		content.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, scalar * hbWidth);
		//content.rectTransform.Translate (new Vector3 (-offset, 0, 0));
	}
}
