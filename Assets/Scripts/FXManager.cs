using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour {

    public static FXManager instance = null;

    private void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
}
