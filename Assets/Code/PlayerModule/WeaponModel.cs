using System;
using UnityEngine;

namespace PlayerModule
{
    public class WeaponModel
    {
        private PrefabID _bulletPrefabID;
        private Sprite _bulletIconSprite;
        private int _ammoCount;
        private int _maxAmmoCount;
        private float _damage;
        private float _cooldown;
        private float _bulletSpeed;
        private Action _onAmmoCountChanged;

        public PrefabID BulletPrefabID { get => _bulletPrefabID; }
        public Sprite BulletIconSprite { get => _bulletIconSprite; }
        public int AmmoCount { get => _ammoCount; set => _ammoCount = value; }
        public int MaxAmmoCount { get => _maxAmmoCount; }
        public float Damage { get => _damage; }
        public float Cooldown { get => _cooldown; }
        public float BulletSpeed { get => _bulletSpeed; }
        public Action OnAmmoCountChanged { get => _onAmmoCountChanged; set => _onAmmoCountChanged = value; }

        public WeaponModel(PrefabID bulletPrefabID, Sprite bulletIconSprite, int ammoCount,
            int maxAmmoCount, float damage, float cooldown, float bulletSpeed)
        {
            _bulletPrefabID = bulletPrefabID;
            _bulletIconSprite = bulletIconSprite;
            _ammoCount = ammoCount;
            _maxAmmoCount = maxAmmoCount;
            _damage = damage;
            _cooldown = cooldown;
            _bulletSpeed = bulletSpeed;
        }

        public void SetAmmoCount(int ammoCount)
        {
            _ammoCount = ammoCount;
            OnAmmoCountChanged?.Invoke();

        }


    }
}
