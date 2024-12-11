using Core.Interface;
using Extention;
using UnityEngine;
using Zenject;

namespace GameCoreModule
{

    public class PoolsOperatorPresenter : IPresenter, IInitialisation, ICleanUp
    {
        private PoolsContainer _poolsContainer;
        private GameEventBus _gameEventBus;

        [Inject]
        public void Construct(PoolsContainer poolsContainer, GameEventBus gameEventBus)
        {
            _poolsContainer = poolsContainer;
            _gameEventBus = gameEventBus;
            _poolsContainer.Initialize();
            
        }

        public void Initialisation()
        {
            _gameEventBus.OnSpawnObjectFromPool += SpawnObject;
            _gameEventBus.OnSpawnRotatedObjectFromPool += SpawnObject;
        }

        public void Cleanup()
        {
            _gameEventBus.OnSpawnObjectFromPool -= SpawnObject;
            _gameEventBus.OnSpawnRotatedObjectFromPool -= SpawnObject;
        }



        public void SpawnObject(PrefabID prefabID, Vector3 position)
        {
            IPool pool = _poolsContainer.PoolsDict.GetValue(prefabID);
            pool.Pop(position);
        }

        public void SpawnObject(PrefabID prefabID, Vector3 position, Quaternion rotation)
        {
            IPool pool = _poolsContainer.PoolsDict.GetValue(prefabID);
            pool.Pop(position, rotation);
        }

    }
}
