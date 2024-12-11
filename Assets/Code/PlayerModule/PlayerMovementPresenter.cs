using Core.Interface;
using GameCoreModule;
using UnityEngine;
using Zenject;

namespace PlayerModule
{
    public class PlayerMovementPresenter : IPresenter, IInitialisation, IFixedExecute, ICleanUp
    {
        private SceneViewsContainer _sceneViewsContainer;
        private PlayerView _playerView;
        private PlayerModel _playerModel;
        private PlayerEventBus _playerEventBus;
        private PlayerState _currentState;
        private Vector3 _movingRightScale;
        private Vector3 _movingLeftScale;

        [Inject]
        public void Construct(SceneViewsContainer sceneViewsContainer, PlayerModel playerModel,
            PlayerEventBus playerEventBus)
        {
            _sceneViewsContainer = sceneViewsContainer;
            _playerModel = playerModel;
            _playerEventBus = playerEventBus;
        }

        public void Initialisation()
        {
            _playerView = _sceneViewsContainer.GetPlayerView();
            _movingRightScale = _playerView.PayerObject.transform.localScale;
            _movingLeftScale = 
                new Vector3(-1 * _playerView.PayerObject.transform.localScale.x, 
                _playerView.PayerObject.transform.localScale.y, 
                _playerView.PayerObject.transform.localScale.z);
            _playerView.Direction = 1;
            _playerEventBus.OnStateChanged += SetNewMovementBehavior;
        }


        public void Cleanup()
        {
            _playerEventBus.OnStateChanged -= SetNewMovementBehavior;
        }

        public void FixedExecute(float fixedDeltaTime)
        {
            if (_currentState == PlayerState.MovingLeft)
            {
                _playerView.PayerObject.transform.localScale = _movingLeftScale;
                _playerView.PlayerRB.velocity = new Vector2(-_playerModel.CurrentSpeed, _playerView.PlayerRB.velocity.y);
                _playerView.Direction = -1;
            }
            else if (_currentState == PlayerState.MovingRight)
            {
                _playerView.PayerObject.transform.localScale = _movingRightScale;
                _playerView.PlayerRB.velocity = new Vector2(_playerModel.CurrentSpeed, _playerView.PlayerRB.velocity.y);
                _playerView.Direction = 1;
            }
            else if (_currentState == PlayerState.Jumping)
            {
                _playerView.PlayerRB.AddForce(new Vector2(0, _playerModel.CurrentJumpForce));
                _playerEventBus.OnStateChangedFromOutside?.Invoke(PlayerState.Falling);
                _playerView.GroundChecker.IsGrounded = false;
                return;
            }
            else if(_currentState == PlayerState.Standing ||
                _currentState == PlayerState.Shooting)
            {
                _playerView.PlayerRB.velocity = Vector2.zero;
            }

            if (_currentState == PlayerState.Falling &&
                _playerView.GroundChecker.IsGrounded &&
                _currentState != PlayerState.Shooting)
            {
                _playerEventBus.OnStateChangedFromOutside?.Invoke(PlayerState.Standing);
            }
            else if (!_playerView.GroundChecker.IsGrounded)
            {
                _currentState = PlayerState.Falling;
                _playerEventBus.OnStateChangedFromOutside?.Invoke(PlayerState.Falling);
            }
        }

        private void SetNewMovementBehavior(PlayerState state)
        {
            _currentState = state;
        }
    }
}
