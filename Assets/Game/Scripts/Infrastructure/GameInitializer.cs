using System;
using UnityEngine;

namespace Game.Scripts.Infrastructure
{
    public class GameInitializer : MonoBehaviour
    {
        public GameLoader LoaderPrefab;

        private void Awake()
        {
            GameLoader loader = FindObjectOfType<GameLoader>();
            if (loader != null) return;

            Instantiate(LoaderPrefab);
        }
    }
}