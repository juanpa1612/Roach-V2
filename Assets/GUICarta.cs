using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUICarta : MonoBehaviour {
	private GUIStyle Dibujarmensaje;
	//private GUIStyle Dibujarcarta;
	public GameObject Carta;
	private GameObject Jugador;
	private bool sePrendio;
	private float TimePrendido;
	private bool sumar, cartita;
	public Texture imagen;
	// Use this for initialization
	void Start () {
		sePrendio = false;
		sumar = true;
		TimePrendido = 2;
		Jugador = GameObject.FindGameObjectWithTag ("Player");
		Dibujarmensaje = new GUIStyle ();
		Dibujarmensaje.normal.textColor = Color.clear;
		Dibujarmensaje.fontSize = 30;
		//Dibujarcarta = new GUIStyle ();
		//GUI.color = Color.clear;
		cartita=false;
	}

	void OnGUI(){
		Rect RectMensaje = new Rect (520, 520, 100, 100);
		GUI.Label (RectMensaje, "Podras encontrar mas mensajes en el laberinto",Dibujarmensaje);
		if (cartita) {
			GUI.Label (new Rect (520, 100, 600, 500), imagen);
		}
	}
		
	// Update is called once per frame
	void Update () {
		//print (TimePrendido);
		//print (GUI.color);
		if (TimePrendido <= 0) {
			Dibujarmensaje.normal.textColor = Color.clear;
			sePrendio = true;
			sumar = true;
			cartita = true;
			TimePrendido = 2;
		}

		if (!sePrendio) {
			if (!Carta.active) {
				TimePrendido -= Time.deltaTime;
				Dibujarmensaje.normal.textColor = Color.white;
				//sumarFosforo ();
			}
		}

		if (Input.GetKeyUp (KeyCode.E)) {
			cartita = false;
		}
	}

	void sumarFosforo(){
		if (sumar) {
			Jugador.GetComponent<PickUp> ().sumarFosforos(1);
			sumar = false;
		}
	}
}
