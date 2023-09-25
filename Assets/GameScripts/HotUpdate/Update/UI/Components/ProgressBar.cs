using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameScripts.HotUpdate.UpdateAssets.UI.Components
{
    public class ProgressBar : UIBehaviour
    {
        [SerializeField] private Image _background;
        [SerializeField] private Image _front;
        private float _progressValue;

        /// <summary>
        /// [0,1]
        /// </summary>
        public float ProgressValue
        {
            get => _progressValue;
            set
            {
                _progressValue = Mathf.Clamp01(value);
                var backgroundSize = _background.rectTransform.rect;
                _front.rectTransform.sizeDelta = new Vector2(backgroundSize.width * _progressValue, 0);
            }
        }
    }
}