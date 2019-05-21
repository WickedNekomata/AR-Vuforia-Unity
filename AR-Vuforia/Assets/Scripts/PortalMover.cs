using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalMover : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    public GameObject thisPortal = null;
    public GameObject spawnPoint = null;

    public enum Direction { Left, Right };
    [HideInInspector]
    public Direction direction = Direction.Left;
    #endregion

    #region PRIVATE_VARIABLES
    private float speed = 1.0f;
    private float time = 2.0f;

    private bool stop = false;
    private float timer = 0.0f;
    #endregion

    private void Update()
    {
        if (stop)
        {
            if (timer >= time)
            {
                Teleport();

                timer = 0.0f;

                stop = false;
                BulletMover.Call.gameObject.SetActive(true);

                return;
            }

            timer += Time.deltaTime;

            return;
        }

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

        if (collision.gameObject == BulletMover.Call.gameObject)
        {
            stop = true;
            BulletMover.Call.gameObject.SetActive(false);
        }
    }

    // Teleports the bullet the other portal
    private void Teleport()
    {
        BulletMover.Call.gameObject.transform.position = spawnPoint.transform.position;
        BulletMover.Call.gameObject.transform.rotation = Quaternion.LookRotation(-BulletMover.Call.transform.forward);
        BulletMover.Call.speed += BulletMover.Call.increaseOverBound * 2.0f;
    }
}