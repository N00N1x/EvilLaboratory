using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int MeleeDamage = 1;
    public Camera fpsCam;
    public float MeleeRange = 10f;

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Melee();
        }
    }

    void Melee()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, MeleeRange))
        {
            Debug.Log("Meleed: " + hitInfo.transform.name);
            EnemyHealth enemy = hitInfo.transform.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(MeleeDamage);
            }
        }

    }



    
}
