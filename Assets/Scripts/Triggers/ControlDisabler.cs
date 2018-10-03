using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDisabler : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Game.instance.PlayerControlActive = false;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            Game.instance.PlayerControlActive = true;
        }
    }
}
