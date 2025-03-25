using CodeBase.Infrastructure.Services.DIContainer;
using Game.Scripts.Infrastructure;
using Game.Scripts.Services.Factory;
using Game.Scripts.StaticData;
using Game.Scripts.StaticData.CharacterData;
using Game.Scripts.StaticData.WindowsStaticData;
using Game.Scripts.TransitionLogic;
using Game.Scripts.UI;
using UnityEngine;

namespace CodeHub.StateMachine.States
{
    public class CharacterSelectorState : IState, IService
    {
        private const string SceneName = "CharacterSelector";

        private readonly SceneLoader _sceneLoader;
        private readonly LoadVisualizer _loadVisualizer;
        private readonly IStaticDataService _staticDataService;
        private readonly IUIFactory _uiFactory;
        private readonly ICharacterFactory _characterFactory;
        private readonly LevelDataHolder _levelDataHolder;

        private GenerateCharacterWindow _generateCharacterWindow;
        private GameObject _spawnedCharacter;

        public CharacterSelectorState(SceneLoader sceneLoader, LoadVisualizer loadVisualizer,
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
            //unscribe events .....
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
            GenerateCharacter();
        }

        private void InitUI()
        {
            WindowData windowData = _staticDataService.GetWindowData(WindowId.ShowCharacterWindow);
            _generateCharacterWindow = _uiFactory.GetWindow(windowData).GetComponent<GenerateCharacterWindow>();
            _generateCharacterWindow.PlayButton.onClick.AddListener(LoadGame);
            _generateCharacterWindow.GenerateButton.onClick.AddListener(GenerateCharacter);
        }

        private void LoadGame()
        {
            GameStateMachine gameMachine = AllServices.Container.Single<GameStateMachine>();
            gameMachine.EnterState<GameState>();
        }

        private void GenerateCharacter()
        {
            CharacterStaticData characterData = _staticDataService.GetRandomCharacterData();
            if (_spawnedCharacter != null)
                GameObject.Destroy(_spawnedCharacter);

            _spawnedCharacter = _characterFactory.GetCharacter(characterData);
            _levelDataHolder.SelectedCharacter = characterData;
            _spawnedCharacter.transform.position = _generateCharacterWindow.SpawnPointForCharacter;
            SetUpWindowsUIByCharacterData(characterData);
        }

        private void SetUpWindowsUIByCharacterData(CharacterStaticData data)
        {
            _generateCharacterWindow.DescriptionTxt.text = "Description: \n" + data.Description;
            _generateCharacterWindow.StatsTxt.text = "Max hp: " + data.MaxHp + "\n" + "Damage:" + data.Damage;
        }
    }
}