using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject playGameObjects;
    public GameObject button;

    public void OnClickPlay()
    {
        playGameObjects.SetActive(!playGameObjects.activeSelf);
        button.SetActive(false);

        GameManager.Call.BlueScore = 0;
        GameManager.Call.RedScore = 0;
    }
}