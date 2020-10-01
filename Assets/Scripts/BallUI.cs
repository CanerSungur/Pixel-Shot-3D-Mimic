using UnityEngine;
using UnityEngine.UI;

public class BallUI : MonoBehaviour
{
    public Text ballText;
    public BallSpawner ballSpawner;

    private void Update()
    {
        ballText.text = ballSpawner.ballCount.ToString();
    }
}
