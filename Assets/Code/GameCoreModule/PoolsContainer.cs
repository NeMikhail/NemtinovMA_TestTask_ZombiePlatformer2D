using Extention;
using Zenject;
using SO;
using UnityEngine;

namespace GameCoreModule
{
    public class PoolsContainer
    {
        private DiContainer _di;
        private PrefabsContainer _prefabsContainer;
        private SerializableDictionary<PrefabID, IPool> _poolsDict;

        public SerializableDictionary<PrefabID, IPool> PoolsDict { get => _poolsDict; }

        [Inject]
        public void Construct(DiContainer di, PrefabsContainer prefabsContainer)
        {
            _di = di;
            _prefabsContainer = prefabsContainer;
        }

        public void Initialize()
        {
            _poolsDict = new SerializableDictionary<PrefabID, IPool>();
            InitializePool(PrefabID.BulletPrefab);
            InitializePool(PrefabID.EnemyPrefab1);
            InitializePool(PrefabID.EnemyPrefab2);
            InitializePool(PrefabID.EnemyPrefab3);
            InitializePool(PrefabID.EnemyPrefab4);
            InitializePool(PrefabID.EnemyPrefab5);
            InitializePool(PrefabID.AmmoBox);
        }

        private void InitializePool(PrefabID prefabID)
        {
            GameObject prefab = _prefabsContainer.PrefabsDict.GetValue(prefabID);
            Transform poolRoot = new GameObject(prefabID.ToString()).transform;
            ObjectsPool pool = new ObjectsPool(_di, prefab, poolRoot);
            _poolsDict.Add(prefabID, pool);
        }
    }
}
