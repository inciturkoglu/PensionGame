using UnityEditor.Rendering;
using UnityEngine;

public class TestInteractable : MonoBehaviour, IInteractable
{

    
    public bool CanInteract()
    {
        return true;
    }

    public void Interact()
    {
        Debug.Log("Etkinlesti!");

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
