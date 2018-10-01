using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    public static ObstacleSpawner instance = null;
    public GameObject[] obstacles;
    public Transform obstacleHolder;
    public float freq;
    public float distance;
    public float minXOffset;
    public float maxXOffset;

    private void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start() {
        InvokeRepeating("SpawnObstacle", 5.0f, Random.Range(3.0F, freq));
    }

    public void SpawnObstacle() {
        Vector3 spawnPosition = new Vector3(Random.Range(minXOffset,maxXOffset),transform.position.y,distance);
        GameObject spawnObstacle = obstacles[Random.Range(0, obstacles.Length)];
        GameObject go = Instantiate(spawnObstacle, spawnObstacle.transform.position + transform.position + spawnPosition, transform.rotation);
        go.transform.parent = obstacleHolder;
    }

    private void OnDestroy()
    {
        CancelInvoke();
    }

}
