using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Material scrollMaterial;
    public float scrollFactor = 0.5f;

    void LateUpdate()
    {
        float baseYOffset = transform.position.y / transform.localScale.y;
        Vector2 offset = new Vector2(0.0f, baseYOffset * scrollFactor);
        scrollMaterial.SetTextureOffset("_MainTex", offset);
    }
}
