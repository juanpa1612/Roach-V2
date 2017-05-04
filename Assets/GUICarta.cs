using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUICarta : MonoBehaviour {
	private GUIStyle Dibujarmensaje;
	//private GUIStyle Dibujarcarta;
	public GameObject Carta;
	private GameObject Jugador;
	private bool sePrendio;
	private float TimePrendido;
	private bool sumar, cartita;
	public Texture imagen;
	private AudioSource Source;
	public AudioClip papel;
	private bool sono;

    //Optimizacion Chumi
    public Text masMensajes;
    public Image imgCarta;
    private Color colorCarta;
	public Font fuente;
	// Use this for initialization
	void Start ()
    {
        masMensajes.gameObject.SetActive(false);
        imgCarta.gameObject.SetActive(false);
        colorCarta = imgCarta.color;

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
		sono = false;
		Source = GetComponent<AudioSource> ();
	}

	public bool getCartita()
    {
		return cartita;
	}

	void OnGUI()
    {
		Rect RectMensaje = new Rect (520, 520, 100, 100);
		GUI.Label (RectMensaje, "Podras encontrar mas mensajes en el laberinto",Dibujarmensaje);

		if (cartita)
        {
            //GUI.Label (new Rect (520, 100, 800, 500), imagen);
            colorCarta.a += 0.2f * Time.deltaTime;
            imgCarta.color = colorCarta;
		}
	}
		
	// Update is called once per frame
	void Update ()
    {
		if (cartita) {
			BoxCollider box = gameObject.AddComponent<BoxCollider>();
		}
		//print (TimePrendido);
		//print (GUI.color);
		if (TimePrendido <= 0)
        {
            masMensajes.CrossFadeAlpha(0, 1, false);
            imgCarta.gameObject.SetActive(true);
            //Dibujarmensaje.normal.textColor = Color.clear;
            sePrendio = true;
			sumar = true;
			cartita = true;
			if (!sono)
            {
				Source.clip = papel;
				Source.Play ();
				sono = true;
			}
			TimePrendido = 2;
		}

		if (!sePrendio)
        {
			if (!Carta.active)
            {
				TimePrendido -= Time.deltaTime;
				//Dibujarmensaje.normal.textColor = Color.white;
                masMensajes.gameObject.SetActive(true);
                //sumarFosforo ();
            }
		}

		if ((Input.GetKeyUp (KeyCode.E)||(Input.GetButtonDown("Xbox_B")))&&cartita)
        {
			cartita = false;
			sono = false;
            imgCarta.CrossFadeAlpha(0, 1, false);
		}
	}

	void sumarFosforo()
    {
		if (sumar)
        {
			Jugador.GetComponent<PickUp> ().sumarFosforos(1);
			sumar = false;
		}
	}
}
