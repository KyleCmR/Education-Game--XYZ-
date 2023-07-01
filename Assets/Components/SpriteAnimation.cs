using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAnimation : MonoBehaviour
{
    [SerializeField] private int _frameRate;
    [SerializeField] private bool _loop;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private UnityEvent _onComplete;

    private SpriteRenderer _renderer;
    private float _secondsPerFrame;
    private int _currentSpritendex;
    private float _nextFrameTime;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _secondsPerFrame = 1f / _frameRate;
        _nextFrameTime = Time.time + _secondsPerFrame;
        _currentSpritendex = 0;
    }
    private void Update()
    {
        if (_nextFrameTime > Time.time) return;

        if (_currentSpritendex >= _sprites.Length)
        {
            if (_loop)
            {
                _currentSpritendex = 0;
            }
            else
            {
                enabled = false;
                _onComplete.Invoke();
                return;
            }
        }

        _renderer.sprite = _sprites[_currentSpritendex];
        _nextFrameTime += _secondsPerFrame;
        _currentSpritendex++;
    }
}
