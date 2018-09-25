using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

    public float speed;

	void Update () {

        if (Input.GetKey(KeyCode.R)) {
            transform.position = Vector3.zero;
        }

        transform.position += Vector3.forward * speed * Time.deltaTime;
	}
}
