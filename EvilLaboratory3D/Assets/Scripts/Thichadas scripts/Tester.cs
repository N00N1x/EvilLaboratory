using UnityEngine;

public class Tester : MonoBehaviour
{
    public float moveSpeed = 5f; 
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0f, moveZ);
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World); 

    }
}
