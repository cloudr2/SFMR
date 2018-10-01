﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship {

    public GameObject splashPart;
    public Transform aim;

    private float forwSpeed;
    private bool canBurst = true;
    private float offsetDir;

    protected override void Awake() {
        base.Awake();
    }

    private void Update() {
        if (GameManager.instance.isPlayerControlActive)
        {
            Move();
            GetKeys();
        }
    }

    private void GetKeys() {
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            Shoot();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Game.instance.SwitchToBurstSpeed();
            anim.Play("burst");
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Game.instance.SwitchToNormalSpeed();
            anim.Play("burst_inv");
        }

        if (Input.GetKey(KeyCode.E))
        {
            BarrelRoll(-1);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            BarrelRoll(1);
        }
    }

    #region Movement
    private void Move() {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(hor, ver, 0);
        Vector3 rotDir = new Vector3(hor, ver, 1.0f);
        Vector3 pos = transform.position + dir * shipSpeed * Time.deltaTime;
        Vector3 finalPos = new Vector3(Mathf.Clamp(pos.x, -8.5f, 8.5f), Mathf.Clamp(pos.y, 0.5f, 20f), pos.z);
        Quaternion rot = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(rotDir), Mathf.Deg2Rad * 50.0f);
        transform.position = finalPos;
        transform.rotation = rot;
    }
    #endregion

    //receives either -1 or 1 to asign orientation
    private void BarrelRoll (int orientation) {
        throw new System.NotImplementedException();
    }

    #region Shoot
    private void Shoot() {
        canShoot = false;
        Bullet newBullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation).GetComponent<Bullet>();
        newBullet.transform.parent = bulletHolder;
        newBullet.owner = gameObject;
        StartCoroutine(StartShootCD());
    }

    private IEnumerator StartShootCD() {
        yield return new WaitForSeconds(ShootCD);
        canShoot = true;
    }
    #endregion

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Ground") {
            splashPart.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Ground") {
            splashPart.gameObject.SetActive(false);
        }
    }
}
