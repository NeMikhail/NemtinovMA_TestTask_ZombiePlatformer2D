using Core.Interface;
using Zenject;
using GameCoreModule;
using Extention;
using System;
using UnityEngine;

namespace PlayerModule
{
    public class WeaponPresenter : IPresenter, IInitialisation, IFixedExecute, ICleanUp
    {
        private SceneViewsContainer _sceneViewsContainer;
        private PlayerView _playerView;
        private PlayerModel _playerModel;
        private PlayerEventBus _playerEventBus;
        private GameEventBus _gameEventBus;
        private AudioController _audioController;
        private WeaponModel _weaponModel;
        private PlayerState _currentState;
        private Timer _timer;
        

        [Inject]
        public void Construct(SceneViewsContainer sceneViewsContainer, PlayerModel playerModel,
            PlayerEventBus playerEventBus, GameEventBus gameEventBus, AudioController audioController)
        {
            _sceneViewsContainer = sceneViewsContainer;
            _playerModel = playerModel;
            _playerEventBus = playerEventBus;
            _gameEventBus = gameEventBus;
            _audioController = audioController;
        }

        public void Initialisation()
        {
            _playerView = _sceneViewsContainer.GetPlayerView();
            InitializeWeapon(_playerModel.WeaponModel);
            _playerEventBus.OnStateChanged += ChangeState;
            _playerView.OnAmmoAdded += AddAmmo;
        }

        public void Cleanup()
        {
            _playerEventBus.OnStateChanged -= ChangeState;
            _playerView.OnAmmoAdded -= AddAmmo;
        }

        public void FixedExecute(float fixedDeltaTime)
        {
            if (_currentState == PlayerState.Shooting)
            {
                if (_timer.Wait())
                {
                    Shoot();
                }
            }
        }
        private void InitializeWeapon(WeaponModel weaponModel)
        {
            _weaponModel = weaponModel;
            _timer = new Timer(_playerModel.WeaponModel.Cooldown, false);
        }


        private void AddAmmo(int ammoCount)
        {
            _audioController.PlayPickUpSound();
            _weaponModel.SetAmmoCount(_weaponModel.AmmoCount + ammoCount);
            if (_weaponModel.AmmoCount > _weaponModel.MaxAmmoCount)
            {
                _weaponModel.SetAmmoCount(_weaponModel.MaxAmmoCount);
            }
        }

        public void ChangeState(PlayerState playerState)
        {
            _currentState = playerState;
        }

        private void Shoot()
        {
            if (_weaponModel.AmmoCount > 0)
            {
                _audioController.PlayShootSound();
                _weaponModel.SetAmmoCount(_weaponModel.AmmoCount - 1);
                _gameEventBus.OnObjectSpawnedFromPool += InitializeBullet;
                _gameEventBus.OnSpawnObjectFromPool(_weaponModel.BulletPrefabID, _playerView.Weapon.transform.position);
                _gameEventBus.OnObjectSpawnedFromPool -= InitializeBullet;
                _playerEventBus.OnShootEvent?.Invoke(_weaponModel.AmmoCount, _weaponModel.MaxAmmoCount);
                if (_weaponModel.AmmoCount == 0)
                {
                    _playerEventBus.OnStateChangedFromOutside?.Invoke(PlayerState.Standing);
                    _gameEventBus.OnGameOver?.Invoke();
                }
            }
            
        }

        private void InitializeBullet(GameObject go, IPool pool)
        {
            Bullet bullet = go.GetComponent<Bullet>();
            bullet.SetInitialParametrs(pool,
                _weaponModel.BulletSpeed * _playerView.Direction, _weaponModel.Damage);
        }
    }
}
