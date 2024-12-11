using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField] private Spawner _currentSpawner;

    public Spawner CurrentSpawner { get => _currentSpawner; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Spawner spawner;
        if (collision.gameObject.TryGetComponent<Spawner>(out spawner))
        {
            _currentSpawner = spawner;
        }
    }
}
