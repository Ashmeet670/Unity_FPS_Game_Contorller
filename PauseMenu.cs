using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool isPaused = false;
    public bool CursoreIsLocked = false;
    public GameObject pauseMenuUI;

    


    
    void Update()
    {

        // use Escape key to pause the game - Change this by chnaing the "Escape" in KeyCode.Escape to the key of your choice
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Pause();
            
        }

        if(isPaused == true)
        {
            Pause();
        }
    }

    // Resuming
    public void Resume()
    {
        if(CursoreIsLocked == false )
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        
            
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    //Pausing
    public void Pause()
    {
       
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }



    

        
}
