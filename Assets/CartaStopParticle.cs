using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaStopParticle : MonoBehaviour {

	public ParticleSystem Brillo;
	public GameObject Carta;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (Carta.activeInHierarchy == false){
			Brillo.Stop();
			Brillo.GetComponent<Light> ().enabled = false;
		}
	}
}
