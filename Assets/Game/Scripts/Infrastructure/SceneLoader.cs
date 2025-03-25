using System;
using CodeBase.Infrastructure.Services.DIContainer;
using CodeHub.StateMachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Infrastructure
{
    public class SceneLoader : IService
    {
        public Tween LoadSceneTween;

        public void Load(string sceneName, Action onLoaded = null) =>
            LoadSceneTween = LoadScene(sceneName, onLoaded);

        public Tween LoadScene(string sceneName, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                onLoaded?.Invoke();
                return DOVirtual.DelayedCall(0f, () => { });
            }

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            asyncOperation.allowSceneActivation = false;

            LoadSceneTween = DOVirtual.Float(0, 1, 1f, progress =>
            {
                if (asyncOperation.progress >= 0.9f)
                    asyncOperation.allowSceneActivation = true;
            }).OnComplete(() => onLoaded?.Invoke());

            return LoadSceneTween;
        }
    }
}