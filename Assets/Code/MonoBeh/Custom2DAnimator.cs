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

    public List<Sprite> AnimationSprites { get => _animationSprites; set => _animationSprites = value; }

    private void Start()
    {
        _timer = new Timer(_framesTimeDelta);
        _currentFrameIndex = 0;
    }

    private void FixedUpdate()
    {
        if (_timer.Wait())
        {
            ChangeFrame();
        }
    }

    public void ChangeAnimation(List<Sprite> animationSprites)
    {
        _currentFrameIndex = 0;
        _animationSprites = animationSprites;
        _renderer.sprite = AnimationSprites[_currentFrameIndex];
    }

    private void ChangeFrame()
    {
        _currentFrameIndex++;
        if (_currentFrameIndex >= AnimationSprites.Count)
        {
            _currentFrameIndex = 0;
        }
        _renderer.sprite = AnimationSprites[_currentFrameIndex];
    }
}
