using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TitleAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Title Card")]
    [SerializeField] RectTransform titleImageRect;
    [SerializeField] Vector2 startPosition;
    [SerializeField] Vector2 endPosition;
    [SerializeField] float jumpPower;
    [SerializeField] int bounces;
    [SerializeField] float titleDuration;

    [Header("Buttons")]
    [SerializeField] CanvasGroup buttonGroup;
    [SerializeField] VerticalLayoutGroup buttonLayout;
    [SerializeField] float buttonDuration;

    void OnEnable()
    {
        buttonGroup.alpha = 0f;
        titleImageRect.anchoredPosition = startPosition;
        titleImageRect.DOJumpAnchorPos(endPosition, jumpPower, bounces, titleDuration)
            .OnComplete(() =>
            {
                buttonGroup.DOFade(1f, buttonDuration).From(0f);
                DOTween.To((v) => { buttonLayout.spacing = v; }, 20f, 30f, buttonDuration);
            });

    }

}
