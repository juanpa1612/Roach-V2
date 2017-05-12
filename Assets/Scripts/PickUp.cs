using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Reflection;
public class PickUp : MonoBehaviour {

    public int distanceToItem;
    public GameObject carta;
	public GameObject pasoDeNivel;
	private float timerFosforo;
	private GameObject lightGameObject;
	public ParticleSystem fosforo;
	//public Light luz;
	public bool hayLuz, TEST, mostrarCarta;
	private static int cantFosforos=30;
	private static float veneno=900;
	private float venenoStage;
	private int cantFosforosStage;
	GUIStyle Dibujarmensaje;
	public string EscenaSiguiente, EscenaActual;
	public GameObject Pointer;
	private float video;
    private GameObject barraFosforo;
	public GameObject Hand, Match;
	private Animator HandAnim, MatchAnim;
	public Component movimiento;
	public FieldInfo fi;

    public Text txtClick;
    public Text txtTutorial;
    private Color colorFinal;
    private bool subirAlpha;

    private bool cadaver;
    public GameObject gmCadaver;

	// Use this for initialization
	void Start ()
    {
        colorFinal = txtTutorial.color;
        txtTutorial.gameObject.SetActive(false);
        cadaver = false;

        Hand.SetActive (false);
		Match.SetActive (false);
		HandAnim = Hand.GetComponent<Animator> ();
		MatchAnim = Match.GetComponent<Animator> ();

        txtClick.gameObject.SetActive(false);
        txtTutorial.gameObject.SetActive(false);

        venenoStage = veneno;
		cantFosforosStage = cantFosforos;
		timerFosforo = 10;
		//cantFosforos = 2;
		//hayLuz = false;
		lightGameObject = new GameObject ("The Light");
		Light lightComp = lightGameObject.AddComponent<Light> ();
		lightComp.color = Color.red;
		lightComp.color += Color.yellow;
		lightComp.range = 5;
		lightComp.intensity = 1;
		lightComp.bounceIntensity = 0.5f;
		lightGameObject.gameObject.GetComponent<Light> ().enabled = false;
		fosforo.Stop();
		Dibujarmensaje = new GUIStyle ();
		Dibujarmensaje.normal.textColor = Color.white;
		Dibujarmensaje.fontSize = 30;
		video = 51;
        barraFosforo = GameObject.Find("BarraLlena"); 
        
	}

	public int getFosforos(){
		return cantFosforos;
	}
	public float getVeneno(){
		return veneno;
	}
    public bool getCadaver()
    {
        return cadaver;
    }

    // Update is called once per frame
    void Update ()
    {

        if (EscenaActual == "Nivel1_Chumi")
        {
			video -= Time.deltaTime;
        }
        else
        {
			video = 0;
		}
		if (video <= 0)
        {			
			veneno -= Time.deltaTime;
            //Texto Tutorial
            txtTutorial.gameObject.SetActive(true);
            if (subirAlpha==false && txtTutorial.color.a <=1)
            {
                colorFinal.a += 1 * Time.deltaTime;
                txtTutorial.color = colorFinal;
            }
        }
        if (txtTutorial.color.a >= 1 && subirAlpha==false)
        {
            StartCoroutine(Tutorial());
        }
        if (veneno <= 0)
        {
			veneno = venenoStage;
			cantFosforos = cantFosforosStage;
			SceneManager.LoadScene (EscenaActual);
		}
		if(hayLuz == false){	
			//timerFosforo -= Time.deltaTime;
			fosforo.transform.position = Pointer.transform.position;
			//fosforo.transform.position.Set (Match.transform.position.x, Match.transform.position.y , Match.transform.position.z);
			//lightGameObject.transform.position = fosforo.transform.position;
			lightGameObject.transform.position = Pointer.transform.position;
		}
		if(hayLuz == true){	
			timerFosforo -= Time.deltaTime;
			if (timerFosforo <= 3f) {
				HandAnim.Play ("H_Idle");
				MatchAnim.Play ("M_Idle");
			}
			fosforo.transform.position = Pointer.transform.position;
			//fosforo.transform.position.Set (Match.transform.position.x, Match.transform.position.y , Match.transform.position.z);
			//lightGameObject.transform.position = fosforo.transform.position;
			lightGameObject.transform.position = Pointer.transform.position;
		}
        Collect();
		if ((Input.GetKeyDown(KeyCode.F)||(Input.GetButtonUp("Xbox_A")))&&video<=0)
        {
			CrearFosforo ();
            barraFosforo.GetComponent<Animator>().SetBool("Fuego", true);
		}
		if (timerFosforo <= 0) {
			DestruirFosforo ();
            barraFosforo.GetComponent<Animator>().SetBool("Fuego", false);
        }
	}

	void OnGUI()
    {
		if (TEST)
        {
            /*
            Rect RectMensaje = new Rect (520, 470, 100, 100);
			GUI.Label (RectMensaje, "Presiona R para pasar al siguiente cuarto", Dibujarmensaje);
            */

            txtClick.gameObject.SetActive(true);
            txtClick.text = "Presiona Y para pasar al siguiente cuarto";
            txtClick.CrossFadeAlpha(1, .5f, false);
		}
		if (mostrarCarta)
        {
            /*
			Rect RectMensaje = new Rect (520, 470, 100, 100);
			GUI.Label (RectMensaje, "Haz click para leer la carta", Dibujarmensaje);
            */
            txtClick.gameObject.SetActive(true);
            txtClick.text = "Presiona X para leer la carta";
            txtClick.CrossFadeAlpha(1, 0.5f, false);


		}
	}

    void Collect ()
    { 
			RaycastHit hit;
			Ray rayo = Camera.main.ScreenPointToRay (Input.mousePosition);

        //Si esta apuntando

		if (Physics.Raycast (rayo, out hit, distanceToItem))
        {
			if (hit.collider.gameObject == carta)
            {
				mostrarCarta = true;
				if (Input.GetMouseButtonUp (0)||(Input.GetButtonUp("Xbox_X")))
                {
					carta.SetActive (false);
                    //txtTutorial.text = "Presiona B para dejar de leer la carta";
                    //txtTutorial.CrossFadeAlpha(1, .5f, false);
                }
                    
			} 

			if (hit.collider.gameObject == pasoDeNivel)
            {
				TEST = true;
				if (Input.GetKeyUp (KeyCode.R)||(Input.GetButtonUp("Xbox_Y")))
                {
					if (EscenaActual == "Nivel2") {
						veneno = 900;
						cantFosforos = 30;
					}
					SceneManager.LoadScene (EscenaSiguiente);

				}

            }
            if (hit.collider.gameObject == gmCadaver)
            {
                cadaver = true;
            }
        }
        else
        {
            //Si no esta apuntando
            TEST = false;		
			mostrarCarta = false;
            cadaver = false;
            //txtClick.gameObject.SetActive(true);
            txtClick.CrossFadeAlpha(0, 0.5f, false);
        }
    }

	void CrearFosforo(){
		if(!hayLuz&&cantFosforos>0){
			Hand.SetActive (true);
			Match.SetActive (true);
			lightGameObject.gameObject.GetComponent<Light> ().enabled = true;
			fosforo.Play ();
			HandAnim.Play ("H_Light");
			MatchAnim.Play ("M_Light");
			hayLuz = true;
			cantFosforos -= 1;
		}
	}

	void DestruirFosforo(){
		lightGameObject.gameObject.GetComponent<Light> ().enabled = false;
		fosforo.Stop ();
		HandAnim.Play ("H_Drop");
		Match.SetActive (false);
		hayLuz = false;
		timerFosforo = 10;
	}

	public void sumarFosforos(int numSumar)
    {
		cantFosforos += numSumar;
	}

    IEnumerator Tutorial()
    {
        subirAlpha = true;
        yield return new WaitForSeconds(5f);
        txtTutorial.CrossFadeAlpha(0, 1f, false);
        
    }
}
