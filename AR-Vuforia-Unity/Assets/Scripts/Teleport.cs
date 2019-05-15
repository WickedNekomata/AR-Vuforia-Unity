using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject map = null;
    public GameObject bulletPrefab = null;
    public GameObject otherPortal = null;

    void OnTriggerEnter(Collider collider)
    {
        if (LayerMask.LayerToName(collider.gameObject.layer) == "Bullet")
        {
            // Teleport the bullet the other portal
            Destroy(collider.gameObject);
            Instantiate(bulletPrefab, otherPortal.transform.position, otherPortal.transform.rotation, map.transform);
        }
    }
}