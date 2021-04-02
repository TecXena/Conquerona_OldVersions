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
            DealDamageShader();
        }

        // Prototype Heal
        if (Input.GetKeyDown(KeyCode.Z))
        {
            healthBar.RegainHealth(1);
        }

    }


    public void DealDamageShader (){
        Color color = new Color(1, 0, 0, 1f);
        GetComponent<MaterialTint_Damaged>().SetTintColor(color);
    }

}
