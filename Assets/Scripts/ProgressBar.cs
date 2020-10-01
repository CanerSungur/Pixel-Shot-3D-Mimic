using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public ObjectDestroyer od;

    //public int max;
    //public int current;
    public Image mask;

    private void Update()
    {
        GetCurrentFill();
    }

    private void GetCurrentFill()
    {
        float fillAmount = (float)od.obstaclesInScene.Length / (float)od.totalObstacles;
        mask.fillAmount = fillAmount;
    }
}
