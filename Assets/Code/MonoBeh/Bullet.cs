using UnityEngine;
using Constants;
using EnemyModule;
using Extention;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _bulletRB;
    private IPool _pool;
    private float _speed;
    private float _damage;
    private float _lifetime;
    private Timer _timer;

    public void SetInitialParametrs(IPool pool, float speed, float damage)
    {
        _pool = pool;
        _speed = speed;
        _damage = damage;
        _lifetime = 6;
        _timer = new Timer(_lifetime);
    }

    private void FixedUpdate()
    {
        _bulletRB.velocity = new Vector2(_speed, 0);
        if (_timer.Wait())
        {
            Destroy();
        }
    }

    private void Destroy()
    {
        _pool.Push(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == TagsConstantsManager.ENEMY_TAG)
        {
            collision.gameObject.GetComponent<EnemyView>().GetDamage(_damage);
        }
    }
}
