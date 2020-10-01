using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();    
    }

    private void Update()
    {
        if (GameManager.IsBallThrown && (rb.velocity.magnitude < 0.3f))
        {
            StartCoroutine(DestroyBall());
        }
    }

    private IEnumerator DestroyBall()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
        GameManager.BallInScene = false;
        GameManager.IsBallThrown = false;
    }
}
