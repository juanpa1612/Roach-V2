using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

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
    public Text presionaB;
    public Image imgCarta;
    private Color colorCarta;
	public Font fuente;
    private Color alphaMensajes;
	// Use this for initialization
	void Start ()
    {
        masMensajes.gameObject.SetActive(false);
        imgCarta.gameObject.SetActive(false);
        presionaB.gameObject.SetActive(false);
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
            presionaB.gameObject.SetActive(true);
		}
	}
		
	// Update is called once per frame
	void Update ()
    {
		
		if (cartita||(Jugador.GetComponent<FirstPersonController>().Escena1&&Jugador.GetComponent<FirstPersonController>().tiempoInicio>0))
        {
			Jugador.GetComponent<FirstPersonController>().m_WalkSpeed = 0;

		}
        else
        {
			Jugador.GetComponent<FirstPersonController>().m_WalkSpeed = 5;
        }
        
		//print (TimePrendido);
		//print (GUI.color);
		if (TimePrendido <= 0)
        {
            //masMensajes.CrossFadeAlpha(0, 1, false);
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
                
                //sumarFosforo ();
            }
		}

		if ((Input.GetKeyUp (KeyCode.E)||(Input.GetButtonDown("Xbox_B")))&&cartita)
        {
			cartita = false;
			sono = false;
            imgCarta.CrossFadeAlpha(0, 1, false);
            StartCoroutine(FadeOutMensajes());
            masMensajes.gameObject.SetActive(true);
            alphaMensajes = masMensajes.color;
            alphaMensajes.a = 1;
            masMensajes.color = alphaMensajes;
            presionaB.CrossFadeAlpha(0, .5f, false);
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
    IEnumerator FadeOutMensajes()
    {

        yield return new WaitForSeconds(3);

        masMensajes.CrossFadeAlpha(0, 1f, false);
    }
}
