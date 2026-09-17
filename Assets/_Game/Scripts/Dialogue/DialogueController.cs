using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField]
    private InputAction AdvanceDialogue;
    [SerializeField]
    private TMP_Text DialogueText;
    [SerializeField]
    private GameObject DialogueUI;
    private NPCInteraction currentSpeaker;
    List<string> currentLines;
    int currentLine;
    public void StartDialogue(NPCInteraction npcInteraction)
    {
        currentSpeaker=npcInteraction;
        currentLines=npcInteraction.npcDefinition.GetDialogueLines();
        currentLine=0;

        PositionDialogueBubble();
        DialogueUI.SetActive(true);

        DisplayCurrentLine();

    }
   public string GetCurrentLine()
    {
       return currentLines[currentLine];
    }
    
    public void DisplayCurrentLine()
    {
        DialogueText.text=GetCurrentLine();
    }
    public bool NextLine()
    {
        
        if(currentLine<currentLines.Count-1)
        {
            currentLine++;
            return true;
        }
        
        else {return false;}
    }

    public void PositionDialogueBubble()
    {
        
        DialogueUI.transform.position=currentSpeaker.BubbleAnchor.position;
    }

    public void EndDialogue()
    {
        DialogueUI.gameObject.SetActive(false);
    }

    public void Start()
    {
        AdvanceDialogue.Enable();
    }
    public void Update()
    {
        if(AdvanceDialogue.WasPressedThisFrame())
        {
            if(NextLine())
        {
            DisplayCurrentLine();
        }
        else
        {
            EndDialogue();
        }
        }

        
    }
}
