using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnabler : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            GameManager.instance.isPlayerControlActive = true;
            Debug.Log("ENTRE");
        }
    }
}
