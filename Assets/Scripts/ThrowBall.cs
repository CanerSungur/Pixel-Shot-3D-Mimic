using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    /*
     * 
     * Makes the ball thrown in the air and destroy itself
     * 
     */

    private Rigidbody rb;

    private float throwForce = 10f;
    private bool didItThrown = false;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Add Force according to thrust power
        if (GameManager.ThrustPower == 1)
        {
            if (!didItThrown)
            {
                rb.useGravity = true;
                rb.AddRelativeForce(Vector3.forward * throwForce * 0.6f, ForceMode.Impulse);

                didItThrown = true;
            }
        }
        else if (GameManager.ThrustPower == 2)
        {
            if (!didItThrown)
            {
                rb.useGravity = true;
                rb.AddRelativeForce(Vector3.forward * throwForce * 1.1f, ForceMode.Impulse);

                didItThrown = true;
            }
        }
        else if (GameManager.ThrustPower == 3)
        {
            if (!didItThrown)
            {
                rb.useGravity = true;
                rb.AddRelativeForce(Vector3.forward * throwForce * 1.6f, ForceMode.Impulse);

                didItThrown = true;
            }
        }
        else if (GameManager.ThrustPower == 4)
        {
            if (!didItThrown)
            {
                rb.useGravity = true;
                rb.AddRelativeForce(Vector3.forward * throwForce * 2, ForceMode.Impulse);

                didItThrown = true;
            }
        }
    }
}
