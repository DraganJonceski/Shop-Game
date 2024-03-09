using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    private bool finished;
    void Start()
    {

        
    }
    
    void Update()
    {
        if (transform.position.x < -35)
        {
            transform.Translate(0,0,0.03f);
        }
       else if (transform.position.x < -20)
        {
            transform.Translate(0,0,0.02f);
        }
        else if (transform.position.x < -15)
        {
            transform.Translate(0,0,0.01f);
            
            
        }
            if (transform.position.x >= -15 && !finished)
            {
            
                GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                capsule.transform.position = new Vector3(-13, 8, 12);
                finished = true;
            }

    }
}
