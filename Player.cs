using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool isDead = false;
    public float health = 100f;


    void Update()
    {
        //The health is there so player can be able to take damage

        //Use 
        //   Player.health = Player.health - [Damage]
        // where [Damage] would be the damage given this can be used in any other script
        // if this player script is added

        // if this is not working then make a    public Player [variable name]
        // and change the "Player" in Player.health to [variable name]
    


        if(health == 0f)
        {
            isDead = true;
        }

    }

}
