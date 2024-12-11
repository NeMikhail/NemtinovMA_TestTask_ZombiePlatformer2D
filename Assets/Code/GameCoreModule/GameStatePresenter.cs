using Core.Interface;
using UnityEngine;
using Zenject;
using InputModule;

namespace GameCoreModule
{
    public class GameStatePresenter : IPresenter, IInitialisation, ICleanUp
    {
        private GameEventBus _gameEventBus;
        private InputEventBus _inputEventBus;
        private GameState _currentGameState;

        [Inject]
        public void Construct(GameEventBus gameEventBus, InputEventBus inputEventBus)
        {
            _gameEventBus = gameEventBus;
            _inputEventBus = inputEventBus;
        }

        public void Initialisation()
        {
            _inputEventBus.OnPauseButtonDown += SetPauseState;
            _gameEventBus.OnContinueGame += SetPlayingState;
            _gameEventBus.OnGameOver += SetGameOverState;
            SetPlayingState();
        }

        public void Cleanup()
        {
            _inputEventBus.OnPauseButtonDown -= SetPauseState;
            _gameEventBus.OnContinueGame -= SetPlayingState;
            _gameEventBus.OnGameOver -= SetGameOverState;
        }

        private void SetPlayingState()
        {
            if (_currentGameState != GameState.PlayState)
            {
                Time.timeScale = 1f;
                _inputEventBus.OnEnableInput?.Invoke();
                _currentGameState = GameState.PlayState;
                _gameEventBus.OnStateChanged?.Invoke(_currentGameState);
            }
        }
        private void SetPauseState()
        {
            if (_currentGameState != GameState.PauseState)
            {
                Time.timeScale = 0f;
                _inputEventBus.OnDisableInput?.Invoke();
                _currentGameState = GameState.PauseState;
                _gameEventBus.OnStateChanged?.Invoke(_currentGameState);
            }
        }

        private void SetGameOverState()
        {
            Time.timeScale = 0f;
            _inputEventBus.OnDisableInput?.Invoke();
            _currentGameState = GameState.GameOver;
            _gameEventBus.OnStateChanged?.Invoke(_currentGameState);
        }

    }
}
