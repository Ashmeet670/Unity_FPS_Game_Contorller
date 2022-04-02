using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    public Transform _camera;

    public Transform player;
    

    public float moveSpeed = 6f;
    public float sprintSpeed = 2f;
    public float crouchSpeed = 3f;
    private float currentSpeed;
    private Vector3 playerTransform;
    public float jumpForce = 10f;
    public Camera playerCam;
    public LayerMask Ground;
    bool isGrounded;
    private bool crouched = false;


    void Start()
    {
        //setting current speed to moves speed so the crouch or sprint speed does not become the normal one - Just for check purpose
        currentSpeed = moveSpeed;
    }

    void Update()
    {
        //Enter Crouching - Simple Solution - Suitable for singleplayer as the transform is just shrinked down
        if (Input.GetKeyDown(KeyCode.C) && crouched == false)
        {
            playerTransform = player.transform.localScale;
            player.transform.localScale -= new Vector3(0, (float)0.6, 0);
            crouched = true;
        }

        //Exit crouching
        if(Input.GetKeyUp(KeyCode.C) && crouched == true)
        {
            player.transform.localScale = playerTransform;
            crouched = false;
        }

        //crouching
        if (crouched == true)
        {
            currentSpeed = moveSpeed;
            currentSpeed = crouchSpeed;
        }

        //Checking if player is on the ground
        isGrounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 0.4f, Ground);


        //facing direction line
        Debug.DrawLine(_camera.position, transform.forward * 2.5f);

       
       //sprinting
        if (Input.GetKey(KeyCode.LeftShift) && crouched == false)
        {
            currentSpeed = moveSpeed + sprintSpeed;
            
        }
        else
        {
            currentSpeed = moveSpeed;
        }

        //moving
        float x = Input.GetAxisRaw("Horizontal") * currentSpeed;
        float y = Input.GetAxisRaw("Vertical") * currentSpeed;


        
        //jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

        //setting movement
        Vector3 move = transform.right * x + transform.forward * y;
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);

    }

    




}
