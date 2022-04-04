using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform followTransform;
    public float followSpeed = 10.0f;

    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.y = Mathf.Max(followTransform.position.y, transform.position.y);
        transform.position = Vector3.Lerp(transform.position, newPosition, followSpeed * Time.deltaTime);
    }
}
