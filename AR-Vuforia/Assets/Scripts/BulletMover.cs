using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    [HideInInspector]
    public float speed = 5.0f;
    [HideInInspector]
    public float lifeTime = 5.0f;
    #endregion

    #region PRIVATE_VARIABLES
    private float timer = 0.0f;
    #endregion

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = (transform.forward * speed);
    }

    void Update()
    {
        rb.velocity = speed * (rb.velocity.normalized);

        if (timer >= lifeTime)
        {
            Destroy(gameObject);
            return;
        }

        //gameObject.transform.position += transform.forward * speed * Time.deltaTime;

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