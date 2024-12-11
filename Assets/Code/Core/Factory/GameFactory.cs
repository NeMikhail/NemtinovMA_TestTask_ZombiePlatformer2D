﻿using Core.Interface;
using GameCoreModule;
using InputModule;
using PlayerModule;
using System;
using Zenject;

namespace Core
{
    public class GameFactory
    {
        private DiContainer _di;
        private Presenters _presenters;

        [Inject]
        public void Construct(DiContainer di, Presenters presenters)
        {
            _di = di;
            _presenters = presenters;
        }

        public void Init()
        {
            InitializeInputModule();
            InitializeGameCoreModule();
            InitializePlayerModule();
        }

        private void InitializePresenter(IPresenter presenter)
        {
            _presenters.Add(presenter);
        }


        private void InitializeInputModule()
        {
            InputPresenter inputPresenter = _di.Resolve<InputPresenter>();
            InitializePresenter(inputPresenter);
        }

        private void InitializeGameCoreModule()
        {
            GameStatePresenter gameStatePresenter = _di.Resolve<GameStatePresenter>();
            InitializePresenter(gameStatePresenter);
            PoolsOperatorPresenter poolsOperator = _di.Resolve<PoolsOperatorPresenter>();
            InitializePresenter(poolsOperator);
            SpawnOperatorPresenter spawnOperator = _di.Resolve<SpawnOperatorPresenter>();
            InitializePresenter(spawnOperator);
        }

        private void InitializePlayerModule()
        {
            PlayerSpawnPresenter playerSpawnPresenter = _di.Resolve<PlayerSpawnPresenter>();
            InitializePresenter(playerSpawnPresenter);
            PlayerStatePresenter playerStatePresenter = _di.Resolve<PlayerStatePresenter>();
            InitializePresenter(playerStatePresenter);
            PlayerMovementPresenter playerMovementPresenter = _di.Resolve<PlayerMovementPresenter>();
            InitializePresenter(playerMovementPresenter);
            WeaponPresenter weaponPresenter = _di.Resolve<WeaponPresenter>();
            InitializePresenter(weaponPresenter);
        }


    }
}