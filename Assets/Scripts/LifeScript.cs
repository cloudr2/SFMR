using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript : MonoBehaviour{

    public float maxHP;
    public float flashTime;
    private float currentHP;
    public Transform onDisableHolder { get; set; }

    private void Awake()
    {
        onDisableHolder = GameObject.Find("OnDisableHolder").transform;
        currentHP = maxHP;
    }

    public void ReceiveDamage(float damage)
    {
        FXManager.instance.DisplayImpactFX(transform.position);
        currentHP -= damage;
        if (currentHP <= 0)
            Death();
        else
            OnHit();
    }

    public void Death()
    {
        FXManager.instance.DisplayExplosionFX(transform.position);
        transform.parent = onDisableHolder;
        gameObject.SetActive(false);
    }

    private void OnHit()
    {
        StartCoroutine(FlashOnHit());
    }

    private IEnumerator FlashOnHit() {
        Renderer[] rends = transform.GetComponentsInChildren<Renderer>();

        foreach (Renderer rend in rends) {
            rend.material.color = Color.red;
        }

        yield return new WaitForSeconds(flashTime);

        foreach (Renderer rend in rends) {
            rend.material.color = Color.white;
        }
    }

    private void OnDisable()
    {     
        StopAllCoroutines();
    }
}
