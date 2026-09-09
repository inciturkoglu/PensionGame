using UnityEngine;

public class CameraController : MonoBehaviour
{
   
   public GameObject player;
   private Vector3 offset= new Vector3(-3.613342f,3.414667f,-10.3636f);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
