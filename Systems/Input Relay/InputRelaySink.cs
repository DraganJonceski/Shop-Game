using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class InputRelaySink :MonoBehaviour
{
   
    
    public int[] buyprice = { 4, 3, 2 };
public int[] sellprice = { 3, 2, 1 };
public bool[] canSellIt = { true, true, true };
[SerializeField] RectTransform canvasTransform;
public static float[] itemnums = { 2, 4, 7 };
string _taged = "";
int index = 0;
GraphicRaycaster _raycaster;

//public TextMeshProUGUI budget;
    public TextMeshProUGUI[] itemAmount;
List <GameObject> DragTargets = new List<GameObject>();
    void Start()
    {
      
    itemAmount[0].text = "Bottle x" + itemnums[0].ToString();
    itemAmount[1].text = "Can    x" + itemnums[1].ToString();
    itemAmount[2].text = "Tape   x" + itemnums[2].ToString();
    _raycaster = GetComponent<GraphicRaycaster>();
}

    void Update()
    {

  //  budget.text = "Budget: " + _moneyAmount.ToString() + "$";
}

public void OnCursorInput(Vector2 normalisedPosition)
{
   // calculate position in canvas space
        Vector3 mousePosition = new Vector3(canvasTransform.sizeDelta.x * normalisedPosition.x,
                                            canvasTransform.sizeDelta.y * normalisedPosition.y, 0f);

  //  construct pointer event
        PointerEventData mouseEvent = new PointerEventData(EventSystem.current);
    mouseEvent.position = mousePosition;

   // does a raycast using the graphics raycaster
    List<RaycastResult> results = new List<RaycastResult>();
    _raycaster.Raycast(mouseEvent, results);

    bool sendMouseDown = Input.GetMouseButtonDown(0);
    bool sendMouseUp = Input.GetMouseButtonUp(0);
    bool isMouseDown = Input.GetMouseButton(0);

   // sennd through end drag events as needed
        if (sendMouseUp)
    {
        foreach (var target in DragTargets)
        {
            if (ExecuteEvents.Execute(target, mouseEvent, ExecuteEvents.endDragHandler))
                break;
        }
        DragTargets.Clear();
    }

    //process the raycast results
        foreach (var result in results)
    {
      //  setup the new event data
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = mousePosition;
        eventData.pointerCurrentRaycast = eventData.pointerPressRaycast = result;

        if (isMouseDown)
            eventData.button = PointerEventData.InputButton.Left;

      //  potential new drag targets
            if (sendMouseDown)
        {


            if (ExecuteEvents.Execute(result.gameObject, eventData, ExecuteEvents.beginDragHandler))
                DragTargets.Add(result.gameObject);
        }
      //  need to update drag target
            else if (DragTargets.Contains(result.gameObject))
        {
            eventData.dragging = true;
            ExecuteEvents.Execute(result.gameObject, eventData, ExecuteEvents.dragHandler);
        }

        if (sendMouseDown)
        {
            if (ExecuteEvents.Execute(result.gameObject, mouseEvent, ExecuteEvents.pointerDownHandler))
            {

                break;
            }
        }
        else if (sendMouseUp)
        {
            bool didRun = ExecuteEvents.Execute(result.gameObject, mouseEvent, ExecuteEvents.pointerUpHandler);
            didRun = ExecuteEvents.Execute(result.gameObject, mouseEvent, ExecuteEvents.pointerClickHandler);

            if (didRun)
            {
                if (result.gameObject.CompareTag("bottle"))
                {
                    _taged = "Bottle";
                    index = 0;
                }
                else if (result.gameObject.CompareTag("can"))
                {
                    _taged = "Can";
                    index = 1;
                }
                else if (result.gameObject.CompareTag("tape"))
                {
                    _taged = "Tape";
                    index = 2;
                }
                if (_taged != "")
                    if (result.gameObject.CompareTag("Buy"))
                    {
                       Trigger._moneyAmount -= buyprice[index];
                        itemnums[index] = itemnums[index] + 0.5f;
                        itemAmount[index].text = _taged + " x" + itemnums[index].ToString();
                        StateNameController.Budget.text =  "Budget: " + Trigger._moneyAmount.ToString()  + "$"; 

                    }
                if (result.gameObject.CompareTag("Sell"))
                {
                    if (itemnums[index] != 0)
                        canSellIt[index] = true;
                    if (canSellIt[index])
                        if (_taged !="")
                        {
                            Trigger._moneyAmount += sellprice[index];

                            itemnums[index] = itemnums[index] - 0.5f;
                            StateNameController.Budget.text =  "Budget: " + Trigger._moneyAmount.ToString()  + "$"; 
                            itemAmount[index].text = _taged + " x" + itemnums[index].ToString();
                            if (itemnums[index] == 0)
                            {
                                canSellIt[index] = false;
                            }


                        }
                }
                break;
            }

        }

    }


}
}
