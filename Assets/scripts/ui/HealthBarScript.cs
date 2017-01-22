using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {
	[SerializeField]
	private Image content;
	private float hbWidth = 150f;
	// ensures that the script works if maxHealth changes
	private float scalar;

	private PlayerHealth playerHealth;
	private float maxHealth;
	private float currentHealth;
	// Use this for initialization
	void Start () {
		playerHealth = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<PlayerHealth>();
		maxHealth = playerHealth.GetMaxHealth();
		currentHealth = maxHealth;

	}
	
	// Update is called once per frame
	void Update () {
		currentHealth = playerHealth.GetCurrentHealth();
		if (currentHealth > 0) {
			// define deltaH proportionally to maxHealth and hbWidth
			scalar = currentHealth / maxHealth;
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
