using Core.Interface;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace InputModule
{
    public class InputPresenter : IPresenter, IPreInitialisation, ICleanUp
    {
        private GameControls _controls;
        private InputEventBus _inputEventBus;

        [Inject]
        public void Construct(InputEventBus inputEventBus)
        {
            _inputEventBus = inputEventBus;
        }

        public void PreInitialisation()
        {
            _controls = new GameControls();
            _controls.Enable();
            BindInput();
        }

        public void Cleanup()
        {
            UnbindInput();
        }

        private void BindInput()
        {
            var gameInput = _controls.GameInput;
            gameInput.MoveLeft.performed += InvokeMoveLeftEvent;
            gameInput.MoveRight.performed += InvokeMoveRightEvent;
            gameInput.Jump.performed += InvokeJumpEvent;
            gameInput.Shoot.performed += InvokeShootEvent;
            gameInput.Pause.performed += InvokePauseEvent;
        }

        private void UnbindInput()
        {
            var gameInput = _controls.GameInput;
            gameInput.MoveLeft.performed -= InvokeMoveLeftEvent;
            gameInput.MoveRight.performed -= InvokeMoveRightEvent;
            gameInput.Jump.performed -= InvokeJumpEvent;
            gameInput.Shoot.performed -= InvokeShootEvent;
            gameInput.Pause.performed -= InvokePauseEvent;
        }

        private void InvokeMoveLeftEvent(InputAction.CallbackContext obj)
        {
            _inputEventBus.OnWalkLeftButtonDown?.Invoke();
        }
        private void InvokeMoveRightEvent(InputAction.CallbackContext obj)
        {
            _inputEventBus.OnWalkRightButtonDown?.Invoke();
        }
        private void InvokeJumpEvent(InputAction.CallbackContext obj)
        {
            _inputEventBus.OnJumpButtonDown?.Invoke();
        }
        private void InvokeShootEvent(InputAction.CallbackContext obj)
        {
            _inputEventBus.OnShootButtonDown?.Invoke();
        }
        private void InvokePauseEvent(InputAction.CallbackContext obj)
        {
            _inputEventBus.OnPauseButtonDown.Invoke();
        }
    }
}

