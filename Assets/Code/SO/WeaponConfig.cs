using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "SO/WeaponConfig", order = 0)]
    public class WeaponConfig : ScriptableObject
    {
        [SerializeField] private PrefabID _bulletPrefabID;
        [SerializeField] private Sprite _bulletIconSprite;
        [SerializeField] private int _maxAmmoCount;
        [SerializeField] private float _damage;
        [SerializeField] private float _cooldown;
        [SerializeField] private float _bulletSpeed;

        public PrefabID BulletPrefabID { get => _bulletPrefabID; }
        public Sprite BulletIconSprite { get => _bulletIconSprite; }
        public int MaxAmmoCount { get => _maxAmmoCount; }
        public float Damage { get => _damage; }
        public float Cooldown { get => _cooldown; }
        public float BulletSpeed { get => _bulletSpeed; }
    }
}
