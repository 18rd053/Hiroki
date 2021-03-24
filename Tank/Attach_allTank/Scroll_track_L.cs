using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll_track_L : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = 0.1f;

    private float offset = 0.0f;
    private Renderer r;

    void Start()
    {
        r = GetComponent<Renderer>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)) Caterpillar_Move(scrollSpeed);
        if (Input.GetKey(KeyCode.S)) Caterpillar_Move(-scrollSpeed);
        if (Input.GetKey(KeyCode.A)) Caterpillar_Move(-scrollSpeed);
        if (Input.GetKey(KeyCode.D)) Caterpillar_Move(scrollSpeed);
    }

    public void Caterpillar_Move(float _scrollSpeed)
    {
        offset = (offset + Time.deltaTime * _scrollSpeed) % 1f;
        r.material.SetTextureOffset("_MainTex", new Vector2(offset, 0f));
    }
}
