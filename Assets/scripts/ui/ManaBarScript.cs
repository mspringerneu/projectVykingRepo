using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManaBarScript : MonoBehaviour {
	[SerializeField]
	private Image content;
	private float mbWidth = 150f;
	// ensures that the script works if maxMana changes
	private float scalar;

	private PlayerMana playerMana;
	private float maxMana;
	private float currentMana;
	// Use this for initialization
	void Start () {
		playerMana = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<PlayerMana>();
		maxMana = playerMana.GetMaxMana();
		currentMana = maxMana;
	}

	// Update is called once per frame
	void Update () {
		currentMana = playerMana.GetCurrentMana();
		if (currentMana > 0) {
			// define deltaH proportionally to maxMana and hbWidth
			scalar = currentMana / maxMana;
			print ("Scalar: " + scalar.ToString ());
			if (scalar != 1) {
				handleBar (scalar);
			}
		}
	}

	private void handleBar(float scalar) {
		content.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, scalar * mbWidth);
		//content.rectTransform.Translate (new Vector3 (-offset, 0, 0));
	}
}
