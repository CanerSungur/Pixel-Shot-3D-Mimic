using UnityEngine;

public class MoveBall : MonoBehaviour
{
    private Touch touch;
    private float speed;
    private float transitionSpeed;
    private Vector3 originalPosition;

    private GameObject originPoint;

    private float distance;
    private float radiusLimit;
    private Vector3 centerPos;

    private void Start()
    {
        originPoint = GameObject.FindGameObjectWithTag("OriginPoint");
        
        speed = 0.001f;
        transitionSpeed = 30f;
        originalPosition = originPoint.transform.position;

        radiusLimit = 0.6f;
        centerPos = transform.position;
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, centerPos);
        
        //Look at origin.
        transform.LookAt(originPoint.transform);

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y - .16f, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * transitionSpeed);

            }

            if (touch.phase == TouchPhase.Moved)
            {
                //if it's outside of allowed radius
                if (distance > radiusLimit)
                {
                    Vector3 fromOriginToObject = transform.position - centerPos;
                    fromOriginToObject *= radiusLimit / distance;
                    transform.position = centerPos + fromOriginToObject;
                }
                else
                {
                    transform.position = new Vector3(
                        transform.position.x + touch.deltaPosition.x * speed,
                        Mathf.Clamp(transform.position.y, 3.25f, 4.16f) + touch.deltaPosition.y * speed,
                        transform.position.z);
                }

                //Add dots to the ball's direction and decide ball's thrust power accordingly.
                if (distance >= 0.2f && distance < 0.3f)
                {
                    //Low power: 1
                    GameManager.ThrustPower = 1;
                }
                else if (distance >= 0.3f && distance < 0.4f)
                {
                    //Mid power: 2
                    GameManager.ThrustPower = 2;
                }
                else if (distance >= 0.4f && distance < 0.5f)
                {
                    //High power: 3
                    GameManager.ThrustPower = 3;
                }
                else if (distance >= 0.5f && distance < 0.6f)
                {
                    //Highest power: 4
                    GameManager.ThrustPower = 4;
                }
            }
            
            if (touch.phase == TouchPhase.Ended)
            {
                if (distance <= 0.2f)
                {
                    transform.position = originalPosition;
                }
                else
                {
                    //Add Force to the ball and disable all restrictions.
                    GameManager.IsBallThrown = true;
                }
            }
        }
    }
}
