using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Trigger_btnDown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("T_Down");
        animator.SetBool("Bool_WalkDown", true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("F_Down");
        animator.SetBool("Bool_WalkDown", false);
    }
}