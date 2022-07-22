using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class btnRight_Walk : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
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
        Debug.Log("TrueRight");
        animator.SetFloat("Vertical", 1);
        animator.SetFloat("Horizontal", 0);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("FalseRight");
        animator.SetFloat("Vertical", 0);
        animator.SetFloat("Horizontal", 0);
    }

}
