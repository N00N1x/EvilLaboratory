using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int Damage = 1;
    public float FireRate = 0.5f;
    public Camera fpsCam;
    public float range = 100f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range))
        {
            Debug.Log("Hit: " + hitInfo.transform.name);
            // Additional hit effects can be implemented here
        }


    }
}
