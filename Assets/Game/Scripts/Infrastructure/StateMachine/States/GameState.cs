using CodeBase.Infrastructure.Services.DIContainer;
using Game.Scripts.Infrastructure;
using Game.Scripts.Services.Factory;
using Game.Scripts.StaticData;
using Game.Scripts.StaticData.WindowsStaticData;
using Game.Scripts.TransitionLogic;
using Game.Scripts.UI;
using UnityEngine;

namespace CodeHub.StateMachine.States
{
    public class GameState : IState, IService
    {
        private readonly SceneLoader _sceneLoader;
        private readonly LoadVisualizer _loadVisualizer;
        private readonly IStaticDataService _staticDataService;
        private readonly IUIFactory _uiFactory;
        private readonly ICharacterFactory _characterFactory;
        private readonly LevelDataHolder _levelDataHolder;
        private const string SceneName = "Game";


        public GameState(SceneLoader sceneLoader, LoadVisualizer loadVisualizer,
            IStaticDataService staticDataService, IUIFactory uiFactory,
            ICharacterFactory characterFactory, LevelDataHolder levelDataHolder)
        {
            _sceneLoader = sceneLoader;
            _loadVisualizer = loadVisualizer;
            _staticDataService = staticDataService;
            _uiFactory = uiFactory;
            _characterFactory = characterFactory;
            _levelDataHolder = levelDataHolder;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            _loadVisualizer.Show();
            _sceneLoader.LoadScene(SceneName, OnLoaded);
        }

        private void OnLoaded()
        {
            _loadVisualizer.Hide();
            InitUI();
            InitCharacter();
        }

        private void InitUI()
        {
            WindowData windowData = _staticDataService.GetWindowData(WindowId.CoreGameWindow);
            WindowBase window = _uiFactory.GetWindow(windowData);
            window.GetComponent<CoreGameWindow>().BackButton.onClick.AddListener(BackToSelect);
        }

        private void InitCharacter()
        {
            var character = _characterFactory.GetCharacter(_levelDataHolder.SelectedCharacter);
            character.transform.position = Vector3.zero;
            // character.AddComponent<PlayerHpBar>();
            //add animations and etc
        }

        private void BackToSelect()
        {
            GameStateMachine gameMachine = AllServices.Container.Single<GameStateMachine>();
            gameMachine.EnterState<CharacterSelectorState>();
        }
    }
}