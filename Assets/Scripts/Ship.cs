using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LifeScript))]
public abstract class Ship : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootingPoint, bulletHolder;
    public float shipSpeed, burstCD, ShootCD;

    protected bool canShoot = true;
    protected Animator anim;

    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
    }
}
