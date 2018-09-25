﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    public float normalSpeed, burstSpeed, burstCD, ShootCD;
    public GameObject bulletPrefab;
    public Transform aim;
    public Transform bulletHolder;

    private float currentSpeed;

    private bool canShoot = true;
    private bool canBurst = true;

    private void Awake() {
        RestoreSpeed();
    }

    private void Update() {
        Move();

        if (Input.GetKey(KeyCode.Space) && canShoot) {
            Shoot();
        }

        if (Input.GetKey(KeyCode.LeftShift)) {
            Burst();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            RestoreSpeed();
        }
    }

    private void Move() {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(hor, ver, 0f);
        Vector3 finalDir = new Vector3(hor, ver, 1.0f);

        transform.position += dir * currentSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(finalDir), Mathf.Deg2Rad * 50.0f);
    }

    private void Shoot() {
        canShoot = false;
        GameObject go = Instantiate(bulletPrefab,aim.position,Quaternion.LookRotation(Vector3.forward)) as GameObject;
        go.transform.parent = bulletHolder;
        StartCoroutine(StartShootCD());
    }

    private IEnumerator StartShootCD() {
        yield return new WaitForSeconds(ShootCD);
        canShoot = true;
    }

    private void Burst() {
        currentSpeed = burstSpeed;
    }

    private void RestoreSpeed() {
        currentSpeed = normalSpeed;
    }
}
