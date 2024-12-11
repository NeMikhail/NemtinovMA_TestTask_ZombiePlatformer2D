using Core.Interface;
using GameCoreModule;
using SO;
using System;
using UnityEngine;
using Zenject;

namespace PlayerModule
{
    public class PlayerSpawnPresenter : IPresenter, IPreInitialisation
    {
        private DiContainer _di;
        private GameEventBus _gameEventBus;
        private PlayerConfig _playerConfig;

        [Inject]
        public void Construct(DiContainer di, GameEventBus gameEventBus, PlayerConfig playerConfig)
        {
            _di = di;
            _gameEventBus = gameEventBus;
            _playerConfig = playerConfig;
            IninitialisePlayerModel();
        }

        public void PreInitialisation()
        {
            SpawnPlayer();
        }

        private void IninitialisePlayerModel()
        {
            WeaponConfig weaponConfig = _playerConfig.WeaponConfig;
            WeaponModel weaponModel =
                new WeaponModel(weaponConfig.BulletPrefabID, weaponConfig.BulletIconSprite,
                weaponConfig.MaxAmmoCount, weaponConfig.MaxAmmoCount, weaponConfig.Damage,
                weaponConfig.Cooldown, weaponConfig.BulletSpeed);
            PlayerModel playerModel =
                new PlayerModel(_playerConfig.Health, _playerConfig.Speed,
                _playerConfig.JumpForce, weaponModel);
            _di.Bind<PlayerModel>().FromInstance(playerModel);
        }

        private void SpawnPlayer()
        {
            _gameEventBus.OnObjectSpawned += InitializePlayer;
            _gameEventBus.OnSpawnObjectWithoutRoot?.Invoke(_playerConfig.PrefabID, _playerConfig.SpawnPosition);
            _gameEventBus.OnObjectSpawned -= InitializePlayer;
        }

        private void InitializePlayer(GameObject playerObject)
        {
            PlayerView playerView = playerObject.GetComponent<PlayerView>();
            playerView.OnKilled += TriggerGameOver;
        }

        private void TriggerGameOver()
        {
            _gameEventBus.OnGameOver?.Invoke();
        }
    }
}
