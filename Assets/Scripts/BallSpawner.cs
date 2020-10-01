using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject originPoint;
    public GameObject ballPrefab;
    public int ballCount = 3;

    private void Start()
    {
        GameManager.BallInScene = false;
    }

    private void Update()
    {
        if (!GameManager.BallInScene && ballCount > 0)
        {
            Instantiate(ballPrefab, originPoint.transform.position, Quaternion.identity);
            GameManager.BallInScene = true;
            ballCount--;
        }
        
        if (!GameManager.BallInScene && ballCount <= 0)
        {
            GameManager.GameOver = true;
        }
    }
}
