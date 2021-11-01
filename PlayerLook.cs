using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform player;
    public Player playerClass;
    public float sensitivity = 10;
    float x = 0;
    float y = 0;


    void Start()
    {
        //locking the cursor to the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //If game is paused then unlock the cursor so it can be moved
        if (PauseMenu.isPaused == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
        }
        //if its not then lock the cursor to the middle of the screen
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
        }



        //If game is not paused then let the player move the camera around and see
        if(PauseMenu.isPaused == false)
        {
            //input
            x += -Input.GetAxis("Mouse Y") * sensitivity;
            y += Input.GetAxis("Mouse X") * sensitivity;

            //clamping
            x = Mathf.Clamp(x, -90, 90);

            //rotation
            transform.localRotation = Quaternion.Euler(x, 0, 0);
            player.transform.localRotation = Quaternion.Euler(0, y, 0);
        }

        

        
    }
}
