using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float smoothness = 0.125f;
    public Vector3 offset;

    private Ship ship;

    private void Awake() {
        ship = FindObjectOfType<Ship>();
    }

    private void LateUpdate() {
        Vector3 targetPos = ship.transform.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, smoothness);
        transform.position = new Vector3 (0f, smoothPos.y, smoothPos.z);


        //transform.LookAt(ship.transform);
    }
}
