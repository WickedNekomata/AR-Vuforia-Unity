using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    public float speed = 5.0f;
    public float lifeTime = 5.0f;

    [HideInInspector]
    public Vector3 direction = Vector3.zero;
    #endregion

    #region PRIVATE_VARIABLES
    private float timer = 0.0f;
    #endregion

    void Update()
    {
        if (timer >= lifeTime)
        {
            Destroy(gameObject);
            return;
        }

        gameObject.transform.position += direction * speed * Time.deltaTime;

        timer += Time.deltaTime;
    }

    void OnCollisionEnter(Collider collider)
    {
        if (LayerMask.LayerToName(collider.gameObject.layer) == "Obstacle")
        {
            // Destroy the bullet
            Destroy(collider.gameObject);
        }
    }
}