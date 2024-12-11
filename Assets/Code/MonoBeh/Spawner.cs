using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _transforms;

    private void Start()
    {
        List<Transform> transformsToRemove = new List<Transform>();
        foreach (Transform transform in _transforms)
        {
            if (!transform.gameObject.activeInHierarchy)
            {
                transformsToRemove.Add(transform);
            }
        }
        if (transformsToRemove.Count != 0)
        {
            foreach (Transform transform in transformsToRemove)
            {
                _transforms.Remove(transform);
            }
        }
    }

    public Transform GetSpawnTrnsform()
    {
        if (_transforms.Count > 1)
        {
            System.Random random = new System.Random();
            int index = random.Next(0, _transforms.Count);
            return _transforms[index];
        }
        else
        {
            return _transforms[0];
        }
    }
}
