using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    public float angularVelocity = 50.0f;
    public float maxAngle = 45.0f;

    public GameObject mapImageTarget = null;
    public GameObject bulletPrefab = null;
    #endregion

    #region PRIVATE_VARIABLES
    private float accumulatedAngularVelocity = 0.0f;
    #endregion

    void Update()
    {
        // Instantiate bullet
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(bulletPrefab, transform.position, transform.rotation, mapImageTarget.transform);

        // Move turret
        if (Input.GetKey(KeyCode.RightArrow))
        {
            float angle = angularVelocity * Time.deltaTime;

            if (accumulatedAngularVelocity + angle > maxAngle)
                angle = maxAngle - accumulatedAngularVelocity;

            if (angle > 0.0f)
            {
                accumulatedAngularVelocity += angle;

                transform.rotation *= Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            float angle = -angularVelocity * Time.deltaTime;

            if (accumulatedAngularVelocity + angle < -maxAngle)
                angle = -maxAngle - accumulatedAngularVelocity;

            if (angle < 0.0f)
            {
                accumulatedAngularVelocity += angle;

                transform.rotation *= Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }
}