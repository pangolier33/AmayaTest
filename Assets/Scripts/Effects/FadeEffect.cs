using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Effects
{
    public class FadeEffect : MonoBehaviour
    {
        [SerializeField] private int _fadeOutDuration;
        [SerializeField] private int _fadeInDuration;

        public void FadeIn(GameObject _gameObject)
        {
            Fade(1, _fadeInDuration, _gameObject);
        }

        public void FadeOut(GameObject _gameObject)
        {
            Fade(0.2f, _fadeOutDuration, _gameObject);
        }

        private void Fade(float value, float duration, GameObject _gameObject)
        {
            Text text = _gameObject.GetComponent<Text>();
            Image image = _gameObject.GetComponent<Image>();
            CanvasGroup canvasGroup = _gameObject.GetComponent<CanvasGroup>();

            if (canvasGroup != null)
            {
                canvasGroup.DOFade(value, duration);
            }
            else if (text != null)
            {
                text.DOFade(value, duration);
            }
            else if (image != null)
            {
                Color targetColor = image.color;
                targetColor.a = 1;
                image.DOColor(targetColor, duration);
            }
        }
    }
}
