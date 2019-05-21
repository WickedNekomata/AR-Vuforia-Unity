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

    private void OnTriggerEnter(Collider collider)
    {
        if (LayerMask.LayerToName(collider.gameObject.layer) == "Obstacle")
        {
            // Change direction
            switch(direction)
            {
                case Direction.Left:
                    direction = Direction.Right;
                    break;

                case Direction.Right:
                    direction = Direction.Left;
                    break;
            }
        }
        if (LayerMask.LayerToName(collider.gameObject.layer) == "Bullet")
        {
            // Teleport the bullet the other portal
            collider.gameObject.transform.position = otherPortal.transform.position;
            collider.gameObject.transform.rotation = otherPortal.transform.rotation;
        }
    }
}