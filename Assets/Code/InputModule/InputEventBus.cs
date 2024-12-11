using System;

namespace InputModule
{
    public class InputEventBus
    {
        private Action _onWalkLeftButtonDown;
        private Action _onWalkRightButtonDown;
        private Action _onJumpButtonDown;
        private Action _onShootButtonDown;
        private Action _onPauseButtonDown;

        public Action OnWalkLeftButtonDown { get => _onWalkLeftButtonDown; set => _onWalkLeftButtonDown = value; }
        public Action OnWalkRightButtonDown { get => _onWalkRightButtonDown; set => _onWalkRightButtonDown = value; }
        public Action OnJumpButtonDown { get => _onJumpButtonDown; set => _onJumpButtonDown = value; }
        public Action OnShootButtonDown { get => _onShootButtonDown; set => _onShootButtonDown = value; }
        public Action OnPauseButtonDown { get => _onPauseButtonDown; set => _onPauseButtonDown = value; }
    }
}
