using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideo : MonoBehaviour {

	public MovieTexture movText;
	private AudioSource sound;
	public Light Luz1;
	public Light Luz2;
	private bool Count = false;
	private float timer;
	// Use this for initialization
	void Start () {

		GetComponent<Renderer> ().material.mainTexture = movText as MovieTexture;
		sound = GetComponent<AudioSource> ();
		movText.Play ();
		Luz1.enabled = true;
		Luz2.enabled = true;
		Count = true;

	}

    //No
	public void Countdown ()
	{
		if (Count == true) {
			timer += Time.deltaTime;

			if (timer >= 82) {
				Luz1.enabled = false;
				Luz2.enabled = false;
				timer = 0;
				Count = false;
			}
		}
	}
	// Update is called once per frame
	void Update () {
		
			Countdown ();
		
	}
}
