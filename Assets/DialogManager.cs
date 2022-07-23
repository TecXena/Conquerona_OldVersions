using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogPanel;
    public Text npcNameText;
    public Text dialogText;
    public GameObject Controller;
    public GameObject BattleButtons;

    private List<string> conversation;
    private int convoIndex;


    private void Start()
    {
        dialogPanel.SetActive(false);
    }

    public void Start_Dialog(string _npcName, List<string> _convo)
    {
        npcNameText.text = _npcName;
        conversation = new List<string>(_convo);
        dialogPanel.SetActive(true);
        convoIndex = 0;
        ShowText();
        Controller.SetActive(false);
        BattleButtons.SetActive(false);
    }

    public void StopDialog()
    {
        Controller.SetActive(true);
        BattleButtons.SetActive(false);
        dialogPanel.SetActive(false);
    }

    private void ShowText()
    {
        dialogText.text = conversation[convoIndex];
    }

    public void Next()
    {
        if (convoIndex < conversation.Count - 1)
        {
            convoIndex += 1;
            ShowText();
        }
        else 
        {
            Controller.SetActive(true);
            BattleButtons.SetActive(false);
            dialogPanel.SetActive(false);
        }
    }

}
