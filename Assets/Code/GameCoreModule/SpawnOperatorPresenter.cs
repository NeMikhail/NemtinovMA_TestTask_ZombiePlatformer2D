using Core.Interface;
using UnityEngine;
using Zenject;
using SO;

namespace GameCoreModule
{
    public class SpawnOperatorPresenter : IPresenter, IInitialisation, ICleanUp
    {
        private DiContainer _di;
        private PrefabsContainer _prefabsContainer;
        private GameEventBus _eventBus;

        [Inject]
        public void Construct(DiContainer diContainer, PrefabsContainer prefabsContainer,
            GameEventBus gameEventBus)
        {
            _di = diContainer;
            _prefabsContainer = prefabsContainer;
            _eventBus = gameEventBus;
        }

        public void Initialisation()
        {
            _eventBus.OnSpawnObject += SpawnObject;
            _eventBus.OnSpawnRotatedObject += SpawnObject;
        }

        public void Cleanup()
        {
            _eventBus.OnSpawnObject -= SpawnObject;
            _eventBus.OnSpawnRotatedObject -= SpawnObject;
        }

        private void SpawnObject(PrefabID prefabID, Vector3 position, Transform root)
        {
            GameObject prefab = _prefabsContainer.PrefabsDict.GetValue(prefabID);
            _di.InstantiatePrefab(prefab, position, Quaternion.identity, root);
        }

        private void SpawnObject(PrefabID prefabID, Vector3 position, Quaternion rotation, Transform root)
        {
            GameObject prefab = _prefabsContainer.PrefabsDict.GetValue(prefabID);
            _di.InstantiatePrefab(prefab, position, rotation, root);
        }

    }
}
