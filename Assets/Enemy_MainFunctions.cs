using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_MainFunctions : MonoBehaviour
{
    public int health;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
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
        Debug.Log("Damage Taken");
    }

}
