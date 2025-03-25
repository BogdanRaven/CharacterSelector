using UnityEngine;

namespace Game.Scripts.StaticData.CharacterData
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "StaticData/CharacterData")]
    public class CharacterStaticData : ScriptableObject
    {
        public CharacterTypId CharacterTypId;
        public GameObject CharacterPrefab;

        public int MaxHp;
        public int Damage;
        public string Description;
    }
}