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

    //Enemy Takes Damage Method
    public void TakeDamage(int damage)
    {
        // Reduces Health by the damage of the player
        health -= damage;
        // Creates a new color that allows the red of the shader to appear 
        // gives it to the the MaterialTint_Damaged Script
        Color color = new Color(1, 0, 0, 1f);
        GetComponent<MaterialTint_Damaged>().SetTintColor(color);
        Debug.Log("Damage Taken " + health);
    }

}
