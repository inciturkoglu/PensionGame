using System;
using Unity.Multiplayer.Center.Common.Analytics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerInteractor : MonoBehaviour
{
    public InputAction interactAction;
    [SerializeField]
    private float interactionRadius= 3f;
    [SerializeField]
     private Transform interactOrigin;

     IInteractable currentInteractable;

    

     void Start()
    {
       interactAction.Enable();
    }

   
    void Update()
    {
        

         float closestdistance= float.MaxValue;
         currentInteractable=null;

    Collider[] nearbyColliders = Physics.OverlapSphere(interactOrigin.position, interactionRadius);
    

        foreach(Collider collider in nearbyColliders)
        {
          IInteractable interactable = collider.gameObject.GetComponent<IInteractable>();
            
            if(interactable!=null)
            { 
                Debug.Log("Interactable Bulundu");
             if(interactable.CanInteract())
             {
                float currentDistance = Vector3.Distance(interactOrigin.position,collider.transform.position);
                     
                    if(currentDistance<closestdistance)
                       {
                        closestdistance=currentDistance;
                        currentInteractable =interactable;   

                      }
             }
            
            }
        }
       if(currentInteractable!=null)
       {
         if(interactAction.WasPressedThisFrame()==true)
            {
            currentInteractable.Interact();
            }
       }
    }
}