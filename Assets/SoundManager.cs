using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioClip Saludo;
	public AudioClip Carta;
	public AudioClip Regalo;
	public AudioClip Agota;
	public AudioClip DebePuerta;
	public AudioClip Acaban;
	private bool saludo;
	private bool leyo, carta, regalo, agota, debePuerta, acaban;
	private AudioSource Source;
	public GameObject CartaMana;
	private float intro;
	private string sala;
	private float veneno;
	private float tiempoensala;
	private int fosforos;
	private static int conteo=0;
	public AudioClip Relacion;
	private static bool relacion = false;
	// Use this for initialization
	void Start () {
		intro = 51;
		Source = GetComponent<AudioSource>();
		saludo = false;
		leyo = CartaMana.GetComponent<GUICarta> ().getCartita();
		carta = false;
		sala = GameObject.FindGameObjectWithTag ("Player").GetComponent<PickUp> ().EscenaActual;
		veneno = GameObject.FindGameObjectWithTag ("Player").GetComponent<PickUp> ().getVeneno();
		fosforos= GameObject.FindGameObjectWithTag ("Player").GetComponent<PickUp> ().getFosforos();
		regalo = false;
		agota = false;
		debePuerta = false;
		tiempoensala = 300;
		acaban = false;
	}
	
	// Update is called once per frame
	void Update () {
		intro -= Time.deltaTime;
		tiempoensala -= Time.deltaTime;
		leyo = CartaMana.GetComponent<GUICarta> ().getCartita();
		veneno = GameObject.FindGameObjectWithTag ("Player").GetComponent<PickUp> ().getVeneno();
		fosforos= GameObject.FindGameObjectWithTag ("Player").GetComponent<PickUp> ().getFosforos();
		if (!saludo&&intro<=0&&sala=="Nivel1_Chumi") {
			Source.clip = Saludo;
			Source.Play ();
			saludo = true;
		}
		if (leyo&&!carta) {
			Source.clip = Carta;
			Source.Play ();
			carta = true;
		}
		if (carta && !leyo&&!regalo) {
			Source.clip = Regalo;
			Source.Play ();
			regalo = true;
			conteo++;
		}
		if (veneno <= 120&&!agota) {
			Source.clip = Agota;
			Source.Play ();
			agota = true;
		}
		if (tiempoensala <= 0&&!debePuerta) {
			Source.clip = DebePuerta;
			Source.Play ();
			debePuerta = true;
		}
		if (fosforos <= 5&&!acaban) {
			Source.clip = Acaban;
			Source.Play ();
			acaban = true;
		}
		if (conteo >= 3&&!relacion) {
			Source.clip = Relacion;
			Source.Play ();
			relacion = true;
		}
			
	}
}
