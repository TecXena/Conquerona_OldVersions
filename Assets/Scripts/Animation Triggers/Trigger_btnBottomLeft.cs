﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Trigger_btnBottomLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Animator animator;
    private string currentState;

    // Animation State
    const string player_WalkLeft = "Prototype_WalkLeft";
    const string player_Idle = "Prototype_Idle";
    
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("T_BottomLeft_New");
        ChangeAnimationState(player_WalkLeft);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("F_BottomLeft_New");
        ChangeAnimationState(player_Idle);
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }

}
