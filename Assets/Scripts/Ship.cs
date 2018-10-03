using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LifeScript))]
public abstract class Ship : MonoBehaviour
{
    public float shipSpeed, burstCD, ShootCD;
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    protected bool canShoot = true;
    protected Transform bulletHolder;
    protected Animator anim;
    protected LifeScript ls;

    protected virtual void Awake()
    {
        bulletHolder = GameObject.Find("BulletHolder").transform;
        anim = GetComponent<Animator>();
        ls = GetComponent<LifeScript>();
    }

    public abstract void Shoot();
}
