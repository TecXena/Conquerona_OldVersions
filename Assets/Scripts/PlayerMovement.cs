using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Animator animator;
    private Vector3 movementDirection = Vector3.zero;
    private Rigidbody2D rb;
    private bool moveLeft;
    private bool moveRight;
    private bool moveUp;
    private bool moveDown;
    private bool moveTopRight;
    private bool moveTopLeft;
    private bool moveBottomLeft;
    private bool moveBottomRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveLeft = false;
        moveRight = false;
        moveUp = false;
        moveDown = false;
        moveTopLeft = false;
        moveTopRight = false;
        moveBottomLeft = false;
        moveBottomRight = false;

    }

    void Update()
    {
        Direction();
    }

    private void FixedUpdate()
    {
        Move();
    }

    //Getting the value of x and y for movement
    private void Direction()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector3(moveX, moveY, 0);

        // For PC Movement
        animator.SetFloat("Horizontal", moveX);
        animator.SetFloat("Vertical", moveY);
        animator.SetFloat("Speed", movementDirection.sqrMagnitude);
        
        //Compared .GetAxis, yung .GetAxisRaw para medyo maging responsive ang galaw ng player
        //Tapos nilagay naman yung function ng move sa FixedUpdate()
    }

    private void Move()
    {
        //Movement for left button
        if (moveLeft)
        {
            if (moveTopLeft)
            {
                Debug.Log("Top Left");
                movementDirection += Vector3.up;
            }

            if (moveBottomLeft)
            {
                Debug.Log("Bottom Left");
                movementDirection -= Vector3.up;
            }
            Debug.Log("Left");
            movementDirection -= Vector3.right;
        }
        
        //Movement for right button
        if (moveRight)
        {
            if (moveTopRight)
            {
                Debug.Log("Top Right");
                movementDirection += Vector3.up;
            }

            if (moveBottomRight)
            {
                Debug.Log("Bottom Right");
                movementDirection -= Vector3.up;
            }
            Debug.Log("Right");
            movementDirection += Vector3.right;
        }

        //Movement for up button
        if (moveUp)
        {
            if (moveTopRight)
            {
                Debug.Log("Top Right");
                movementDirection += Vector3.right;
            }

            if (moveTopLeft)
            {
                Debug.Log("Top Left");
                movementDirection -= Vector3.right;
            }
            Debug.Log("Up");
            movementDirection += Vector3.up;
        }
        
        //Movement for down button
        if (moveDown)
        {
            if (moveBottomRight)
            {
                Debug.Log("Bottom Right");
                movementDirection += Vector3.right;
            }

            if (moveBottomLeft)
            {
                Debug.Log("Bottom Left");
                movementDirection -= Vector3.right;
            }
            Debug.Log("Down");
            movementDirection -= Vector3.up;
            /*movementDirection.y = -movementSpeed;*/
        }

        

        /*rb.velocity = new Vector3(movementDirection.x, movementDirection.y, 0);*/
        rb.MovePosition(transform.position + movementDirection.normalized * movementSpeed * Time.deltaTime);
    }

    //Button keys for detecting if the finger swipes in the 4 diagonal direction
    public void KeyDownTopRight()
    {
        moveTopRight = true;
    }

    public void KeyUpTopRight()
    {
        moveTopRight = false;
    }

    public void KeyDownTopLeft()
    {
        moveTopLeft = true;
    }

    public void KeyUpTopLeft()
    {
        moveTopLeft = false;
    }

    public void KeyDownBottomLeft()
    {
        moveBottomLeft = true;
    }

    public void KeyUpBottomLeft()
    {
        moveBottomLeft = false;
    }

    public void KeyDownBottomRight()
    {
        moveBottomRight = true;
    }

    public void KeyUpBottomRight()
    {
        moveBottomRight = false;
    }

    //For the left button (Key down, and key up)
    public void KeyDownLeft()
    {
        moveLeft = true;
    }


    public void KeyUpLeft()
    {
        moveLeft    = false;
    }

    //For the right button
    public void KeyDownRight()
    {
        moveRight = true;
    }

    public void KeyUpRight()
    {
        moveRight = false;
    }

    //For the up button
    public void KeyDownUp()
    {
        moveUp = true;
    }

    public void KeyUpUp()
    {
        moveUp = false;
    }
    //For the down button
    public void KeyDownDown()
    {
        moveDown = true;
    }

    public void KeyUpDown()
    {
        moveDown = false;
    }
}
