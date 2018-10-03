using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Ship {

    public Transform p0 { get; set; }
    public Transform p1 { get; set; }
    public Transform p2 { get; set; }
    public float maxTime;

    private float startTime;
    private Player target;

    private void Awake() {
        startTime = Time.time;
        target = FindObjectOfType<Player>();
        base.Awake();
    }

    void Update() {
        Appear();
        transform.forward = target.transform.position - transform.position;
    }

    private void Appear() {
        if (p0 == null || p1 == null || p2 == null) {
            throw new System.Exception("Some waypoints are null: " + p0 + "," + p1 + " ," + p2 + ".");
        }
        else {
            float currentTime = Time.time - startTime;
            float percent = currentTime / maxTime;

            Vector3 A = Vector3.Lerp(p0.position, p1.position, percent);
            Vector3 B = Vector3.Lerp(p1.position, p2.position, percent);

            transform.position = Vector3.Lerp(A, B, percent);
        }
    }
}
