using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    public float normalSpeed, burstSpeed, burstCD, ShootCD;
    public GameObject bulletPrefab;
    public Transform aim, bulletHolder;

    private float currentSpeed, forwSpeed;

    private bool canShoot = true;
    private bool canBurst = true;

    private Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
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
        Vector3 dir = new Vector3(hor, ver, forwSpeed);
        Vector3 finalDir = new Vector3(hor, ver, 1.0f);

        transform.position += dir * currentSpeed * Time.deltaTime;
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(finalDir), Mathf.Deg2Rad * 50.0f);
    }
    #endregion

    #region Shoot
    private void Shoot() {
        canShoot = false;
        GameObject go = Instantiate(bulletPrefab, transform.position, Quaternion.LookRotation(Vector3.forward)) as GameObject;
        go.transform.forward = aim.forward - transform.forward;
        go.transform.parent = bulletHolder;
        StartCoroutine(StartShootCD());
    }

    private IEnumerator StartShootCD() {
        yield return new WaitForSeconds(ShootCD);
        canShoot = true;
    }
    #endregion

    #region Burst
    private void Burst() {
        currentSpeed = normalSpeed * 0.5f;
        anim.Play("burst");
    }

    private void RestoreSpeed() {
        currentSpeed = normalSpeed;
        anim.Play("burst_inv");
    }
    #endregion
}
