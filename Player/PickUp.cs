using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{

    public class PickUp : MonoBehaviour
    {
        public Texture can;
        public Texture bottle;
        public Texture tape;
        public GameObject[] props;

    
        public GameObject spawnObj;
        public GameObject[] iconsob;
        public RawImage[] icons;

        private GameObject droppedObj;
        private Rigidbody droppedRB;
        [Header("Pickup Settings")] [SerializeField]
        Transform holdArea;

        private GameObject actualObj;
        private GameObject heldObj;
        private Rigidbody heldObjRB;
        int j = 0;

        [Header("Physics Parameters")] [SerializeField]
        private float pickupRange;

        [SerializeField] private float pickupForce;

        void Start()
        {
            

            for (int i = 0; i < 5; i++)
                iconsob[i].SetActive(false);
        }

      
   

        private void Update()
        {
           
      


            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (iconsob[0].activeSelf)
                {

                    iconsob[0].SetActive(false);
                    if (icons[0].texture == bottle)
                        spawnObj = props[0];
                    else if (icons[0].texture == can)
                        spawnObj = props[1];
                    else if (icons[0].texture == tape)
                        spawnObj = props[2];
                    Instantiate(spawnObj, holdArea.position, Quaternion.identity);
                }

            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (iconsob[1].activeSelf)
                {

                    iconsob[1].SetActive(false);
                    if (icons[1].texture == bottle)
                        spawnObj = props[0];
                    else if (icons[1].texture == can)
                        spawnObj = props[1];
                    else if (icons[1].texture == tape)
                        spawnObj = props[2];
                    Instantiate(spawnObj, holdArea.position, Quaternion.identity);
                }

            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (iconsob[2].activeSelf)
                {

                    iconsob[2].SetActive(false);
                    if (icons[2].texture == bottle)
                        spawnObj = props[0];
                    else if (icons[2].texture == can)
                        spawnObj = props[1];
                    else if (icons[2].texture == tape)
                        spawnObj = props[2];
                    Instantiate(spawnObj, holdArea.position, Quaternion.identity);

                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (iconsob[3].activeSelf == true)
                {

                    iconsob[3].SetActive(false);
                    if (icons[3].texture == bottle)
                        spawnObj = props[0];
                    else if (icons[3].texture == can)
                        spawnObj = props[1];
                    else if (icons[3].texture == tape)
                        spawnObj = props[2];
                    Instantiate(spawnObj, holdArea.position, Quaternion.identity);

                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                if (iconsob[4].activeSelf == true)
                {

                    iconsob[4].SetActive(false);
                    if (icons[4].texture == bottle)
                        spawnObj = props[0];
                    else if (icons[4].texture == can)
                        spawnObj = props[1];
                    else if (icons[4].texture == tape)
                        spawnObj = props[2];
                    Instantiate(spawnObj, holdArea.position, Quaternion.identity);

                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                
                if (heldObj == null)
                {
                

                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,
                            pickupRange))
                    {
                        PickUpObject(hit.transform.gameObject);
                    
                      
                    }

                }
                else
                {

                    DropObject();
                    
                }
            }

            if (heldObj != null)
            {
                
                MoveObject();
               
                if (Input.GetKeyDown(KeyCode.E))
                {
                    

                    int nextavailableSlot = -1;
                    for (int i = 0; i < 5; i++)
                        if (!iconsob[i].activeSelf)
                        {
                            nextavailableSlot = i;
                            break;
                        }


                    if (nextavailableSlot != -1 && heldObj.CompareTag("bottle"))
                    {
                        icons[nextavailableSlot].texture = bottle;
                        iconsob[nextavailableSlot].SetActive(true);
                        j++;
                    }
                    else if (nextavailableSlot != -1 && heldObj.CompareTag("can"))
                    {
                        icons[nextavailableSlot].texture = can;
                        iconsob[nextavailableSlot].SetActive(true);
                        j++;
                    }
                    else if (nextavailableSlot != -1 && heldObj.CompareTag("tape"))
                    {
                        icons[nextavailableSlot].texture = tape;
                        iconsob[nextavailableSlot].SetActive(true);
                        j++;
                    }

                    //nextavailableSlot != -1 && mozda ke treba da se tweakne ako ima save i hotbarot e full
                    if (nextavailableSlot != -1)
                        Destroy(heldObj);

                    if (j == 5)
                    {

                        j = 0;
                    }
                }
            }
        }
        
        

        void MoveObject()
        {
            if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
            {
                Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
                heldObjRB.AddForce(moveDirection * pickupForce);
            }
        }

     
        void PickUpObject(GameObject pickObj)
        {
            if (pickObj.GetComponent<Rigidbody>())
            {
                
                heldObjRB = pickObj.GetComponent<Rigidbody>();
                heldObjRB.useGravity = false;
                heldObjRB.drag = 10;
                heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;
              
                heldObjRB.transform.parent = holdArea;
                heldObj = pickObj;
               

            }
        }

        void DropObject()
        {
            heldObjRB.useGravity = true;
            heldObjRB.drag = 1;
            heldObjRB.constraints = RigidbodyConstraints.None;
            
            heldObjRB.transform.parent = null;
            heldObj = null;
          
           
            
        }

      
    }
    
    
}