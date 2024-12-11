using Extention;
using PlayerModule;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [SerializeField] private int _ammoCount;
    private IPool _pool;

    public void SetInitialParametrs(IPool pool)
    {
        _pool = pool;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerView playerView;
        if (collision.gameObject.TryGetComponent<PlayerView>(out playerView))
        {
            playerView.OnAmmoAdded?.Invoke(_ammoCount);
            _pool.Push(gameObject);
        }
    }
}
