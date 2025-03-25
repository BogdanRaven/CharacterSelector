using Game.Scripts.StaticData.WindowsStaticData;
using Game.Scripts.UI;
using UnityEngine;

namespace Game.Scripts.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        public WindowBase GetWindow(WindowData windowData) => GameObject.Instantiate(windowData.Window);
    }
}