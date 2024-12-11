using Core.Interface;
using Zenject;
using InputModule;
using System;

namespace PlayerModule
{
    public class PlayerStatePresenter : IPresenter, IInitialisation, ICleanUp
    {
        private InputEventBus _inputEventBus;
        private PlayerEventBus _playerEventBus;
        private PlayerModel _playerModel;
        private WeaponModel _weaponModel;
        private PlayerState _currentState;

        [Inject]
        public void Construct(InputEventBus inputEventBus, PlayerEventBus playerEventBus,
            PlayerModel playerModel)
        {
            _inputEventBus = inputEventBus;
            _playerEventBus = playerEventBus;
            _playerModel = playerModel;
        }

        public void Initialisation()
        {
            ChangeState(PlayerState.Standing);
            _weaponModel = _playerModel.WeaponModel;
            _playerEventBus.OnStateChangedFromOutside += ChangeState;

            _inputEventBus.OnWalkLeftButtonDown += TrySetWalkingLeftState;
            _inputEventBus.OnWalkLeftButtonUp += TrySetStandingState;
            _inputEventBus.OnWalkRightButtonDown += TrySetWalkingRightState;
            _inputEventBus.OnWalkRightButtonUp += TrySetStandingState;
            _inputEventBus.OnJumpButtonDown += TrySetJumpingState;
            _inputEventBus.OnShootButtonDown += TrySetShootingState;
            _inputEventBus.OnShootButtonUp += SetStandingState;
        }

        public void Cleanup()
        {
            _playerEventBus.OnStateChangedFromOutside -= ChangeState;

            _inputEventBus.OnWalkLeftButtonDown -= TrySetWalkingLeftState;
            _inputEventBus.OnWalkLeftButtonUp -= TrySetStandingState;
            _inputEventBus.OnWalkRightButtonDown -= TrySetWalkingRightState;
            _inputEventBus.OnWalkRightButtonUp -= TrySetStandingState;
            _inputEventBus.OnJumpButtonDown -= TrySetJumpingState;
            _inputEventBus.OnShootButtonDown -= TrySetShootingState;
            _inputEventBus.OnShootButtonUp -= SetStandingState;
        }

        private void ChangeState(PlayerState state)
        {
            _currentState = state;
            _playerEventBus.OnStateChanged?.Invoke(_currentState);
        }
        private void SetStandingState()
        {
            ChangeState(PlayerState.Standing);
        }
        private void TrySetStandingState()
        {
            if (_currentState != PlayerState.Falling && 
                _currentState != PlayerState.Shooting)
            {
                ChangeState(PlayerState.Standing);
            }
        }

        private void TrySetWalkingLeftState()
        {
            if (_currentState != PlayerState.Shooting)
            {
                ChangeState(PlayerState.MovingLeft);
            }
        }
        private void TrySetWalkingRightState()
        {
            if (_currentState != PlayerState.Shooting)
            {
                ChangeState(PlayerState.MovingRight);
            }
        }

        private void TrySetJumpingState()
        {
            if (_currentState != PlayerState.Falling)
            {
                ChangeState(PlayerState.Jumping);
            }
        }

        private void TrySetShootingState()
        {
            if (_currentState != PlayerState.Falling &&
                _weaponModel.AmmoCount > 0)

            {
                ChangeState(PlayerState.Shooting);
            }
        }
    }
}
