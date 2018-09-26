using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {

    public float speed;
    public float damage;
    public  GameObject owner { get; set; }
    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject,1.5f);
    }

    void Update() {
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != owner.tag)
        {
            other.transform.parent.SendMessage("ReceiveDamage",damage);
        }
    }

}
