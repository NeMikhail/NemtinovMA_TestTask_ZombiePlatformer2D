using Zenject;

namespace PlayerModule
{
    public class PlayerModel
    {
        private float _health;
        private float _currentSpeed;
        private float _currentJumpForce;
        private WeaponModel _weaponModel;

        public float Health { get => _health; set => _health = value; }
        public float CurrentSpeed { get => _currentSpeed; set => _currentSpeed = value; }
        public float CurrentJumpForce { get => _currentJumpForce; set => _currentJumpForce = value; }
        public WeaponModel WeaponModel { get => _weaponModel; set => _weaponModel = value; }

        public PlayerModel(float health, float currentSpeed, float currentJumpForce, WeaponModel weaponModel)
        {
            _health = health;
            _currentSpeed = currentSpeed;
            _currentJumpForce = currentJumpForce;
            _weaponModel = weaponModel;
        }
    }
}
