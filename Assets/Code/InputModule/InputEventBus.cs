using System;

namespace InputModule
{
    public class InputEventBus
    {
        private Action _onWalkLeftButtonDown;
        private Action _onWalkLeftButtonUp;
        private Action _onWalkRightButtonDown;
        private Action _onWalkRightButtonUp;
        private Action _onJumpButtonDown;
        private Action _onShootButtonDown;
        private Action _onShootButtonUp;
        private Action _onPauseButtonDown;
        private Action _onDisableInput;
        private Action _onEnableInput;

        public Action OnWalkLeftButtonDown { get => _onWalkLeftButtonDown; set => _onWalkLeftButtonDown = value; }
        public Action OnWalkLeftButtonUp { get => _onWalkLeftButtonUp; set => _onWalkLeftButtonUp = value; }
        public Action OnWalkRightButtonDown { get => _onWalkRightButtonDown; set => _onWalkRightButtonDown = value; }
        public Action OnWalkRightButtonUp { get => _onWalkRightButtonUp; set => _onWalkRightButtonUp = value; }
        public Action OnJumpButtonDown { get => _onJumpButtonDown; set => _onJumpButtonDown = value; }
        public Action OnShootButtonDown { get => _onShootButtonDown; set => _onShootButtonDown = value; }
        public Action OnShootButtonUp { get => _onShootButtonUp; set => _onShootButtonUp = value; }
        public Action OnPauseButtonDown { get => _onPauseButtonDown; set => _onPauseButtonDown = value; }
        public Action OnDisableInput { get => _onDisableInput; set => _onDisableInput = value; }
        public Action OnEnableInput { get => _onEnableInput; set => _onEnableInput = value; }
    }
}
