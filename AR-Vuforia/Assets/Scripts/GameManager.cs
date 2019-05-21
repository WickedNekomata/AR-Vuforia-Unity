using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    public PortalMover redPortal = null;
    public PortalMover bluePortal = null;

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

    private GameManager()
    {
        gameManager = this;
    }

    private void Awake()
    {
        int random = Random.Range(0, 2);
        switch (random)
        {
            case 0:
                redPortal.direction = PortalMover.Direction.Left;
                bluePortal.direction = PortalMover.Direction.Left;
                break;

            case 1:
                redPortal.direction = PortalMover.Direction.Right;
                bluePortal.direction = PortalMover.Direction.Right;
                break;
        }
    }
}