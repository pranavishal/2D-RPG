﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text dialogueText;
    public Text nameText;
    public GameObject dialogueBox;
    public GameObject nameBox;

    public string[] dialogueLines;

    public int currentLine;
    private bool justStarted;
    public static DialogManager instance;

    private string questToMark;
    private bool markQuestComplete;
    private bool shouldMarkQuest;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //ialogueText.text = dialogueLines[currentLine];
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire1") )
            {
                if (!justStarted)
                {
                    currentLine++;

                    if (currentLine >= dialogueLines.Length)
                    {
                        dialogueBox.SetActive(false);

                        GameManager.instance.dialogueActive = false;

                        if (shouldMarkQuest)
                        {
                            shouldMarkQuest = false;
                            if (markQuestComplete)
                            {
                                QuestManager.instance.MarkQuestComplete(questToMark);
                            }
                            else
                            {
                                QuestManager.instance.MarkQuestIncomplete(questToMark);
                            }
                        }
                    }
                    else
                    {
                        CheckIfName();
                        dialogueText.text = dialogueLines[currentLine];
                    }
                }
                else
                {
                    justStarted = false;
                }
               
            }
        }
        
    }

    public void ShowDialogue(string[] newLines, bool isPerson)
    {
        dialogueLines = newLines;

        currentLine = 0;

        CheckIfName();

        dialogueText.text = dialogueLines[currentLine];
        dialogueBox.SetActive(true);

        justStarted = true;

        nameBox.SetActive(isPerson);

        GameManager.instance.dialogueActive = true;
    }

    public void CheckIfName()
    {
        if (dialogueLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogueLines[currentLine].Replace("n-","");
            currentLine++;
        }
    }

    public void ShouldActivateQuestAtEnd(string questName, bool markComplete)
    {
        questToMark = questName;
        markQuestComplete = markComplete;

        shouldMarkQuest = true;
    }
}
