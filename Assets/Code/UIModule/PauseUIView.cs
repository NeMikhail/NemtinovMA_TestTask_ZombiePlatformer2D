using Core.Interface;
using GameCoreModule;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UIModule
{
    public class PauseUIView : MonoBehaviour, IView
    {
        [SerializeField] private GameObject _object;
        [SerializeField] private GameObject _guiPanel;
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _exitButton;
        private GameEventBus _gameEventBus;
        private string _viewID;

        public GameObject Object { get => _object; }
        public string ViewID { get => _viewID; set => _viewID = value; }

        [Inject]
        public void Construct(GameEventBus gameEventBus)
        {
            _gameEventBus = gameEventBus;
        }

        private void Start()
        {
            _continueButton.onClick.AddListener(ContinueGame);
            _exitButton.onClick.AddListener(ExitGame);
            _gameEventBus.OnStateChanged += TryShowPauseMenu;
            _object.SetActive(false);
        }

        private void OnDestroy()
        {
            _continueButton.onClick.RemoveListener(ContinueGame);
            _exitButton.onClick.RemoveListener(ExitGame);
            _gameEventBus.OnStateChanged -= TryShowPauseMenu;
        }
        private void TryShowPauseMenu(GameState state)
        {
            if (state == GameState.PauseState)
            {
                _object.SetActive(true);
                _guiPanel.SetActive(false);
            }
        }

        private void ContinueGame()
        {
            _object.SetActive(false);
            _guiPanel.SetActive(true);
            _gameEventBus.OnContinueGame?.Invoke();
        }
        private void ExitGame()
        {
            Application.Quit();
        }
    }
}

