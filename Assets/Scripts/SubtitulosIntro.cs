using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtitulosIntro : MonoBehaviour {

    public Text subInicio;
    public Text subSiguiente;
    private double tiempo;

    private Color alphaInicio;
    private Color alphaSiguiente;

	// Use this for initialization
	void Start ()
    {
        tiempo = 90;
        alphaInicio = subInicio.color;
        alphaSiguiente = subSiguiente.color;
	}

    // Update is called once per frame
    void Update()
    {
        if (tiempo >= 0)
        {
            tiempo -= Time.deltaTime;
        }
        if (tiempo <= 85 && tiempo > 83)
        {
            alphaInicio.a += 0.8f * Time.deltaTime;
            subInicio.color = alphaInicio;
        }
        if (tiempo <= 81 && tiempo > 79)
        {
            Transicion("de mareo en su cabeza, la causa de esto");
        }
        if (tiempo <= 79 && tiempo > 77)
        {
            Transicion("es un potente veneno que acabará con su vida");
        }
        if (tiempo <= 77 && tiempo > 75)
        {
            Transicion("en exactamente 15 minutos");
        }
        if (tiempo <= 75 && tiempo > 73)
        {
            Transicion("atrás suyo se encuentra un pasillo");
        }
        if (tiempo <= 73 && tiempo > 71)
        {
            Transicion("que lo dirigirá a una de las 5 salas");
        }
        if (tiempo <= 71 && tiempo > 69)
        {
            Transicion("que conforman un laberinto a oscuras");
        }
        if (tiempo <= 69 && tiempo > 67)
        {
            Transicion("llegue a la quinta sala y podrá");
        }
        if (tiempo <= 67 && tiempo > 65)
        {
            Transicion("encontrar una llave que le permitirá");
        }
        if (tiempo <= 65 && tiempo > 63)
        {
            Transicion("abrir la puerta que se encuentra a su derecha");
        }
        if (tiempo <= 63 && tiempo > 61)
        {
            Transicion("y obtener el antidoto que anulará");
        }
        if (tiempo <= 61 && tiempo > 60)
        {
            Transicion("los efectos del veneno.");
        }
        if (tiempo <= 60 && tiempo > 58)
        {
            Transicion("Y si presta atención, podrá encontrar");
        }
        if (tiempo <= 58 && tiempo > 56)
        {
            Transicion("regalos hechos por mí");
        }
        if (tiempo <= 56 && tiempo > 54)
        {
            Transicion("trate de descifrar su significado");
        }
        if (tiempo <= 54 && tiempo > 52)
        {
            Transicion("y podría recompensarlo de alguna forma");
        }
        if (tiempo <= 52 && tiempo > 50)
        {
            Transicion("Le he dejado una caja de cerillos");
        }
        if (tiempo <= 50 && tiempo > 48)
        {
            Transicion("en su bolsillo, para que ilumine su");
        }
        if (tiempo <= 48 && tiempo > 46)
        {
            Transicion("camino en el laberinto, uselos bien");
        }
        if (tiempo <= 46 && tiempo > 45)
        {
            Transicion("si quiere vivir.");
        }
        if (tiempo <= 45 && tiempo > 43)
        {
            Transicion("Veamos si un tiempo en la oscuridad");
        }
        if (tiempo <= 43 && tiempo > 41)
        {
            Transicion("absoluta lo ayuda a recapacitar acerca");
        }
        if (tiempo <= 41 && tiempo > 39)
        {
            Transicion("de su obsesión conmigo.");
        }
        if (tiempo <= 39)
        {
            subInicio.gameObject.SetActive(false);
            subSiguiente.gameObject.SetActive(false);
        }
    }

    //Transicion

    public void Transicion (string textoNuevo)
    {
        alphaInicio.a = 0;
        subInicio.color = alphaInicio;

        alphaSiguiente.a = 1;
        subSiguiente.color = alphaSiguiente;

        subSiguiente.text = textoNuevo;
    }

}
