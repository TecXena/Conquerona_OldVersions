using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Trigger_btnUp : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Animator animator;
    private string currentState;

    // Animation State
    const string player_WalkUp = "Prototype_WalkUp";
    const string player_Idle = "Prototype_Idle";
    


    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("T_Up_New");
        ChangeAnimationState(player_WalkUp);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("F_Up_New");
        ChangeAnimationState(player_Idle);
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }
}