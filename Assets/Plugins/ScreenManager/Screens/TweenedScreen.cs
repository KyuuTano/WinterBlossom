using UnityEngine;
using DG.Tweening;

namespace ScreenMgr
{
    /// <summary>
    /// A simple class to demonstrate custom tweened screen
    /// </summary>
    public class TweenedScreen : BaseScreen
    {
        public override void OnAnimationIn()
        {
            canvasGroup.alpha = 1f;

            Transform[] allChildren = GetComponentsInChildren<RectTransform>();
            foreach (var item in allChildren)
            {
                if (item.transform == this.transform) continue;
                item.localScale = Vector3.zero;
                item.DOScale(Vector3.one, Random.Range(0.2f, 0.7f)).SetDelay(Random.Range(0f, 0.6f)).SetEase(Ease.OutBack);
            }

            DOVirtual.DelayedCall(0.5f, OnAnimationInEnd);
        }

        public override void OnAnimationOut()
        {
            canvasGroup.DOFade(0f, 0.5f).SetEase(Ease.OutCubic).OnComplete(OnAnimationOutEnd);
        }
    }
}