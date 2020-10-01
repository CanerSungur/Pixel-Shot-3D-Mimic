using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text scoreText;

    private void Update()
    {
        scoreText.text = GameManager.Score.ToString();
    }
}
