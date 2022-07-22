using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_MainFunctions : MonoBehaviour
{
    public int health;
    public float speed;

    // Update is called once per frame
    void Update()
    {  
        // If the health is 0, destroy the game object (enemy)
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        // Moves Enemy (basic for now)
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    //Enemy Takes Damage
    public void TakeDamage(int damage)
    {

        health -= damage;
        //Debug.Log("Damage Taken");
    }

}
