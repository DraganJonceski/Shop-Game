using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Serialization;

public class ModalWindowPanel : MonoBehaviour
{
   
    [Header("Header")]
    [SerializeField]
    private Transform headerArea;
    [SerializeField]
    private TextMeshProUGUI titlefield;
    [Header("Content")]
    [SerializeField]
    private Transform contentArea;
    [SerializeField] 
    private TextMeshProUGUI ItemSelectedText;
   // [SerializeField] private Transform varticalLayoutArea; [SerializeField] private Image heroImage;[SerializeField] private TextMeshProUGUI heroText; //[Space()]
    

    public GameObject horizontalLayoutArea;

    [SerializeField]
    private Transform buySellBox;
    [SerializeField]
    private Image popUpImage;
    [SerializeField]
    private TextMeshProUGUI popUpText;
    [SerializeField]
    private Transform iconContainer;

    [Header("Footer")]
    [SerializeField]
    private Transform footerArea;
    [SerializeField]
    private Button confirmButton;
    [SerializeField]
    private Button declineButton;
    
    private Action _confirmAction;
    private Action _declineAction;

    private bool[] _selected = new bool [3];
    
   // public TextMeshProUGUI budgetReference;
   // public   TextMeshProUGUI budgetText;

    private void Start()
    {
      
      
    }
  

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.M) && !buySellBox.gameObject.activeSelf)
        {
            buySellBox.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            buySellBox.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void SelectBottle()
    {
      
        _selected[0] = true;
        _selected[1] = false;
        _selected[2] = false;
        ItemSelectedText.text = "Bottle Selected";
    }
    public void SelectCan()
    {
        _selected[0] = false;
        _selected[1] = true;
        _selected[2] = false;
        ItemSelectedText.text = "Can Selected";
    }
    public void SelectTape()
    {
        
        _selected[0] = false;
        _selected[1] = false;
        _selected[2] = true;
        ItemSelectedText.text = "Tape Selected";
    }

    public bool[] isInOrder = {false, false, false};
    
    public void ShowAsPrompt(string title, Image icon, string message )
    {
        LeanTween.cancel(gameObject);

        horizontalLayoutArea.SetActive(true);

      //  bool hasTitle = string.IsNullOrEmpty(title);
      //  headerArea.gameObject.SetActive(hasTitle);
        titlefield.text = title;

        popUpImage = icon;
        popUpText.text = message;
    


    }
   
 
    
    public void Buy()
    {
        
        
        if (_selected[0])
        {
            Trigger._moneyAmount -= 6;
            StateNameController.Budget.text =  "Budget: " + Trigger._moneyAmount.ToString()  + "$";
        }
        if (_selected[1])
        {
            Trigger._moneyAmount -= 5;
            StateNameController.Budget.text =  "Budget: " + Trigger._moneyAmount.ToString()  + "$";
        }
        if (_selected[2])
        {
            Trigger._moneyAmount -= 4;
            StateNameController.Budget.text =  "Budget: " + Trigger._moneyAmount.ToString()  + "$";
        }
    
        
    }

    public void Sell()
    {
        if (_selected[0])
        {
            Trigger._moneyAmount += 5;
            StateNameController.Budget.text =  "Budget: " + Trigger._moneyAmount.ToString()  + "$";
        }
        if (_selected[1])
        {
            Trigger._moneyAmount += 4;
            StateNameController.Budget.text =  "Budget: " + Trigger._moneyAmount.ToString()  + "$";
        }
        if (_selected[2])
        {
            Trigger._moneyAmount += 3;
            StateNameController.Budget.text =  "Budget: " + Trigger._moneyAmount.ToString()  + "$";
        }
    }

    public void Confirm()
    {
       // _confirmAction?.Invoke();
       horizontalLayoutArea.SetActive(false);
       // isInOrder[0] = true;
        Cursor.lockState = CursorLockMode.Locked;
       // Debug.Log((isInOrder[0]));
    }

    public void Decline()
    {
       // _declineAction?.Invoke();
       horizontalLayoutArea.SetActive(false);
         Cursor.lockState = CursorLockMode.Locked;
    }
}
