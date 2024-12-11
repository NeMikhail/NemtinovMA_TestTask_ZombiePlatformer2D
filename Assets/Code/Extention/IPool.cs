using UnityEngine;

namespace Extention
{
    public interface IPool
    {
        public Transform Root { get; }
        public GameObject Prefab { get; }

        public void Push(GameObject go);
        public GameObject Pop(Vector3 position);
        public GameObject Pop(Vector3 position, Quaternion rotation);
    }
}

