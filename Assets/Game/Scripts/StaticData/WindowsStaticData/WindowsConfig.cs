using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.StaticData.WindowsStaticData
{
    [CreateAssetMenu(fileName = "WindowsConfig", menuName = "StaticData/WindowsConfig", order = 0)]
    public class WindowsConfig : ScriptableObject
    {
        public List<WindowData> Windows;
    }
}