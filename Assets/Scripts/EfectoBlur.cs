using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class EfectoBlur : MonoBehaviour
{

    float video = 70;
    MotionBlur mBlur;

    private void Start()
    {
        mBlur = GameObject.Find("FirstPersonCharacter").GetComponent<MotionBlur>();
        mBlur.enabled = false;
    }
    public void EfectoVeneno()
    {
        if ( video > 0)
        {
            if (video <= 20 && video > 5)
            {
                mBlur.enabled = true;
            }
            if (video <= 5)
            {
                mBlur.enabled = false;
            }
        }
      
    }
    private void Update()
    {
        video -= Time.deltaTime;
        EfectoVeneno();
        Debug.Log(video);
    }
}
