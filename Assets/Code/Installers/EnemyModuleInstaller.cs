using EnemyModule;
using SO;
using UnityEngine;
using Zenject;

public class EnemyModuleInstaller : MonoInstaller
{
    [SerializeField] private EnemyConfigsContainer _enemyConfigs;

    public override void InstallBindings()
    {
        Container.Bind<EnemyConfigsContainer>().FromInstance(_enemyConfigs).AsSingle();
        Container.Bind<EnemySpawnPresenter>().AsSingle();
    }
}