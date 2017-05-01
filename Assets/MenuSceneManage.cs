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

		if (Input.GetKey (KeyCode.A)) {
				SceneManager.LoadScene ("Nivel1_Chumi");
			}
	
		if (Input.GetKey (KeyCode.B)) {
			SceneManager.LoadScene ("Creditos");
		}
	}
}
