using CodeBase.Infrastructure.Services.DIContainer;
using Game.Scripts.StaticData.WindowsStaticData;
using Game.Scripts.UI;

namespace Game.Scripts.Services.Factory
{
    public interface IUIFactory: IService
    {
        WindowBase GetWindow(WindowData windowData);
    }
}