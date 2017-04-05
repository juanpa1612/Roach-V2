using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIController : MonoBehaviour {

	private GameObject Player;
	private int cantFosforosPlayer;
	private bool hayLuzPlayer;
	private GUIStyle Dibujarfosforos;
	private GUIStyle Dibujartitulo;
	private GUIStyle DibujarReload;
	private float timer;


	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		cantFosforosPlayer = Player.GetComponent<PickUp>().cantFosforos;
		Dibujarfosforos = new GUIStyle ();
		Dibujarfosforos.normal.textColor = Color.white;
		Dibujarfosforos.fontSize = 40;
		Dibujartitulo = new GUIStyle ();
		Dibujartitulo.normal.textColor = Color.white;
		Dibujartitulo.fontSize = 30;
		DibujarReload = new GUIStyle ();
		DibujarReload.normal.textColor = Color.clear;
		DibujarReload.fontSize = 120;
		timer = Player.GetComponent<PickUp>().veneno;

	}

	void OnGUI(){
		Rect RectFosforos = new Rect (40, 60, 100, 100);
		Rect RectTitulo = new Rect (40, 30, 100, 100);
		Rect RectTiempo = new Rect (420, 60, 100, 100);
		Rect RectTitTiempo = new Rect (420, 30, 100, 100);
		GUI.Label (RectFosforos, cantFosforosPlayer.ToString(),Dibujarfosforos);
		GUI.Label (RectTitulo, "Fosforos Restantes:", Dibujartitulo);
		int minutes = Mathf.FloorToInt (timer / 60F);
		int seconds = Mathf.FloorToInt (timer - minutes * 60);
		string tiempoDibujo = string.Format ("{0:00}:{1:00}", minutes, seconds);
		GUI.Label (RectTiempo, tiempoDibujo ,Dibujarfosforos);
		GUI.Label (RectTitTiempo, "Tiempo Restante:", Dibujartitulo);
		/*(0,0,200,200,vidaact)*/
		Rect RectReload = new Rect (320, 520, 100, 100);
		GUI.Label (RectReload, "Se acabo el tiempo ",DibujarReload);
	}
	
	// Update is called once per frame
	void Update () {
		cantFosforosPlayer = Player.GetComponent<PickUp>().cantFosforos;
		timer = Player.GetComponent<PickUp>().veneno;
		if (timer <= 1) {
			DibujarReload.normal.textColor = Color.red;
		}

	}


}
