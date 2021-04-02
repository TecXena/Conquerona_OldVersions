using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public float healthGameTime;
    private bool stopTimer;
    
    void Start()
    {
        stopTimer = false;
        
        // Sets the Max Value and Starting Value of the slider
        slider.maxValue = healthGameTime;
        slider.value = healthGameTime;
    }



    void Update()
    {
        // Updates to decrease the value of the Linear Health Bar
        float time = healthGameTime - Time.time;
        
        if (time <= 0)
        {
            // Put here death animation and popup script to 
            // allow player to restart or go to main menu
            stopTimer = true;
        }

        if (stopTimer == false)
        {
            // Updates the value of the slider
            slider.value = time;
        }
    }


    // Sets the health of the player to the linear HealthGameTime slider
    public void SetMaxHealth(float health)
    {

        healthGameTime = health;     
    }

    // Reduces the linear healthGameTime value
    public void DealDamage (float damage)
    {
        healthGameTime -= damage;
    }

    // Increases the linear healthGameTime value
    public void RegainHealth (float health)
    {
        healthGameTime += health;
    }


}
