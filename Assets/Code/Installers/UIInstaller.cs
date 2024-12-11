using Zenject;
using UIModule;

public class UIInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<UIPresenter>().AsSingle();

    }
}