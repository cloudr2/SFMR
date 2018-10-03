using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour {

    public static FXManager instance = null;
    public GameObject impactFX;
    public GameObject explosionFX;

    private Transform FXHolder;

    private void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        FXHolder = FindObjectOfType<FXManager>().transform;
    }

    public void DisplayImpactFX(Vector3 pos) {
        GameObject newPart=Instantiate(impactFX,pos,Quaternion.identity);
        newPart.transform.parent = FXHolder.transform;
        Destroy(newPart,1f);
    }

    public void DisplayExplosionFX(Vector3 pos)
    {
        GameObject newPart = Instantiate(explosionFX, pos, Quaternion.identity);
        newPart.transform.parent = FXHolder.transform;
        Destroy(newPart, 1f);
    }
}
