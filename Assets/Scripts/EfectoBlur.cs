using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class EfectoBlur : MonoBehaviour
{

    float video = 60;
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
            if (video <= 10 && video > 2)
            {
                mBlur.enabled = true;
            }
            if (video <= 2)
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
