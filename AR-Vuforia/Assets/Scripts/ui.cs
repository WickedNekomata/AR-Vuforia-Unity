using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui : MonoBehaviour
{
    public GameObject playgos;

    public void OnClickPlay()
    {
        playgos.SetActive(!playgos.activeSelf);
        gameObject.SetActive(false);
    }
}
