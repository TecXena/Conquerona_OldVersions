﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Trigger_BtnRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public Animator animator;

    private string currentState;

    // Animation State
    const string player_WalkRight = "Prototype_WalkRight";
    const string player_Idle = "Prototype_Idle";

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("T_Right_New");
        ChangeAnimationState(player_WalkRight);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("F_Right_New");
        ChangeAnimationState(player_Idle);
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }

}
