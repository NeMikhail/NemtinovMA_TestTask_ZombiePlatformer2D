using Core.Interface;
using GameCoreModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace UIModule
{
    public class UIPresenter : IPresenter, IInitialisation, ICleanUp
    {
        private GameEventBus _gameEventBus;

        [Inject]
        public void Construct(GameEventBus gameEventBus)
        {
            _gameEventBus = gameEventBus;
        }

        public void Initialisation()
        {
            SpawnCanvas();
        }

        private void SpawnCanvas()
        {
            _gameEventBus.OnSpawnObjectWithoutRoot?.Invoke(PrefabID.Canvas, Vector3.zero);
        }

        public void Cleanup()
        {

        }
    }
}

