using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMovement : MonoBehaviour {

    private float scrollSpeed = 0.01f;
    private Renderer rend;
	
	void Start () {
        rend = GetComponent<Renderer>();
	}
	
	void FixedUpdate () {
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
