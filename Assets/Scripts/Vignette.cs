using UnityEngine;
using UnityEngine.UI;

public class Vignette : MonoBehaviour
{
    [SerializeField] Image vignette;
    [SerializeField] float distanceToFreeze = 5f;
    [SerializeField] Transform playerTransform;
    [SerializeField] float value;

    void Update()
    {
        var col = vignette.color;
        var distance = playerTransform.position.y - GameManager.Snow.transform.position.y;
        var alpha = 1f - Mathf.Clamp(distance / distanceToFreeze, 0f, 1f);
        vignette.color = new Color(col.r, col.g, col.b, alpha);
        value = alpha;
    }
}
