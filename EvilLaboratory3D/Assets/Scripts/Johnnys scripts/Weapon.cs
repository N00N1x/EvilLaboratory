using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int ShootDamage = 1;
    public int MeleeDamage = 1/2;
    public float FireRate = 0.5f;
    public float MeleeRate = 1f;
    public Camera fpsCam;
    public float Shootrange = 100f;
    public float Meleerange = 1.5f;


    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Melee();
        }
    }

    void Shoot()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, Shootrange))
        {
            Debug.Log("Hit: " + hitInfo.transform.name);
            EnemyHealth enemy = hitInfo.transform.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(ShootDamage);
            }
        }



    }

    public void Melee()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, Meleerange))
        {
            Debug.Log("Hit: " + hitInfo.transform.name);
            // Additional hit effects can be implemented here
        }
    }
}
