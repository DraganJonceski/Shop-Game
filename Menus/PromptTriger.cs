using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PromptTriger : MonoBehaviour
{
    public string title;
    public Image sprite;
    public string message;
 //   public Action confirmAction;
  //  public Action declineAction;

    public void Interact()
    {
        UIController.instance.modalWindow.ShowAsPrompt(title, sprite, message);
    }

   
}
