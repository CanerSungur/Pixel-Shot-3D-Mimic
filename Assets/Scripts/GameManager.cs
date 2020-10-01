using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool IsBallThrown;
    public static bool BallInScene;
    public static int ThrustPower;
    public static int Score;
    public static bool GameOver;

    public GameObject restartPanel;

    private GameObject ballInScene;
    private MoveBall moveBallScript;
    private ThrowBall throwBallScript;

    private void Start()
    {
        IsBallThrown = false;
        BallInScene = false;
        ThrustPower = 0;
        Score = 0;
        GameOver = false;
    }

    private void Update()
    {
        if (GameOver)
        {
            restartPanel.SetActive(true);
        }
        else
        {
            restartPanel.SetActive(false);

            if (ballInScene == null)
            {
                ballInScene = GameObject.FindGameObjectWithTag("Ball");
            }
            if (ballInScene != null)
            {
                moveBallScript = ballInScene.GetComponent<MoveBall>();
                throwBallScript = ballInScene.GetComponent<ThrowBall>();
            }

            if (IsBallThrown && ThrustPower != 0)
            {
                moveBallScript.enabled = false;
                throwBallScript.enabled = true;
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
