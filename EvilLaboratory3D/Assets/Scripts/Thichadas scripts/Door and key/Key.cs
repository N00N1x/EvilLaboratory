using UnityEngine;

public class Key : MonoBehaviour
{
    public Component doorcolliderhere; 
    public GameObject KeyGone;

    void OnTriggerStay()
    {
        if (Input.GetKeyUp(KeyCode.Space))

        doorcolliderhere.GetComponent<Collider>().enabled = true;

        if(Input.GetKeyUp(KeyCode.Space))
        KeyGone.SetActive(false);
    }
}
