using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene2 : MonoBehaviour {
	private float timer;
	public Text Uno, Dos;
	private Color Color1, Color2;
	private string a;
	public Object scene;
	//Always start this coroutine in the start function
	private void Start()
	{
		Color1 = Uno.color;
		Color2 = Dos.color;
	}
	//CoRoutine to return async progress, and trigger level load.

	private void Update(){
		timer += Time.deltaTime;
		if (timer >= 1) {
			Color1.a += 0.5f * Time.deltaTime;
			Uno.color = Color1;
		}
		if (timer >= 3) {
			Color2.a += 0.5f * Time.deltaTime;
			Dos.color = Color2;
		}
		if (timer >= 10) {
			SceneManager.LoadScene (scene.name);
		}
	
	}
}
