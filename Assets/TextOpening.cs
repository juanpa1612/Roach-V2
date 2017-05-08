using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextOpening : MonoBehaviour {

	float timer;
	public Text Uno, Dos, Tres, Cuatro, Cinco, Seis, Siete;
	private Color Color1, Color2, Color3, Color4, Color5, Color6;
	// Use this for initialization
	void Start () {

		Scene currentScene = SceneManager.GetActiveScene ();
		string sceneName = currentScene.name;
		if (sceneName == "Opening") {
			Color1 = Uno.color;
			Color2 = Dos.color;
			Color3 = Tres.color;
			Color4 = Cuatro.color;
			Color5 = Cinco.color;
			Color6 = Seis.color;
		}

		if (sceneName == "Ending") {
			Color1 = Uno.color;
			Color2 = Dos.color;
			Color3 = Tres.color;
			Color4 = Cuatro.color;
		}

	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		Scene currentScene = SceneManager.GetActiveScene ();
		string sceneName = currentScene.name;

		if (sceneName == "Opening") {
			if (timer > 3) {
				Color1.a += 0.5f * Time.deltaTime;
				Uno.color = Color1;
			}

			if (timer > 6) {
				Color2.a += 0.5f * Time.deltaTime;
				Dos.color = Color2;
			}

			if (timer > 12) {
				Color3.a += 0.5f * Time.deltaTime;
				Tres.color = Color3;
			}

			if (timer > 18) {
				Color4.a += 0.5f * Time.deltaTime;
				Cuatro.color = Color4;
			}

			if (timer > 24) {
				Color5.a += 0.5f * Time.deltaTime;
				Cinco.color = Color5;
			}

			if (timer > 30) {
				Color6.a += 0.5f * Time.deltaTime;
				Seis.color = Color6;
			}

			if (timer > 36) {
				Siete.enabled = true;
			}
		}

		if (sceneName == "Ending") {
			if (timer > 3) {
				Color1.a += 0.5f * Time.deltaTime;
				Uno.color = Color1;
			}

			if (timer > 9) {
				Color2.a += 0.5f * Time.deltaTime;
				Dos.color = Color2;
			}

			if (timer > 12) {
				Color3.a += 0.5f * Time.deltaTime;
				Tres.color = Color3;
			}

			if (timer > 15) {
				Color4.a += 0.5f * Time.deltaTime;
				Cuatro.color = Color4;

		    if (timer > 20) {
					SceneManager.LoadScene ("Menu");
			}
		}
			
		}
	}
}
