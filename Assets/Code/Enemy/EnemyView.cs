using System;

namespace Enemy
{
    public class EnemyView
    {
        private Action<float> _onHealthChanged;

        public void GetDamage(float damage)
        {
            _onHealthChanged?.Invoke(damage);
        }
    }
}
