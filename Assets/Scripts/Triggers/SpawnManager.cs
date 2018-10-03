using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public static SpawnManager instance = null;

    public Enemy[] enemies;
    public Transform[] spawnPoints;
    public Transform[] bezierPoints;
    public Transform[] destinationPoints;

    private void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void Spawn() {
        int rand = Random.Range(0,spawnPoints.Length);
        Enemy newEnemy = Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPoints[rand].position, spawnPoints[rand].rotation);
        newEnemy.transform.parent = spawnPoints[rand];
        newEnemy.p0 = spawnPoints[rand];
        newEnemy.p1 = bezierPoints[rand];
        newEnemy.p2 = destinationPoints[rand];
    }

    public void Spawn(Transform sp, int index) {
        Enemy newEnemy = Instantiate(enemies[Random.Range(0, enemies.Length)], sp.position, sp.rotation);
        newEnemy.transform.parent = sp;
        newEnemy.p0 = sp;
        newEnemy.p1 = bezierPoints[index];
        newEnemy.p2 = destinationPoints[index];
    }

    public void SpawnAll() {
        int i = 0;
        foreach (Transform sp in spawnPoints) {
            if (sp.childCount == 0)
                Spawn(sp, i);

            i++;
        }
    }

}
