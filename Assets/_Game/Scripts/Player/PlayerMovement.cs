using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction MoveAction;
    public Vector2 moveInput;
    public float speed= 5.0f;
    public float turnSpeed= 5.0f;

    CharacterController characterController;

    private SpriteRenderer characterTurn;

    void Start()
    {
        MoveAction.Enable();
        characterController=GetComponent<CharacterController>();
        characterTurn = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput=MoveAction.ReadValue<Vector2>();

        characterController.Move(Vector3.forward*Time.deltaTime*speed*moveInput.y);

        characterController.Move(Vector3.right*Time.deltaTime*turnSpeed*moveInput.x);


        if(moveInput.x >0)
        {
            
            characterTurn.flipX = true;

        }

        if(moveInput.x <0)
        {
            
            characterTurn.flipX = false;
        }

       
    }
}
