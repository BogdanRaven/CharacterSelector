using CodeBase.Infrastructure.Services.DIContainer;
using Game.Scripts.StaticData.CharacterData;
using UnityEditor.U2D.Animation;
using UnityEngine;

namespace Game.Scripts.Services.Factory
{
    public interface ICharacterFactory: IService
    {
        GameObject GetCharacter(CharacterStaticData data);
    }
}