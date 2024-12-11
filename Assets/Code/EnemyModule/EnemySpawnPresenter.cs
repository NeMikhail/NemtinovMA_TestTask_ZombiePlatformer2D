using Core.Interface;
using Extention;
using GameCoreModule;
using PlayerModule;
using SO;
using System;
using UnityEngine;
using Zenject;

namespace EnemyModule
{
    public class EnemySpawnPresenter : IPresenter, IInitialisation, IFixedExecute
    {
        private const int SPAWN_MAX_DELTA_TIME = 10;
        private SceneViewsContainer _sceneViewsContainer;
        private EnemyConfigsContainer _enemyConfigsContainer;
        private GameEventBus _gameEventBus;
        private PlayerView _playerView;
        private Timer _timer;
        private System.Random _random;
        private EnemyConfig _currentConfig;

        [Inject]
        public void Construct(SceneViewsContainer sceneViewsContainer, EnemyConfigsContainer enemyConfigsContainer,
            GameEventBus gameEventBus)
        {
            _sceneViewsContainer = sceneViewsContainer;
            _enemyConfigsContainer = enemyConfigsContainer;
            _gameEventBus = gameEventBus;
        }

        public void Initialisation()
        {
            _playerView = _sceneViewsContainer.GetPlayerView();
            _random = new System.Random();
            SetNewTimer();
        }

        public void FixedExecute(float fixedDeltaTime)
        {
            if (_timer.Wait())
            {
                SetNewTimer();
                int spawnDirection = _random.Next(0, 1);
                Spawner spawner;
                if (spawnDirection == 0)
                {
                    spawner = _playerView.LeftSpawnZone.CurrentSpawner;
                }
                else
                {
                    spawner = _playerView.RightSpawnZone.CurrentSpawner;
                }
                SpawnEnemy(spawner.GetSpawnTrnsform());
            }
        }

        private void SpawnEnemy(Transform transform)
        {
            _currentConfig = _enemyConfigsContainer.GetRandomEnemyConfig();
            _gameEventBus.OnObjectSpawnedFromPool += IstantiateEnemy;
            _gameEventBus.OnSpawnObjectFromPool?.Invoke(_currentConfig.PrefabID, transform.position);
            _gameEventBus.OnObjectSpawnedFromPool -= IstantiateEnemy;
        }

        private void IstantiateEnemy(GameObject enemy, IPool pool)
        {
            EnemyView enemyView = enemy.GetComponent<EnemyView>();
            enemyView.SetInitialParametrs(pool, _currentConfig.Speed, _currentConfig.Health, _playerView);
            enemyView.OnEnemyKilled += KillEnemy;
        }

        private void KillEnemy(EnemyView enemyView)
        {
            _gameEventBus.OnObjectSpawnedFromPool += IstantiateAmmoBox;
            _gameEventBus.OnSpawnObjectFromPool?.Invoke(PrefabID.AmmoBox, enemyView.Object.transform.position);
            _gameEventBus.OnObjectSpawnedFromPool -= IstantiateAmmoBox;
            enemyView.OnEnemyKilled -= KillEnemy;
        }

        private void IstantiateAmmoBox(GameObject boxObject, IPool pool)
        {
            AmmoBox ammoBox = boxObject.GetComponent<AmmoBox>();
            ammoBox.SetInitialParametrs(pool);
        }

        private void SetNewTimer()
        {
            float deltaTime = GetRandomDeltaTime();
            _timer = new Timer(deltaTime);
        }

        private float GetRandomDeltaTime()
        {
            float deltaTime = _random.Next(1, SPAWN_MAX_DELTA_TIME);
            float tens = _random.Next(1, 9) / 10;
            float hudreds = _random.Next(1, 9) / 100;
            deltaTime = deltaTime + tens + hudreds;
            return deltaTime;
        }

    }
}
