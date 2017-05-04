using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.A)||(Input.GetButtonUp("Xbox_Start"))) {
				SceneManager.LoadScene ("LoadLevel1");
			}
	
		if (Input.GetKey (KeyCode.B)||(Input.GetButtonUp("Xbox_Back"))) {
			SceneManager.LoadScene ("Creditos");
		}
	}
}
