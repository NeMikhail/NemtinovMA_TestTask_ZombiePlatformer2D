using Core.Interface;
using System;
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
            gameInput.MoveLeft.canceled += InvokeMoveLeftCanceledEvent;
            gameInput.MoveRight.performed += InvokeMoveRightEvent;
            gameInput.MoveRight.canceled += InvokeMoveRightCanceledEvent;
            gameInput.Jump.performed += InvokeJumpEvent;
            gameInput.Shoot.performed += InvokeShootEvent;
            gameInput.Shoot.canceled += InvokeShootCanceledEvent;
            gameInput.Pause.performed += InvokePauseEvent;
        }

        private void UnbindInput()
        {
            var gameInput = _controls.GameInput;
            gameInput.MoveLeft.performed -= InvokeMoveLeftEvent;
            gameInput.MoveLeft.canceled -= InvokeMoveLeftCanceledEvent;
            gameInput.MoveRight.performed -= InvokeMoveRightEvent;
            gameInput.MoveRight.canceled -= InvokeMoveRightCanceledEvent;
            gameInput.Jump.performed -= InvokeJumpEvent;
            gameInput.Shoot.performed -= InvokeShootEvent;
            gameInput.Shoot.canceled -= InvokeShootCanceledEvent;
            gameInput.Pause.performed -= InvokePauseEvent;
        }

        private void InvokeMoveLeftEvent(InputAction.CallbackContext obj)
        {
            _inputEventBus.OnWalkLeftButtonDown?.Invoke();
        }
        private void InvokeMoveLeftCanceledEvent(InputAction.CallbackContext obj)
        {
            _inputEventBus.OnWalkLeftButtonUp?.Invoke();
        }
        private void InvokeMoveRightEvent(InputAction.CallbackContext obj)
        {
            _inputEventBus.OnWalkRightButtonDown?.Invoke();
        }
        private void InvokeMoveRightCanceledEvent(InputAction.CallbackContext obj)
        {
            _inputEventBus.OnWalkRightButtonUp?.Invoke();
        }
        private void InvokeJumpEvent(InputAction.CallbackContext obj)
        {
            _inputEventBus.OnJumpButtonDown?.Invoke();
        }
        private void InvokeShootEvent(InputAction.CallbackContext obj)
        {
            _inputEventBus.OnShootButtonDown?.Invoke();
        }
        private void InvokeShootCanceledEvent(InputAction.CallbackContext obj)
        {
            _inputEventBus.OnShootButtonUp?.Invoke();
        }
        private void InvokePauseEvent(InputAction.CallbackContext obj)
        {
            _inputEventBus.OnPauseButtonDown.Invoke();
        }
    }
}

