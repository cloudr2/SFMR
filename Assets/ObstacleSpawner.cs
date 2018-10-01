using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    public static ObstacleSpawner instance = null;
    public GameObject[] obstacles;
    public float freq;
    public float minDistance;
    public float maxDistance;
    public float minXOffset;
    public float maxXOffset;

    private void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Update() {
        InvokeRepeating("SpawnObstacle", 10.0f, Random.Range(1.0f, freq));
    }

    public void SpawnObstacle() {
        for (int i = 0; i < obstacles.Length - 1; i++) {
            Vector3 spawnPosition = new Vector3(Random.Range(minXOffset,maxXOffset),transform.position.y,Random.Range(minDistance,maxDistance));
            Instantiate(obstacles[i], spawnPosition, transform.rotation);
        }
    }

}
