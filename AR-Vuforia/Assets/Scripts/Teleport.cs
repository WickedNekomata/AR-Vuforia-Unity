using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject mapImageTarget = null;
    public GameObject bulletPrefab = null;
    public GameObject otherPortalGameObject = null;

    void OnTriggerEnter(Collider collider)
    {
        if (LayerMask.LayerToName(collider.gameObject.layer) == "Bullet")
        {
            // Teleport the bullet the other portal
            Destroy(collider.gameObject);
            Instantiate(bulletPrefab, otherPortalGameObject.transform.position, otherPortalGameObject.transform.rotation, mapImageTarget.transform);
        }
    }
}