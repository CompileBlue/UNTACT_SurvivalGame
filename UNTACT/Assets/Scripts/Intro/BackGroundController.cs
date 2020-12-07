using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    Material bgMaterial;

    void Start()
    {
        bgMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        float newOffsetX = bgMaterial.mainTextureOffset.x + scrollSpeed * Time.deltaTime;
        Vector2 newOffset = new Vector2(newOffsetX, 0);

        bgMaterial.mainTextureOffset = newOffset;
    }
}
