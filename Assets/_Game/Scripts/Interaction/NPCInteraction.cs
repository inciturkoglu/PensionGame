using UnityEngine;

public class NPCInteraction : MonoBehaviour, IInteractable
{
    public Transform AnchorPoint;
    public bool CanInteract()
    {
        return true;
    }

    public Transform GetInteractionPoint()
    {
        return AnchorPoint;
    }

    public void Interact()
    {
        Debug.Log("Konusuldu!");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
