using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject bulletPrefab = null;
    public GameObject otherPortal = null;

    void OnTriggerEnter(Collider collider)
    {
        if (LayerMask.LayerToName(collider.gameObject.layer) == "Bullet")
        {
            // Teleport the bullet the other portal
            Destroy(collider.gameObject);

            GameObject bullet = Instantiate(bulletPrefab, otherPortal.transform.position, Quaternion.identity, transform.parent);
            BulletMover bulletMover = bullet.GetComponent<BulletMover>();
            bulletMover.direction = otherPortal.transform.forward;
        }
    }
}