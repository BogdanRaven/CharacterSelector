using CodeBase.Infrastructure.Services.DIContainer;
using CodeHub.StateMachine;
using CodeHub.StateMachine.States;
using Game.Scripts.Services.Factory;
using Game.Scripts.StaticData;
using Game.Scripts.TransitionLogic;

namespace Game.Scripts.Infrastructure
{
    public class ServicesInitializer
    {
        private readonly LoadVisualizer _loadVisualizer;

        public ServicesInitializer(LoadVisualizer loadVisualizer) => _loadVisualizer = loadVisualizer;

        public void Initialize() => InitServices();

        private void InitServices()
        {
            AllServices.Container.Bind<GameStateMachine>();

            BindServices();
            BindStates();
            
            AllServices.Container.ForceResolve();
        }

        private void BindServices()
        {
            AllServices.Container.BindSingle(_loadVisualizer);
            AllServices.Container.Bind<SceneLoader>();
            AllServices.Container.Bind<IStaticDataService, StaticDataService>();
            AllServices.Container.Bind<IUIFactory, UIFactory>();
            AllServices.Container.Bind<ICharacterFactory, CharacterFactory>();
            AllServices.Container.Bind<LevelDataHolder>();
        }

        private static void BindStates()
        {
            AllServices.Container.Bind<BootstrapState>();
            AllServices.Container.Bind<CharacterSelectorState>();
            AllServices.Container.Bind<GameState>();
        }
    }
}