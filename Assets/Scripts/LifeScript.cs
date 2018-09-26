using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript : MonoBehaviour {

    public float maxHP;
    private float currentHP;

    private void Awake()
    {
        currentHP = maxHP;
    }

    public void ReceiveDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
            Death();
        else
            OnHit();
    }
    private void Death()
    {
        gameObject.SetActive(false);
    }

    private void OnHit()
    {
        Renderer[] rends = transform.GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in rends)
        {
            rend.material.color = Color.red;
        }
    }
}
