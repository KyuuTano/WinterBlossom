using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

namespace ScreenMgr
{
    /// <summary>
    /// A simple class to demonstrate how to make popups and alertboxes with custom data and animation
    /// </summary>
    public class Popup : BaseScreen
    {
        public string Message;

        [SerializeField]
        private TextMeshProUGUI textMessage;

        public override void OnShow()
        {
            if (textMessage != null) textMessage.text = Message;
        }

        public override void OnAnimationIn()
        {
            transform.GetChild(0).DOScale(1f, 0.5f).From(0f).SetEase(Ease.OutBack).OnComplete(OnAnimationInEnd);
        }

        public override void OnAnimationOut()
        {
            transform.GetChild(0).DOScale(0f, 0.3f).SetEase(Ease.OutCubic).OnComplete(OnAnimationOutEnd);
        }
    }
}