
using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float grounDrag;
    private bool isJumping;
    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatisground;
    bool grounded;
    
    public float jumpAmount = 10;
    public Transform orientation;
    float   yGroundPosBeforeJump;
    private float yGroundPosAfterJump;
    float horizontalInput;
    float verticalInput;
    Rigidbody rb;
    public float fallMultiplyer = 3f;
    
    Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatisground);
        MyInput();
        SpeedControl();
        if (grounded)
        {
            rb.drag = grounDrag;
         
        }
        else
            rb.drag = 0;

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * (Physics.gravity.y * (fallMultiplyer - 1) * Time.deltaTime);
        }
        
      
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping) //&& rb.velocity.y<1)
        {  
            rb.velocity = Vector2.up * jumpAmount;
            isJumping = true;
        }
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("sandground"))
        {
            isJumping = false;
        }
    }

    private void FixedUpdate()
    {
       
        MovePlayer();
      
        
    }
//TO DO FIX DOUBLE JUMP
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
   
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * (moveSpeed * 10f), ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude >moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

    }

}
