using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public class GenerateCharacterWindow : WindowBase
    {
        public Camera CharacterCamera;

        public Vector3 SpawnPointForCharacter => new Vector3(CharacterCamera.transform.position.x,
            CharacterCamera.transform.position.y, 2f);

        public Button GenerateButton;
        public Button PlayButton;
        public TMP_Text DescriptionTxt;
        public TMP_Text StatsTxt;
    }
}