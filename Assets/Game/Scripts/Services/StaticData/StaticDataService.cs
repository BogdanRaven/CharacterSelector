using System.Collections.Generic;
using System.Linq;
using Game.Scripts.StaticData.CharacterData;
using Game.Scripts.StaticData.WindowsStaticData;
using UnityEngine;

namespace Game.Scripts.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string CharacterDataPath = "StaticData/CharactersData";
        private const string WindowsDataPath = "StaticData/WindowsConfig/WindowsConfig";

        private Dictionary<CharacterTypId, CharacterStaticData> _charactersData;
        private Dictionary<WindowId, WindowData> _windowsData;

        public void Load()
        {
            _charactersData = Resources.LoadAll<CharacterStaticData>(CharacterDataPath)
                .ToDictionary(c => c.CharacterTypId);
            _windowsData = Resources.Load<WindowsConfig>(WindowsDataPath).Windows.ToDictionary(data => data.WindowId);
        }

        public CharacterStaticData GetCharacterData(CharacterTypId characterId) => 
            _charactersData.GetValueOrDefault(characterId);

        public CharacterStaticData GetRandomCharacterData()
        {
            int rndId = Random.Range(0, _charactersData.Count);
            return _charactersData.Values.ElementAt(rndId);
        }

        public WindowData GetWindowData(WindowId windowId) => _windowsData.GetValueOrDefault(windowId);
    }
}