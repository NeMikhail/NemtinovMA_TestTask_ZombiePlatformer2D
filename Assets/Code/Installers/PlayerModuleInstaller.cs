using UnityEngine;
using Zenject;
using PlayerModule;
using SO;

public class PlayerModuleInstaller : MonoInstaller
{
    [SerializeField] private PlayerConfig _playerConfig;

    public override void InstallBindings()
    {
        Container.Bind<PlayerConfig>().FromInstance(_playerConfig).AsSingle();
        Container.Bind<PlayerEventBus>().AsSingle();
        Container.Bind<PlayerSpawnPresenter>().AsSingle();
        Container.Bind<PlayerStatePresenter>().AsSingle();
        Container.Bind<PlayerMovementPresenter>().AsSingle();
        Container.Bind<WeaponPresenter>().AsSingle();

    }
}
