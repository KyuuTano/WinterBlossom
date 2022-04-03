using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] SpriteRenderer grassOverlay;
    [SerializeField] float distanceToFreeze = 5f;

    void Update()
    {
        var col = grassOverlay.color;
        var distance = transform.position.y - GameManager.Snow.transform.position.y;
        var alpha = Mathf.Min(distance / distanceToFreeze, 1f);
        grassOverlay.color = new Color(col.r, col.g, col.b, alpha);
    }
}
