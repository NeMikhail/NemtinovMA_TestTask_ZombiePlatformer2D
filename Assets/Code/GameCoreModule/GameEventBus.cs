﻿using Extention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameCoreModule
{
    public class  GameEventBus
    {
        private Action<PrefabID, Vector3> _onSpawnObjectFromPool;
        private Action<PrefabID, Vector3, Quaternion> _onSpawnRotatedObjectFromPool;
        private Action<PrefabID, Vector3, Transform> _onSpawnObject;
        private Action<PrefabID, Vector3> _onSpawnObjectWithoutRoot;
        private Action<PrefabID, Vector3, Quaternion, Transform> _onSpawnRotatedObject;
        private Action<GameState> _onStateChanged;
        private Action<GameObject> _onObjectSpawned;
        private Action<GameObject, IPool> _onObjectSpawnedFromPool;

        public Action<PrefabID, Vector3> OnSpawnObjectFromPool { get => _onSpawnObjectFromPool; set => _onSpawnObjectFromPool = value; }
        public Action<PrefabID, Vector3, Quaternion> OnSpawnRotatedObjectFromPool { get => _onSpawnRotatedObjectFromPool; set => _onSpawnRotatedObjectFromPool = value; }
        public Action<PrefabID, Vector3, Transform> OnSpawnObject { get => _onSpawnObject; set => _onSpawnObject = value; }
        public Action<PrefabID, Vector3> OnSpawnObjectWithoutRoot { get => _onSpawnObjectWithoutRoot; set => _onSpawnObjectWithoutRoot = value; }
        public Action<PrefabID, Vector3, Quaternion, Transform> OnSpawnRotatedObject { get => _onSpawnRotatedObject; set => _onSpawnRotatedObject = value; }
        public Action<GameState> OnStateChanged { get => _onStateChanged; set => _onStateChanged = value; }
        public Action<GameObject> OnObjectSpawned { get => _onObjectSpawned; set => _onObjectSpawned = value; }
        public Action<GameObject, IPool> OnObjectSpawnedFromPool { get => _onObjectSpawnedFromPool; set => _onObjectSpawnedFromPool = value; }
    }
}
