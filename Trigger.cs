using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Trigger : MonoBehaviour
{
   
    public static int _moneyAmount;
    // Start is called before the first frame update
    void Start()
    {
        _moneyAmount = 100;
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision other)
    {
//        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Player"))
            return;
        
            _moneyAmount += 20;
            StateNameController.Budget.text = "Budget: " + _moneyAmount + "$";
            Destroy(other.gameObject);
        }
    
}
