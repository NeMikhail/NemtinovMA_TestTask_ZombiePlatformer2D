using UnityEngine;
using Zenject;
using InputModule;

public class InputModuleInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<InputEventBus>().AsSingle();
        Container.Bind<InputPresenter>().AsSingle();
    }
}