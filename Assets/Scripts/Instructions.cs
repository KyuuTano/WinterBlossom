using DG.Tweening;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    [SerializeField] float wobbleWidth;
    [SerializeField] float duration;
    [SerializeField] Ease easeType;
    [SerializeField] float disappearHeight;

    private Tween tween;

    void OnEnable()
    {
        var halfWidth = wobbleWidth / 2;
        var startPos = transform.position.x - halfWidth;
        var endPos = transform.position.x + halfWidth;
        tween = transform.DOLocalMoveX(endPos, duration / 2).From(startPos).SetEase(easeType).SetLoops(-1, LoopType.Yoyo);
    }

    void Update()
    {
        if (transform.position.y > disappearHeight) Destroy(gameObject);
    }

    void OnDisable()
    {
        tween.Kill();
    }
}
