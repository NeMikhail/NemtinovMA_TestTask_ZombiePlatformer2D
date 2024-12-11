using Core;
using Zenject;
using GameCoreModule;

public class CoreGameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Presenters>().AsSingle();
        Container.Bind<GameFactory>().AsSingle();

        Container.Bind<PoolsContainer>().AsSingle();
        Container.Bind<GameEventBus>().AsSingle();
        Container.Bind<PoolsOperatorPresenter>().AsSingle();
        Container.Bind<SpawnOperatorPresenter>().AsSingle();
    }
}