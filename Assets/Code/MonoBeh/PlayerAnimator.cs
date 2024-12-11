using System.Collections.Generic;
using UnityEngine;
using Extention;
using PlayerModule;
using System;
using Zenject;

public class PlayerAnimator : Custom2DAnimator
{
    [SerializeField] private SerializableDictionary<PlayerAnimationID, List<Sprite>> _animationsDict;
    private PlayerEventBus _playerEventBus;
    private PlayerState _currentState;

    [Inject]
    public void Construct(PlayerEventBus playerEventBus)
    {
        _playerEventBus = playerEventBus;
    }

    private void Awake()
    {
        _playerEventBus.OnStateChanged += TryChangeAnimation;
    }

    private void OnDestroy()
    {
        _playerEventBus.OnStateChanged -= TryChangeAnimation;
    }
    private void TryChangeAnimation(PlayerState state)
    {
        if (state != _currentState)
        {
            _currentState = state;
            if (_currentState == PlayerState.MovingLeft ||
                _currentState == PlayerState.MovingRight)
            {
                ChangeAnimation(PlayerAnimationID.Walking);
            }
            else if (_currentState == PlayerState.Shooting)
            {
                ChangeAnimation(PlayerAnimationID.Shooting);

            }
            else
            {
                ChangeAnimation(PlayerAnimationID.Standing);
            }
               
        }
    }

    public void ChangeAnimation(PlayerAnimationID id)
    {
        ChangeAnimation(_animationsDict.GetValue(id));
    }

}
