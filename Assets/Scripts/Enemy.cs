using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Ship {

    public Transform p0 { get; set; }
    public Transform p1 { get; set; }
    public Transform p2 { get; set; }
    public float timeToDestination;

    private float startTime;
    private Player target;
    private bool onPlace = false;
    private bool isMoveInverted = false;


    private void Awake() {
        startTime = Time.time;
        target = FindObjectOfType<Player>();
        base.Awake();
    }

    void Update() {    
        if (onPlace) {
            transform.forward = target.transform.position - transform.position;
            if (canShoot)
            Shoot();
        }
       
        MoveTowardsDestination();
    }

    private void MoveTowardsDestination() {
        float currentTime = Time.time - startTime;
        float percent;

        if (!isMoveInverted) {
            percent = currentTime / timeToDestination;
            onPlace = percent >= 1;
        }
        else {
            percent = (timeToDestination - currentTime) / timeToDestination;
            if (percent <= 0)
                Destroy(gameObject);
        }

        Vector3 A = Vector3.Lerp(p0.position, p1.position, percent);
        Vector3 B = Vector3.Lerp(p1.position, p2.position, percent);
        transform.position = Vector3.Lerp(A, B, percent);
        
    }

    public void InvertMovement() {
        startTime = Time.time;
        isMoveInverted = true;
    }

    public override void Shoot() {
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
}
