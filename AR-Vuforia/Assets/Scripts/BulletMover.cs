using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    public float speed = 5.0f;
    public float lifeTime = 5.0f;
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

        gameObject.transform.position += transform.forward * speed * Time.deltaTime;

        timer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Obstacle")
        {
            // Destroy the bullet
            Destroy(collision.gameObject);
        }
    }
}