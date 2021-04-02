using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{

    public float maxHealth = 20;

    public HealthBar healthBar;
    

    
    void Awake()
    {
        // Send the health of the player to the HealthBar Script
        healthBar.SetMaxHealth(maxHealth);
        
    }

    // Update is called once per frame
    void Update()
    {
        // Prototype Damage
        if (Input.GetKeyDown(KeyCode.X))
        {
            healthBar.DealDamage(1);
        }

        // Prototype Heal
        if (Input.GetKeyDown(KeyCode.Z))
        {
            healthBar.RegainHealth(1);
        }

    }

}
