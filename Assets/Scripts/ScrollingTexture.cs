using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTexture : MonoBehaviour {

    public float scrollSpeed;
    private Renderer mat;

    private void Awake() {
        mat = GetComponent<Renderer>();
    }

    private void Update() {
        mat.material.mainTextureOffset += Vector2.down * Game.instance.gameSpeed / 100 * Time.deltaTime;   
    }
}
