using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFosforo : MonoBehaviour {
	private GameObject player;
	private bool hayluz;
	private AudioSource Source;
	public AudioClip fosforo;
	private bool sono;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		sono = false;
		Source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		hayluz = player.GetComponent<PickUp> ().hayLuz;
		if (hayluz&&!sono) {
			Source.clip = fosforo;
			Source.Play ();
			sono = true;
		}
		if(!hayluz&&sono){
			sono = false;
		}
	}
}
