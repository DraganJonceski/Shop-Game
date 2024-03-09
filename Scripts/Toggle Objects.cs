using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObjects : MonoBehaviour
{
    public GameObject itemScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !itemScreen.activeSelf)
            itemScreen.SetActive(true);
        else if (Input.GetKeyDown(KeyCode.P))
            itemScreen.SetActive(false);
        
      
    }
}
