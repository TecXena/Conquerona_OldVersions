using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Melee : MonoBehaviour
{
    public float timeBtwAttack;
    public float startTimeBtwAttack;
    public Joystick joystick;
    private Vector2 joystickPosition;
    private Vector2 joystickPositionOrigin; 
    public Animator meleeAnimator;

    public Transform attackPosition;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public int damage;

    
 /* 
    private string currentState;

    Animation States

    const string Melee_Attack = "Prototype_SwordAnimationForMelee";
    const string Melee_Idle = "Prototype_SwordAnimationIdle";
*/
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
            if (joystickPosition.x != joystickPositionOrigin.x && joystickPosition.y != joystickPositionOrigin.y)
            {
                meleeAnimator.Play("Prototype_SwordAnimationForMelee");
                //ChangeAnimationState(Melee_Attack);

                
                // Range that checks the position, attack range and the enemies within the circle
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whatIsEnemies);

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    // takes the script of the enemy within the circle to take damage
                    enemiesToDamage[i].GetComponent<Enemy_MainFunctions>().TakeDamage(damage);
                }

            }

        timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
            //ChangeAnimationState(Melee_Idle);
        }


    }

/* 
    public void ChangeAnimationState(string newState)
    {

    }
*/


}
