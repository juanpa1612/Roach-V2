using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUp : MonoBehaviour {

    public int distanceToItem;
    public GameObject carta;
	public GameObject pasoDeNivel;
	private float timerFosforo;
	private GameObject lightGameObject;
	public ParticleSystem fosforo;
	//public Light luz;
	private bool hayLuz, TEST;
	public int cantFosforos;
	public float veneno;
	GUIStyle Dibujarmensaje;
	public string EscenaSiguiente, EscenaActual;
	public GameObject Match;

    private GameObject barraFosforo;

	// Use this for initialization
	void Start ()
    {
		timerFosforo = 5;
		//cantFosforos = 2;
		hayLuz = false;
		lightGameObject = new GameObject ("The Light");
		Light lightComp = lightGameObject.AddComponent<Light> ();
		lightComp.color = Color.red;
		lightComp.color += Color.yellow;
		lightComp.range = 10;
		lightComp.intensity = 3;
		lightComp.bounceIntensity = 1;
		lightGameObject.gameObject.GetComponent<Light> ().enabled = false;
		fosforo.Stop();
		Dibujarmensaje = new GUIStyle ();
		Dibujarmensaje.normal.textColor = Color.white;
		Dibujarmensaje.fontSize = 30;

        barraFosforo = GameObject.Find("BarraLlena");
        
	}


	// Update is called once per frame
	void Update ()
    {
		veneno -= Time.deltaTime;
		if (veneno <= 0) {
			SceneManager.LoadScene (EscenaActual);
		}
		if(hayLuz){	
			timerFosforo -= Time.deltaTime;
			fosforo.transform.position = Match.transform.position;
			fosforo.transform.position.Set (fosforo.transform.position.x, fosforo.transform.position.y , fosforo.transform.position.z);
			lightGameObject.transform.position = fosforo.transform.position;
		}
        Collect();
		if (Input.GetKeyDown(KeyCode.F))
        {
			CrearFosforo ();
            barraFosforo.GetComponent<Animator>().SetBool("Fuego", true);
		}
		if (timerFosforo <= 0) {
			DestruirFosforo ();
            barraFosforo.GetComponent<Animator>().SetBool("Fuego", false);
        }
	}

	void OnGUI(){
		if (TEST) {
			Rect RectMensaje = new Rect (520, 520, 100, 100);
			GUI.Label (RectMensaje, "Presiona R para pasar al siguiente cuarto", Dibujarmensaje);
		}
	}

    void Collect ()
    { 
			RaycastHit hit;
			Ray rayo = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast (rayo, out hit, distanceToItem)) {
			if (hit.collider.gameObject == carta) {
				if (Input.GetMouseButtonUp (0)) {	
					Debug.Log ("PickUp");
					carta.SetActive (false);
				}
                    
			}

			if (hit.collider.gameObject == pasoDeNivel) {
				TEST = true;
				if (Input.GetKeyUp (KeyCode.R)) {
					SceneManager.LoadScene (EscenaSiguiente);
				}
			}
		} else {
			TEST = false;		
		}
    }

	void CrearFosforo(){
		if(!hayLuz&&cantFosforos>0){
			lightGameObject.gameObject.GetComponent<Light> ().enabled = true;
			fosforo.Play ();
			hayLuz = true;
			cantFosforos -= 1;
		}
	}

	void DestruirFosforo(){
		lightGameObject.gameObject.GetComponent<Light> ().enabled = false;
		fosforo.Stop ();
		hayLuz = false;
		timerFosforo = 5;
	}

	public void sumarFosforos(int numSumar){
		cantFosforos += numSumar;
	}
}
