using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject mapGameObject = null;

    private void Update()
    {
        transform.rotation = mapGameObject.transform.rotation;
    }
}