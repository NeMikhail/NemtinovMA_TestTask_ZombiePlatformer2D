using Core.Interface;
using GameCoreModule;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace UIModule
{
    public class GameOverUIView : MonoBehaviour, IView
    {
        [SerializeField] private GameObject _object;
        [SerializeField] private GameObject _guiPanel;
        [SerializeField] private Button _restartButton;
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
            _restartButton.onClick.AddListener(RestartGame);
            _exitButton.onClick.AddListener(ExitGame);
            _gameEventBus.OnStateChanged += TryShowGameOverMenu;
            _object.SetActive(false);
        }

        private void OnDestroy()
        {
            _restartButton.onClick.RemoveListener(RestartGame);
            _exitButton.onClick.RemoveListener(ExitGame);
            _gameEventBus.OnStateChanged -= TryShowGameOverMenu;
        }
        private void TryShowGameOverMenu(GameState state)
        {
            if (state == GameState.GameOver)
            {
                _object.SetActive(true);
                _guiPanel.SetActive(false);
            }
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        private void ExitGame()
        {
            Application.Quit();
        }
    }
}

