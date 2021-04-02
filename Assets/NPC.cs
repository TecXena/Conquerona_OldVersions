using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string npcName;
    public DialogManager dialogManager;
    public List<string> npcConvo = new List<string>();

    //public void OnMouseDown() // starts dialog by clicking on object
    //{
    //    dialogManager.Start_Dialog(npcName, npcConvo);
    //}
    public void OnCollisionEnter2D(Collision2D other) // starts dialog by colliding with object
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogManager.Start_Dialog(npcName, npcConvo);
        }
    }
}
