using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCDefinition", menuName = "Scriptable Objects/NPCDefinition")]
public class NPCDefinition : ScriptableObject
{
    [SerializeField]
    private string ID;
    [SerializeField]
    private string Name;

    [SerializeField]
    private List<string> dialogueLines;

    public List<string> GetDialogueLines()
    {
        return dialogueLines;
    }
}
