using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public float bulletSpeed;
    public int bulletDmg;
    private Vector2 direction;
    
    // Start is called before the first frame update
    void Start()
    {
        // Finds the direction GameObject and the rotation of the bullet
        direction = GameObject.Find("Direction").transform.position;
        transform.position = GameObject.Find("ShootingPoint").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // moves the bullet towards the direction GameObject
        transform.position = Vector2.MoveTowards(transform.position, direction, bulletSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Gets the functions of the enemy script 
        Enemy_MainFunctions enemy = hitInfo.GetComponent<Enemy_MainFunctions>();
        if (enemy != null)
        {
            enemy.TakeDamage(bulletDmg);
        }
        Destroy(gameObject);
    }
}
