using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform followTransform;
    public float followSpeed = 10.0f;

    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.y = followTransform.position.y;
        transform.position = Vector3.Lerp(transform.position, newPosition, followSpeed * Time.deltaTime);
    }
}
