using CodeBase.Infrastructure.Services.DIContainer;
using Game.Scripts.StaticData.CharacterData;
using Game.Scripts.StaticData.WindowsStaticData;
using UnityEditor.U2D.Animation;

namespace Game.Scripts.StaticData
{
    public interface IStaticDataService : IService
    {
        public void Load();
        public CharacterStaticData GetCharacterData(CharacterTypId characterId);
        public CharacterStaticData GetRandomCharacterData();
        
        public WindowData GetWindowData(WindowId windowId);
    }
}