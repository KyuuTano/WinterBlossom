using UnityEngine;
using DG.Tweening;

namespace ScreenMgr
{
    /// <summary>
    /// A simple class to demonstrate how to make simple tweened screen
    /// </summary>
    public class SimpleTweenScreen : BaseScreen
    {
        public override void OnAnimationIn()
        {
            transform.DOScale(Vector3.one, 0.5f).From(0f).SetEase(Ease.OutBack).OnComplete(OnAnimationInEnd);
        }

        public override void OnAnimationOut()
        {
            transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.OutCubic).OnComplete(OnAnimationOutEnd);
        }
    }
}