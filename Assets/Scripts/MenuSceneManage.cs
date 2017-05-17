using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManage : MonoBehaviour {
	float timer;
    public AudioSource sonidoClick;

	// Use this for initialization
	void Start ()
    {
        sonidoClick = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		Scene currentScene = SceneManager.GetActiveScene ();
		string sceneName = currentScene.name;

		if (sceneName == "Ending") {
			timer += Time.deltaTime;
			if(timer > 16){
				SceneManager.LoadScene ("Menu");
			}
		}

		if (Input.GetKey (KeyCode.A)||(Input.GetButtonUp("Xbox_Start")))
        {
            sonidoClick.Play();
            	
			if (sceneName == "Opening")
            {
				SceneManager.LoadScene ("Load3");
			}
			if (sceneName == "Menu")
            {
				SceneManager.LoadScene ("Opening");
			}
		}
	

		if (Input.GetKey (KeyCode.B)||(Input.GetButtonUp("Xbox_Back")))
        {
            sonidoClick.Play();

            if (sceneName == "Menu")
            {
				SceneManager.LoadScene ("Creditos");
			}
		}
	}
}
