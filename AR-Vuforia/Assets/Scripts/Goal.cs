using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public enum Player { Red, Blue };
    public Player player = Player.Red;

    private void OnTriggerEnter(Collider collider)
    {
        if (LayerMask.LayerToName(collider.gameObject.layer) == "Bullet")
        {
            switch (player)
            {
                case Player.Red:
                    ++GameManager.Call.BlueScore;
                    break;

                case Player.Blue:
                    ++GameManager.Call.RedScore;
                    break;
            }
        }
    }
}