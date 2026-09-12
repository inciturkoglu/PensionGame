using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour, IInteractable
{
    [SerializeField]
    public string destinationScene;
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
        Debug.Log("Kapidan girildi!");
        SceneManager.LoadSceneAsync(destinationScene);
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
