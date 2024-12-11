using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "SO/PlayerConfig", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private Vector3 _spawnPosition;
        [SerializeField] private PrefabID _prefabID;
        [SerializeField] private float _health;
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private WeaponConfig _weaponConfig;

        public Vector3 SpawnPosition { get => _spawnPosition; }
        public PrefabID PrefabID { get => _prefabID; }
        public float Health { get => _health; }
        public float Speed { get => _speed; }
        public float JumpForce { get => _jumpForce; }
        public WeaponConfig WeaponConfig { get => _weaponConfig; }
        
    }
}
