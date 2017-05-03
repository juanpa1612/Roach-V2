using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Creditos : MonoBehaviour {
	public float y = 500;
	public Font holis;
	public GUIStyle nuevo;
	void Start () {
		nuevo = new GUIStyle ();
		nuevo.font = holis;
		nuevo.normal.textColor = Color.white;
		nuevo.fontSize = 20;
	}

	void Update () {
		y = y -1;
		Debug.Log (y);
		if (y <= (-250)) {
			SceneManager.LoadScene("Menu");
		}
	}
	void OnGUI () {

		GUI.Label(new Rect((Screen.width/2)-80,y,200,50),"Camilo Villegas:", nuevo);
		GUI.Label(new Rect((Screen.width/2)-80,y+20,200,50),"Produccion, Game Design, Animacion", nuevo);
		GUI.Label(new Rect((Screen.width/2)-80,y+40,200,50),"", nuevo);
		GUI.Label(new Rect((Screen.width/2)-80,y+60,200,50),"Cesar Angel:", nuevo);
		GUI.Label(new Rect((Screen.width/2)-80,y+80,200,50),"Programacion General, HUD, Testing", nuevo);
		GUI.Label(new Rect((Screen.width/2)-80,y+100,200,50),"", nuevo);
		GUI.Label(new Rect((Screen.width/2)-80,y+120,200,50),"Juan Pablo Amado:", nuevo);
		GUI.Label(new Rect((Screen.width/2)-80,y+140,200,50),"Level Design, Modelado Niveles, HUD", nuevo);
		GUI.Label(new Rect((Screen.width/2)-80,y+160,200,50),"", nuevo);
		GUI.Label(new Rect((Screen.width/2)-80,y+180,200,50),"", nuevo);
		GUI.Label(new Rect((Screen.width/2)-80,y+200,200,50),"Copyright 2017 6 Weeks Games", nuevo);

	}
}