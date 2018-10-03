using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            CleanEnemiesAlive();
            SpawnManager.instance.SpawnAll();
            print("spawned all");
        }
    }

    private void CleanEnemiesAlive() {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        if (enemies.Length > 0) {
            foreach (Enemy enemy in enemies) {
                enemy.InvertMovement();
            }
            print("enemies cleaned");
        }
    }
}
