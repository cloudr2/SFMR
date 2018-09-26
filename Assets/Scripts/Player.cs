using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship {

    public GameObject splashPart;

    private float currentSpeed, forwSpeed;

    private bool canBurst = true;

    protected override void Awake() {
        base.Awake();
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

    #region Movement
    private void Move() {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(hor, ver, 1);
        Vector3 finalDir = new Vector3(hor, ver, 1.0f);
        Vector3 finalPos = transform.position + dir * currentSpeed * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(finalPos.x,-8.5f,8.5f), Mathf.Clamp(finalPos.y, -7f, 14f), finalPos.z);
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(finalDir), Mathf.Deg2Rad * 50.0f);
    }
    #endregion

    #region Shoot
    private void Shoot() {
        canShoot = false;
        Bullet newBullet = Instantiate(bulletPrefab, shootingPoint.transform.position, transform.rotation).GetComponent<Bullet>();
        newBullet.transform.parent = bulletHolder;
        newBullet.transform.forward = shootingPoint.forward;
        newBullet.owner = gameObject;
        StartCoroutine(StartShootCD());
    }

    private IEnumerator StartShootCD() {
        yield return new WaitForSeconds(ShootCD);
        canShoot = true;
    }
    #endregion

    #region Burst
    private void Burst() {
        currentSpeed = burstSpeed;
        anim.Play("burst");
    }

    private void RestoreSpeed() {
        currentSpeed = normalSpeed;
        anim.Play("burst_inv");
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
