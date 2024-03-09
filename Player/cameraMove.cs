using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    
    //public Camera maincam;
    private void Start()
    {
      
        
       
    }
    public Transform cameraPos;
    // Update is called once per frame
    void Update()
    {if(cameraPos !=null)
        transform.position = cameraPos.position;
    }
}
