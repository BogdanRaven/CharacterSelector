using CodeBase.Infrastructure.Services.DIContainer;
using DG.Tweening;
using UnityEngine;

namespace Game.Scripts.TransitionLogic
{
    public class LoadVisualizer : MonoBehaviour, IService
    {
        public CanvasGroup Curtain;

        private void Awake() => DontDestroyOnLoad(this);

        public void Show()
        {
            EnableGameObject(true);
            Curtain.alpha = 1;
        }

        public void Hide() => PlayFadeInAnimation();

        private void PlayFadeInAnimation() => Curtain.DOFade(0, 1.5f).OnComplete(() => EnableGameObject(false));

        private void EnableGameObject(bool enable) => gameObject.SetActive(enable);
    }
}