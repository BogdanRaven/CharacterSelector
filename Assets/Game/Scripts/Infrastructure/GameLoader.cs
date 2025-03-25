using CodeBase.Infrastructure.Services.DIContainer;
using CodeHub.StateMachine;
using CodeHub.StateMachine.States;
using Game.Scripts.TransitionLogic;
using UnityEngine;

namespace Game.Scripts.Infrastructure
{
    public class GameLoader : MonoBehaviour
    {
        public LoadVisualizer LoadVisualizerPrefab;

        private void Awake()
        {
            LoadVisualizer visualizer = Instantiate(LoadVisualizerPrefab);
            
            ServicesInitializer servicesInitializer = new ServicesInitializer(visualizer);
            servicesInitializer.Initialize();
            
            AllServices.Container.Single<GameStateMachine>().EnterState<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}