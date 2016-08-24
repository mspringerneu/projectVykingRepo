using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneFadeInOut : MonoBehaviour {
	public float fadeSpeed = 1.5f;

	private bool sceneStarting = true;
	private GUITexture tex;

	void Awake() {
		tex = GetComponent<GUITexture> ();
		tex.pixelInset = new Rect (0, 0, Screen.width, Screen.height);
	}

	void Update() {
		if (sceneStarting) {
			StartScene ();
		}
	}

	void FadeToClear() {
		tex.color = Color.Lerp(tex.color, Color.clear, fadeSpeed * Time.deltaTime);
	}

	void FadeToBlack() {
		tex.color = Color.Lerp(tex.color, Color.black, fadeSpeed * Time.deltaTime);
	}

	void StartScene() {
		FadeToClear ();

		if (tex.color.a <= 0.05f) {
			tex.color = Color.clear;
			tex.enabled = false;
			sceneStarting = false;
		}
	}

	public void EndScene() {
		tex.enabled = true;
		FadeToBlack ();

		if(tex.color.a >= 0.95f) {
			SceneManager.LoadScene ("TreasureCave");
		}

		sceneStarting = false;
	}
}
