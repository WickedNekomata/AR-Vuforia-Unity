using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public enum Player { Red, Blue };
    public Player player = Player.Red;

    private void OnCollisionEnter(Collision collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Bullet")
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