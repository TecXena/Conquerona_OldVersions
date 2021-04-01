﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Melee : MonoBehaviour
{

    public Joystick joystick;
    private Vector2 joystickPosition;
    private Vector2 joystickPositionOrigin; 
    public Animator meleeAnimator;
    public Transform attackPosition;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public float startTimeBtwAttack;
    public int damage;
    private string currentState;
    private float timeBtwAttack;
    
    // Animation States
    const string Melee_Attack = "Prototype_SwordAnimationForMelee";
    const string Melee_Idle = "Prototype_SwordAnimationIdle";


    // Start is called before the first frame update
    void Start()
    {
        joystickPositionOrigin = new Vector2(0,0);
        meleeAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Takes current Joystick position
        joystickPosition = new Vector2(joystick.Horizontal, joystick.Vertical);
        

        if(timeBtwAttack <= 0)
        {
            ChangeAnimationState(Melee_Idle);
            // Checks if Joystick Handle is not in the middle
            if (joystickPosition.x != joystickPositionOrigin.x && joystickPosition.y != joystickPositionOrigin.y)
            {
                ChangeAnimationState(Melee_Attack);
                // Range that checks the position, attack range and the enemies within the circle
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whatIsEnemies);

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    // takes the script of the enemies within the circle to take damage
                    enemiesToDamage[i].GetComponent<Enemy_MainFunctions>().TakeDamage(damage);
                }
                

            }
        // Makes the countdown come back
        timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
            
        }


    }


    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        meleeAnimator.Play(newState);

        currentState = newState;
    }
}
