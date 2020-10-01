using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private List<GameObject> collidedObstacles;

    private void Start()
    {
        collidedObstacles = new List<GameObject>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            collidedObstacles.Add(other.gameObject);
        }
    }
    private void Update()
    {
        if (collidedObstacles.Count != 0)
        {
            for (int i = 0; i < collidedObstacles.Count; i++)
            {
                collidedObstacles[i].GetComponent<Obstacle>().changeBackColor = true;
                collidedObstacles.Remove(collidedObstacles[i]);
            }
        }
        else
            return;
    }
}
