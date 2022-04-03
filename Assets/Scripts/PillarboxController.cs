using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarboxController : MonoBehaviour
{
    public Transform leftBox;
    public Transform rightBox;
    public float gameAspect = 1.0f;

    void Start()
    {
        Camera cam = Camera.main;
        float camHeight = cam.orthographicSize;
        Vector3 boxSize = new Vector3(Mathf.Max(cam.aspect - gameAspect, 0.0f), 2.0f, 1.0f) * camHeight;
        Vector3 boxPosition = new Vector3(cam.aspect * camHeight - boxSize.x / 2.0f, 0.0f, 0.0f);
        leftBox.localScale = boxSize;
        rightBox.localScale = boxSize;
        leftBox.localPosition = -boxPosition;
        rightBox.localPosition = boxPosition;
    }
}
