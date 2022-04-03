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
        float deltaAspect = cam.aspect - gameAspect;

        if (deltaAspect > 0.0f)
        {
            Vector3 boxSize = new Vector3(Mathf.Max(deltaAspect, 0.0f), 2.0f, 1.0f) * camHeight;
            Vector3 boxPosition = new Vector3(cam.aspect * camHeight - boxSize.x / 2.0f, 0.0f, 0.0f);
            
            leftBox.localScale = boxSize;
            leftBox.localPosition = -boxPosition;
            leftBox.gameObject.SetActive(true);

            rightBox.localScale = boxSize;
            rightBox.localPosition = boxPosition;
            rightBox.gameObject.SetActive(true);
        }
    }
}
