using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBooster : MonoBehaviour {

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player") {
            other.GetComponent<Player>().Boost();
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            other.GetComponent<Player>().StopBoost();
        }
    }
}
