using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour {

    public static FXManager instance = null;

    public GameObject impactFX;

    private void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void DisplayImpactFX(Vector3 pos) {
        Instantiate(impactFX,pos,Quaternion.identity);
    }
}
