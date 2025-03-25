using CodeBase.Infrastructure.Services.DIContainer;
using Game.Scripts.Infrastructure;
using Game.Scripts.StaticData;

namespace CodeHub.StateMachine.States
{
    public class BootstrapState : IState, IService
    {
        private const string SceneName = "Init";
        private readonly SceneLoader _sceneLoader;
        private readonly IStaticDataService _staticDataService;

        public BootstrapState(SceneLoader sceneLoader, IStaticDataService staticDataService)
        {
            _sceneLoader = sceneLoader;
            _staticDataService = staticDataService;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            //Init multiply services, start load game items in cash before we start level
            _staticDataService.Load();
            _sceneLoader.LoadScene(SceneName, OnLoaded);
        }

        private void OnLoaded()
        {
            var stateMachine = AllServices.Container.Single<GameStateMachine>();
            stateMachine.EnterState<CharacterSelectorState>();
        }
    }
}