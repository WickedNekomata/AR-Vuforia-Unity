using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    public PortalMover redPortal = null;
    public PortalMover bluePortal = null;
    public GameObject playGameObjects = null;

    public Text redPoints = null;
    public Text bluePoints = null;
    public Text redWins = null;
    public Text blueWins = null;

    public GameObject gameOverButton = null;

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

                playGameObjects.SetActive(false);
                gameOver = true;
            }
        }
    }
    public uint BlueScore
    {
        get { return blueScore; }
        set
        {
            blueScore = value;

            bluePoints.text = blueScore.ToString();

            if (blueScore >= winScore)
            {
                Debug.Log("Blue wins!");
                blueWins.gameObject.SetActive(true);

                playGameObjects.SetActive(false);
                gameOver = true;
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
    private float time = 5.0f;

    private float timer = 0.0f;
    private bool gameOver = false;

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

    private void Update()
    {
        if (gameOver)
        {
            if (timer >= time)
            {
                blueWins.gameObject.SetActive(false);
                redWins.gameObject.SetActive(false);

                gameOverButton.SetActive(true);

                timer = 0.0f;
                gameOver = false;
            }

            timer += Time.deltaTime;
        }
    }
}