using Core.Interface;
using Extention;
using PlayerModule;
using System;
using UnityEngine;

namespace EnemyModule
{
    public class EnemyView : MonoBehaviour, IView
    {
        [SerializeField] private Rigidbody2D _enemyRB;
        [SerializeField] private GameObject _object;
        [SerializeField] private string _viewID;
        private Action<float> _onHealthChanged;
        private Action<EnemyView> _onEnemyKilled;
        private PlayerView _playerView;
        private Vector3 _movingRightScale;
        private Vector3 _movingLeftScale;
        private IPool _pool;
        private float _speed;
        private float _health;

        public GameObject Object { get => _object; }
        public string ViewID { get => _viewID; set => _viewID = value; }
        public Action<EnemyView> OnEnemyKilled { get => _onEnemyKilled; set => _onEnemyKilled = value; }

        public void SetInitialParametrs(IPool pool, float speed, float health, PlayerView playerView)
        {
            _pool = pool;
            _speed = speed;
            _health = health;
            _playerView = playerView;

            _movingRightScale = _object.transform.localScale;
            _movingLeftScale =
                new Vector3(-1 * _object.transform.localScale.x,
                _object.transform.localScale.y,
                _object.transform.localScale.z);
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            int direction = (int)(_object.transform.position.x - _playerView.Object.transform.position.x);
            if (direction > 0)
            {
                _enemyRB.velocity = new Vector2(-1 * _speed, _enemyRB.velocity.y);

                _object.transform.localScale = _movingLeftScale;
            }
            else
            {
                _enemyRB.velocity = new Vector2(_speed, _enemyRB.velocity.y);

                _object.transform.localScale = _movingRightScale;
            }
        }        

        public void GetDamage(float damage)
        {
            _health = _health - damage;
            _onHealthChanged?.Invoke(damage);
            if (_health <= 0)
            {
                _health = 0;
                KillEnemy();
            }
        }

        private void KillEnemy()
        {
            OnEnemyKilled?.Invoke(this);
            _pool.Push(_object);
        }
    }
}
