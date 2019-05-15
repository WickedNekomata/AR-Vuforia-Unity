using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (LayerMask.LayerToName(collider.gameObject.layer) == "Bullet")
        {
            // Win!
            Debug.Log("Goal reached");
        }
    }
}