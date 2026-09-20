using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.OSX;
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

    Coroutine typingCoroutine;
    
    private IEnumerator TypeLine(string line)
    {
        DialogueText.text=line;
        DialogueText.maxVisibleCharacters= 0;
        for(int i=0;i<line.Length; i++)
        {
            DialogueText.maxVisibleCharacters=i+1;
            yield return new WaitForSeconds(0.05f);
        }
        typingCoroutine=null;
    }
    public void StartDialogue(NPCInteraction npcInteraction)
    {
        currentSpeaker=npcInteraction;
        currentLines=npcInteraction.npcDefinition.GetDialogueLines();
        currentLine=0;

        AdvanceDialogue.Enable();

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
        typingCoroutine=StartCoroutine(TypeLine(GetCurrentLine()));

    }

    public void CompleteCurrentLine()
    {
        if(typingCoroutine!=null)
        {
            DialogueText.maxVisibleCharacters=GetCurrentLine().Length;
            StopCoroutine(typingCoroutine);
        }
            
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
        
    }
    public void Update()
    {
        if(AdvanceDialogue.WasPressedThisFrame())
        {
            if(typingCoroutine!=null)
        {
            CompleteCurrentLine();
            typingCoroutine=null;
        }
        else
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

}

