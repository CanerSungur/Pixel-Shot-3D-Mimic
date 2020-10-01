using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    /*
     * It's attached to the Bottom which is the child of Floor. It holds the trigger.
     * 
     */

    private List<GameObject> objectsOnPlatform;
    public GameObject[] obstaclesInScene;
    public int totalObstacles;

    private void Awake()
    {
        objectsOnPlatform = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            objectsOnPlatform.Add(other.gameObject);
        }
    }

    private void Start()
    {
        obstaclesInScene = GameObject.FindGameObjectsWithTag("Obstacle");
        totalObstacles = obstaclesInScene.Length;
    }

    private void Update()
    {
        obstaclesInScene = GameObject.FindGameObjectsWithTag("Obstacle");

        if (objectsOnPlatform.Count != 0)
        {
            for (int i = 0; i < objectsOnPlatform.Count; i++)
            {
                GameManager.Score += objectsOnPlatform[i].GetComponent<Obstacle>().rewardPoint;
                StartCoroutine(DestroyObject(objectsOnPlatform[i]));
                objectsOnPlatform.Remove(objectsOnPlatform[i]);
            }
        }
    }

    private IEnumerator DestroyObject(GameObject go)
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(go);
    }
}
