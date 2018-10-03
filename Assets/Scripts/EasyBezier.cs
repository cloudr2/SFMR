using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyBezier : MonoBehaviour {

    public Transform p0;
    public Transform p1;
    public Transform p2;

    public Transform grenade;

    [Range(0, 1)]
    public float t;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 A = Vector3.Lerp(p0.position, p1.position, t);
        Vector3 B = Vector3.Lerp(p1.position, p2.position, t);
        grenade.transform.position = Vector3.Lerp(A, B, t);
	}
}
