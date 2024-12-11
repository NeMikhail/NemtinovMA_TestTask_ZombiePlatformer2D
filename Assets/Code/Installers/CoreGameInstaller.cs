using Core;
using Zenject;
using GameCoreModule;
using UnityEngine;
using SO;

public class CoreGameInstaller : MonoInstaller
{
    [SerializeField] private PrefabsContainer _prefabsContainer;
    public override void InstallBindings()
    {
        Container.Bind<Presenters>().AsSingle();
        Container.Bind<GameFactory>().AsSingle();

        Container.Bind<GameEventBus>().AsSingle();
        Container.Bind<PrefabsContainer>().FromInstance(_prefabsContainer).AsSingle();
        Container.Bind<GameStatePresenter>().AsSingle();
        Container.Bind<PoolsContainer>().AsSingle();
        Container.Bind<PoolsOperatorPresenter>().AsSingle();
        Container.Bind<SpawnOperatorPresenter>().AsSingle();
    }
}