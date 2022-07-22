using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Attack_Shoot : MonoBehaviour
{

    public Transform shootingPoint;
    public Joystick joystick;
    public GameObject bulletRed;
    public GameObject bulletBlue;
    public GameObject bulletPink;
    public int bulletType;

    private float timeOfLastShot;
    private float cooldown = 1;
    private Vector2 joystickPosition;
    private Vector2 joystickPositionOrigin; 


    void Start()
    {
        joystickPositionOrigin = new Vector2(0,0);
    }

    void Update()
    {  
        // Updates the x and y position of the joystick
        joystickPosition = new Vector2(joystick.Horizontal, joystick.Vertical);

         //Checks if Joystick position is not equals to 0,0 and the cooldown of the bullets
        if (joystickPosition.x != joystickPositionOrigin.x && joystickPosition.y != joystickPositionOrigin.y && Time.time > timeOfLastShot + cooldown)
        {
            //Shoots and records the time of the last shot
            Shoot();
            timeOfLastShot = Time.time;
        }
    }
    public void Shoot()
    {   // Creates a bullet and positions it to shooting point

                GameObject bulletCloneRed = Instantiate(bulletRed, shootingPoint.position ,shootingPoint.rotation);
                Rigidbody2D bulletRigidBodyRed = bulletCloneRed.GetComponent<Rigidbody2D>();
                
        // bulletRigidBody.AddForce(shootingPoint.up * bulletSpeed * Time.deltaTime, ForceMode2D.Impulse);     Has issues and works for x axis only
        
    }




}
