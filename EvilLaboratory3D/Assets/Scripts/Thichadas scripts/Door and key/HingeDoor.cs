using UnityEngine;

public class HingeDoor : MonoBehaviour
{
    public Animation hingehere;

    void OnTriggerStay()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            hingehere.Play(); 
    }
}
