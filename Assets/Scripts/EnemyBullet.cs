using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet {

    private void OnTriggerEnter(Collider other) {
        print(other.gameObject.name);
        if (other.gameObject.tag == "Player") {
            other.transform.parent.SendMessage("ReceiveDamage", damage);
        }
    }
}
