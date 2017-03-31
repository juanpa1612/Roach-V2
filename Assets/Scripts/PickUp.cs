using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public int distanceToItem;
    public GameObject carta;
	private float timerFosforo;
	private GameObject lightGameObject;
	public ParticleSystem fosforo;
	//public Light luz;
	private bool hayLuz;
	public int cantFosforos;

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
	}
	
	// Update is called once per frame
	void Update ()
    {
		
		if(hayLuz){	
			timerFosforo -= Time.deltaTime;
			fosforo.transform.position = this.transform.position+this.transform.forward*1;
			fosforo.transform.position.Set (fosforo.transform.position.x, 30, fosforo.transform.position.z);
			lightGameObject.transform.position = fosforo.transform.position;
		}
        Collect();
		if (Input.GetKeyDown(KeyCode.F)) {
			CrearFosforo ();
		}
		if (timerFosforo <= 0) {
			DestruirFosforo ();
		}

	}

    void Collect ()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(rayo,out hit,distanceToItem))
            {
                if (hit.collider.gameObject == carta)
                {
                    Debug.Log("PickUp");
                    carta.SetActive(false);
                    
                }
            }
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
}
