using System;
using UnityEngine;
using TMPro;
using UnityEditor;

public class StateNameController : MonoBehaviour
{
    public static TextMeshProUGUI Budget;
    public static int SensitivityValue = 400;
    public static int FovValue = 60;

    

    private void Awake()
    {
    Budget = GameObject.Find("Budget").GetComponent<TextMeshProUGUI>();
    
}

   
}
