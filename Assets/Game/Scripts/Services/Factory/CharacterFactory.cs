using Game.Scripts.StaticData.CharacterData;
using UnityEngine;

namespace Game.Scripts.Services.Factory
{
    public class CharacterFactory : ICharacterFactory
    {
        public GameObject GetCharacter(CharacterStaticData data) => GameObject.Instantiate(data.CharacterPrefab);
    }
}