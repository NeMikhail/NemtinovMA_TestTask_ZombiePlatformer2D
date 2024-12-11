using System.Collections.Generic;
using UnityEngine;
using Extention;

public class Custom2DAnimator : MonoBehaviour
{
    [SerializeField] private List<Sprite> _animationSprites;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private float _framesTimeDelta;
    private int _currentFrameIndex;
    private Timer _timer;

    private void Start()
    {
        _timer = new Timer(_framesTimeDelta);
        _currentFrameIndex = 0;
    }

    void FixedUpdate()
    {
        if (_timer.Wait())
        {
            ChangeFrame();
        }
    }

    private void ChangeFrame()
    {
        _currentFrameIndex++;
        if (_currentFrameIndex >= _animationSprites.Count)
        {
            _currentFrameIndex = 0;
        }
        _renderer.sprite = _animationSprites[_currentFrameIndex];
    }
}
