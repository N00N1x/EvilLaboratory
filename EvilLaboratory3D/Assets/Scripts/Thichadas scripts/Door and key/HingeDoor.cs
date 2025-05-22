using UnityEngine;

public class HingeDoor : MonoBehaviour
{
    public Animation hingehere;

    void OnTriggerStay()
    {
        if (Input.GetKeyDown(KeyCode.E))
            hingehere.Play(); 
    }
}
