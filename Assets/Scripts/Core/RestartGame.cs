using Effects;
using UnityEngine;


public class RestartGame : MonoBehaviour
{
    [SerializeField] private CanvasGroup _mainCanvasGroup;
    [SerializeField] private CanvasGroup _restartCanvasGroup2;
    [SerializeField] private FadeEffect _fadeEffect;
    
    public void Restart()
    {
        _mainCanvasGroup.interactable = false;
        _mainCanvasGroup.blocksRaycasts = false;
        _restartCanvasGroup2.gameObject.SetActive(true);
        _fadeEffect.FadeOut(_mainCanvasGroup.gameObject);
    }

}
