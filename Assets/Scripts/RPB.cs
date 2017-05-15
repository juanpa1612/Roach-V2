using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RPB : MonoBehaviour {

    public Transform barraproreso;
    public Transform indicadortexto;
    public Transform cargatexto;
    [SerializeField]
    private float currentAmount;
    [SerializeField]
    private float speed;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (currentAmount < 100)
        {
            currentAmount += speed * Time.deltaTime;
            indicadortexto.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
            cargatexto.gameObject.SetActive(true);
        }
        else
        {
            cargatexto.gameObject.SetActive(false);
            indicadortexto.GetComponent<Text>().text = "Listo!";

        }
        barraproreso.GetComponent<Image>().fillAmount = currentAmount / 100;
	}
}
