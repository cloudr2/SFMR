using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTexture : MonoBehaviour {

    [Range(0,0.1f)]
    public float scrollSpeedPercent;
    private Renderer mat;

    private void Awake() {
        mat = GetComponent<Renderer>();
    }

    private void Update() {
        mat.material.mainTextureOffset += Vector2.down * Game.instance.gameSpeed * Mathf.Pow(scrollSpeedPercent,2) * Time.deltaTime;   
    }
}
