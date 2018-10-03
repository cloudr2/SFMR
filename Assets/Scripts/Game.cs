using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public static Game instance = null;

    public float normalSpeed, burstSpeed;
    public float gameSpeed { get; set; }
    public bool PlayerControlActive;

    private void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        SwitchToNormalSpeed();
    }

    private void Update() {
        transform.position += Vector3.forward * gameSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.R)) {
            transform.position = Vector3.zero;
        }
    }

    public void SwitchToNormalSpeed() {
        gameSpeed = normalSpeed;
    }

    public void SwitchToBurstSpeed() {
        gameSpeed = burstSpeed;
    }
}
