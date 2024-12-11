using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "SO/EnemyConfig", order = 0)]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private PrefabID _prefabID;
        [SerializeField] private float _health;
        [SerializeField] private float _speed;

        public PrefabID PrefabID { get => _prefabID; set => _prefabID = value; }
        public float Health { get => _health; set => _health = value; }
        public float Speed { get => _speed; set => _speed = value; }
    }
}
