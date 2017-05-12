using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMano : MonoBehaviour {

    public GameObject mano;
    private Vector3 posFinal;
    private Quaternion rotFinal;

    // Use this for initialization
    void Start()
    {
        posFinal = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        posFinal = mano.transform.position;
        rotFinal = mano.transform.rotation;
        this.gameObject.transform.position = posFinal;
        this.gameObject.transform.rotation = rotFinal;
	}
}
