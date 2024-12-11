using System;

namespace PlayerModule
{
    public class PlayerEventBus
    {
        private Action<PlayerState> _onStateChanged;
        private Action<PlayerState> _onStateChangedFromOutside;
        private Action<int, int> _onShootEvent;

        public Action<PlayerState> OnStateChanged { get => _onStateChanged; set => _onStateChanged = value; }
        public Action<PlayerState> OnStateChangedFromOutside { get => _onStateChangedFromOutside; set => _onStateChangedFromOutside = value; }
        public Action<int, int> OnShootEvent { get => _onShootEvent; set => _onShootEvent = value; }
    }
}
