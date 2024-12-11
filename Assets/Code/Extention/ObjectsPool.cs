using System.Collections.Generic;
using UnityEngine;

namespace Extention
{
    public class ObjectsPool : IPool
    {
        private const string DEFAULT_ROOT_NAME = "PoolRoot";
        private readonly Stack<GameObject> _stack = new Stack<GameObject>();
        private readonly GameObject _prefab;
        private readonly Transform _rootPool;

        public Transform Root { get => _rootPool; }
        public GameObject Prefab { get => _prefab; }

        public ObjectsPool(GameObject prefab)
        {
            _prefab = prefab;
            _rootPool = new GameObject(DEFAULT_ROOT_NAME).transform;
        }

        public ObjectsPool(GameObject prefab, Transform rootTransform)
        {
            _prefab = prefab;
            _rootPool = rootTransform;
        }

        public void Push(GameObject go)
        {
            _stack.Push(go);
            go.transform.position = _rootPool.position;
            go.transform.SetParent(_rootPool);
            go.SetActive(false);
        }

        public GameObject Pop(Vector3 position)
        {
            GameObject go;
            if (_stack.Count == 0)
            {
                go = Object.Instantiate(_prefab, position, Quaternion.identity, _rootPool);
            }
            else
            {
                go = _stack.Pop();
                go.transform.position = position;
                go.transform.rotation = Quaternion.identity;

            }
            go.SetActive(true);
            return go;
        }

        public GameObject Pop(Vector3 position, Quaternion rotation)
        {
            GameObject go;
            if (_stack.Count == 0)
            {
                go = Object.Instantiate(_prefab, position, rotation, _rootPool);
            }
            else
            {
                go = _stack.Pop();
                go.transform.position = position;
                go.transform.rotation = rotation;

            }
            go.SetActive(true);
            return go;
        }
    }
}

