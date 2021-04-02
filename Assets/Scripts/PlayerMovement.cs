using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject pressedButton;
    private Button btnTopRight;
    private Button btnTopLeft;
    private Button btnBottomRight;
    private Button btnBottomLeft;
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
    private bool pressing;
    private string btnName;
    private string changeDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        btnTopRight = GameObject.Find("btnTopRight").GetComponent<Button>();
        btnTopLeft = GameObject.Find("btnTopLeft").GetComponent<Button>();
        btnBottomRight = GameObject.Find("btnBottomRight").GetComponent<Button>();
        btnBottomLeft= GameObject.Find("btnBottomLeft").GetComponent<Button>();
        moveLeft = false;
        moveRight = false;
        moveUp = false;
        moveDown = false;
        moveTopLeft = false;
        moveTopRight = false;
        moveBottomLeft = false;
        moveBottomRight = false;
        pressing = false;

    }

    void Update()
    {
        Direction();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void HoveringButton()
    {
        /*EventSystem.current.SetSelectedGameObject(EventSystem.current.currentSelectedGameObject);
        Debug.Log("Currently Pressed:" + EventSystem.current.currentSelectedGameObject);*/
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


   //Function for appearing the certain direction when the main button is pressed
    public void ShowDiagonal()
    {
        btnName = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log("Currently pressed:" + btnName);

        if (btnName.Equals("btnRight"))
        {
            btnTopRight.interactable = true;
            btnBottomRight.interactable = true;
        }

        if (btnName.Equals("btnLeft"))
        {
            btnTopLeft.interactable = true;
            btnBottomLeft.interactable = true;
        }

        if (btnName.Equals("btnUp"))
        {
            btnTopLeft.interactable = true;
            btnTopRight.interactable = true;
        }

        if (btnName.Equals("btnDown"))
        {
            btnBottomLeft.interactable = true;
            btnBottomRight.interactable = true;
        }

    }

    //Function for hiding diagonal after not pressing a button

    public void HideDiagonal()
    {
        EventSystem.current.SetSelectedGameObject(null);
            btnTopRight.interactable = false;
            btnTopLeft.interactable = false;
            btnBottomLeft.interactable = false;
            btnBottomRight.interactable = false;
    }

    private void Move()
    {
        //Movement for left button
        if (moveLeft)
        {
            if (moveTopLeft)
            {
                //Debug.Log("Top Left");
                movementDirection += Vector3.up;
            }

            if (moveBottomLeft)
            {
                //Debug.Log("Bottom Left");
                movementDirection -= Vector3.up;
            }
            //Debug.Log("Left");
            movementDirection -= Vector3.right;
        }
        
        //Movement for right button
        if (moveRight)
        {
            if (moveTopRight)
            {
                //Debug.Log("Top Right");
                movementDirection += Vector3.up;
            }

            if (moveBottomRight)
            {
                //Debug.Log("Bottom Right");
                movementDirection -= Vector3.up;
            }
            //Debug.Log("Right");
            movementDirection += Vector3.right;
        }

        //Movement for up button
        if (moveUp)
        {
            if (moveTopRight)
            {
                //Debug.Log("Top Right");
                movementDirection += Vector3.right;
            }

            if (moveTopLeft)
            {
                //Debug.Log("Top Left");
                movementDirection -= Vector3.right;
            }
            //Debug.Log("Up");
            movementDirection += Vector3.up;
        }
        
        //Movement for down button
        if (moveDown)
        {
            if (moveBottomRight)
            {
                //Debug.Log("Bottom Right");
                movementDirection += Vector3.right;
            }

            if (moveBottomLeft)
            {
                //Debug.Log("Bottom Left");
                movementDirection -= Vector3.right;
            }
            //Debug.Log("Down");
            movementDirection -= Vector3.up;
        }

        

        /*rb.velocity = new Vector3(movementDirection.x, movementDirection.y, 0);*/
        rb.MovePosition(transform.position + movementDirection.normalized * movementSpeed * Time.deltaTime);
    }

//Button keys for detecting if the player tries to change the initiated movement to another direction
    public void ChangeToUp()
    {
        changeDirection = "Up";

    }

    public void RevertFromUp()
    {
        changeDirection = "";
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
