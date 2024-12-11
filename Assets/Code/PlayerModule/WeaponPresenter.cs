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
        private WeaponModel _weaponModel;
        private PlayerState _currentState;
        private Timer _timer;
        

        [Inject]
        public void Construct(SceneViewsContainer sceneViewsContainer, PlayerModel playerModel,
            PlayerEventBus playerEventBus, GameEventBus gameEventBus)
        {
            _sceneViewsContainer = sceneViewsContainer;
            _playerModel = playerModel;
            _playerEventBus = playerEventBus;
            _gameEventBus = gameEventBus;
        }

        public void Initialisation()
        {
            _playerView = _sceneViewsContainer.GetPlayerView();
            InitializeWeapon(_playerModel.WeaponModel);
            _playerEventBus.OnStateChanged += ChangeState;
        }

        public void Cleanup()
        {
            _playerEventBus.OnStateChanged -= ChangeState;
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

        public void ChangeState(PlayerState playerState)
        {
            _currentState = playerState;
        }

        private void Shoot()
        {
            if (_weaponModel.AmmoCount > 0)
            {
                _weaponModel.AmmoCount--;
                _gameEventBus.OnObjectSpawnedFromPool += InitializeBullet;
                _gameEventBus.OnSpawnObjectFromPool(_weaponModel.BulletPrefabID, _playerView.Weapon.transform.position);
                _gameEventBus.OnObjectSpawnedFromPool -= InitializeBullet;
                _playerEventBus.OnShootEvent?.Invoke(_weaponModel.AmmoCount, _weaponModel.MaxAmmoCount);
                if (_weaponModel.AmmoCount == 0)
                {
                    _playerEventBus.OnStateChangedFromOutside?.Invoke(PlayerState.Standing);
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
