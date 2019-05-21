using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    public Text redPoints = null;
    public Text bluePoints = null;
    public Text redWins = null;
    public Text blueWins = null;

    public uint winScore = 5;

    public uint RedScore
    {
        get { return redScore; }
        set
        {
            redScore = value;

            redPoints.text = redScore.ToString();

            if (redScore >= winScore)
            {
                Debug.Log("Red wins!");
                redWins.gameObject.SetActive(true);
            }
        }
    }
    public uint BlueScore
    {
        get { return blueScore; }
        set
        {
            blueScore = value;

            redPoints.text = blueScore.ToString();

            if (blueScore >= winScore)
            {
                Debug.Log("Blue wins!");
                blueWins.gameObject.SetActive(true);
            }
        }
    }

    public static GameManager Call
    {
        get { return gameManager; }
    }
    #endregion

    #region PRIVATE_VARIABLES
    private uint redScore = 0;
    private uint blueScore = 0;

    private static GameManager gameManager = null;
    #endregion

    GameManager()
    {
        gameManager = this;
    }
}