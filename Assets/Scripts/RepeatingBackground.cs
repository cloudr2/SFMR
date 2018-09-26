using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    private Transform[] planes;

    private void Start()
    {
        planes = GetComponentsInChildren<Transform>();
        print(planes.Length);
    }
}
