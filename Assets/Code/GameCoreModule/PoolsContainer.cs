using Extention;

namespace GameCoreModule
{
    public class PoolsContainer
    {
        private SerializableDictionary<PrefabID, IPool> _poolsDict;

        public SerializableDictionary<PrefabID, IPool> PoolsDict { get => _poolsDict; }

        public void Initialize()
        {
            _poolsDict = new SerializableDictionary<PrefabID, IPool>();
        }
    }
}
