using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalMover : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    public float speed = 3.0f;

    public GameObject thisPortal = null;
    public GameObject otherPortal = null;

    public enum Direction { Left, Right };
    [HideInInspector]
    public Direction direction = Direction.Left;
    #endregion

    private void Update()
    {
        switch (direction)
        {
            case Direction.Left:
                thisPortal.transform.position += -thisPortal.transform.right * speed * Time.deltaTime;
                break;

            case Direction.Right:
                thisPortal.transform.position += thisPortal.transform.right * speed * Time.deltaTime;
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Wall")
        {
            // Change direction
            switch (direction)
            {
                case Direction.Left:
                    direction = Direction.Right;
                    break;

                case Direction.Right:
                    direction = Direction.Left;
                    break;
            }
        }
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Bullet")
        {
            // Teleport the bullet the other portal
            collision.gameObject.transform.position = otherPortal.transform.position;
            collision.gameObject.transform.rotation = otherPortal.transform.rotation;
        }
    }
}