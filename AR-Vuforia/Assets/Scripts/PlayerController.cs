using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float angularVelocity = 1000.0f;

    public GameObject map = null;
    public GameObject bulletPrefab = null;

    void Update()
    {
        // Instantiate bullet
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(bulletPrefab, transform.position, transform.rotation, map.transform);

        // Move turret
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.rotation *= Quaternion.AngleAxis(angularVelocity * Time.deltaTime, Vector3.up);
        else if (Input.GetKey(KeyCode.RightArrow))
            transform.rotation *= Quaternion.AngleAxis(angularVelocity * Time.deltaTime, -Vector3.up);
    }
}