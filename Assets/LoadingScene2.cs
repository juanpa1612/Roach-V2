using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene2 : MonoBehaviour {
	public Texture2D ProgressBar;
	private float tiempo;
	private AsyncOperation async = null;
	private GUIStyle escenaDos;
	public string a, b;
	//Always start this coroutine in the start function
	private void Start()
	{
		tiempo = 5;
		StartCoroutine(LoadLevel(a));
		escenaDos = new GUIStyle ();
		escenaDos.fontSize = 200;
		escenaDos.normal.textColor = Color.white;
	}
	//CoRoutine to return async progress, and trigger level load.
	private IEnumerator LoadLevel(string Level)
	{
		yield return new WaitForSeconds (5);
		Application.LoadLevelAsync(Level);
		yield return async;
	}
	private void OnGUI()
	{
			GUI.Label (new Rect (220, 0, 100, 100), b, escenaDos);
			GUI.Label (new Rect (220, 200, 50, 50), "Cargando...", escenaDos);
		// Check if it's loading;
		if (async != null)
		{
			GUI.DrawTexture(new Rect(0, 0, 100 * async.progress, 50), ProgressBar);
		}
	}

	private void Update(){
		tiempo -= Time.deltaTime;
	
	}
}
