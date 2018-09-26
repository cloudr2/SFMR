using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public GameObject ground;

    private Player ship;

    private void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        ship = FindObjectOfType<Player>();
    }

    private void Update() {
        if (Input.GetKey(KeyCode.R)) {
            ship.transform.position = Vector3.zero;
        }
    }

}
