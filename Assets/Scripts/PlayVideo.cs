using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayVideo : MonoBehaviour {

	public MovieTexture movText;
	private AudioSource sound;

	// Use this for initialization
	void Start () {
		Scene currentScene = SceneManager.GetActiveScene ();
		string sceneName = currentScene.name;


		if (sceneName == "Menu")
        {
			GetComponent<Renderer> ().material.mainTexture = movText as MovieTexture;
			sound = GetComponent<AudioSource> ();
			movText.Play ();
			movText.loop = true;
		}

		else if (sceneName != "Menu")
        {
			GetComponent<Renderer> ().material.mainTexture = movText as MovieTexture;
			sound = GetComponent<AudioSource> ();
			movText.Play ();
		}
	}
		
	// Update is called once per frame
	void Update () {
		
		
	}
}
