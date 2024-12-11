using UnityEngine;
using Extention;

namespace SO
{
    [CreateAssetMenu(fileName = "PrefabsContainer", menuName = "SO/PrefabsContainer", order = 0)]
    class PrefabsContainer : ScriptableObject
    {
        [SerializeField] private SerializableDictionary<PrefabID, GameObject> _prefabsDict;

        public SerializableDictionary<PrefabID, GameObject> PrefabsDict { get => _prefabsDict; }
    }
}
