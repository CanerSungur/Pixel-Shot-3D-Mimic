using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Header("Unity Setup Field")]
    private bool gotHit = false;
    private Rigidbody rb;
    private MeshRenderer mr;
    private float posYMax;
    public int rewardPoint;

    [Header("Obstacle Material Field")]
    public Material gotHitMat;
    public Material currentMat;
    public bool changeBackColor;
    private ParticleSystem particle;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        mr = gameObject.GetComponent<MeshRenderer>();
        posYMax = transform.position.y + 0.1f;
        changeBackColor = false;
        particle = gameObject.GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("Obstacle"))
        {
            gotHit = true;
        }
    }

    private void Update()
    {
        //To restrict cubes movement on y axis above it's position.
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -6f, posYMax), transform.position.z);

        if (gotHit)
        {
            if (!particle.isPlaying)
            {
                particle.Play();
            }

            if (changeBackColor)
            {
                mr.material = currentMat;
            }
            else
            {
                rb.useGravity = true;
                mr.material = gotHitMat;
            }
        }
    }
}
