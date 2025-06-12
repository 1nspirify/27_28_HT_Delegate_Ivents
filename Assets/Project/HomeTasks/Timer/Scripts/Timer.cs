using System;

public class Timer
{
    private const float MinCount = 0f;
    public event Action OnTimerChanged;
    public event Action OnTimerEnded;

    private float _duration;
    private float _currentTime;
    private bool _isRunning;

    public float CurrentTime => _currentTime;
    public bool IsRunning => _isRunning;

    public Timer(float duration)
    {
        _duration = duration;
        _currentTime = duration;
        _isRunning = false;
    }

    public void Update(float deltaTime)
    {
        if (!_isRunning || _currentTime <= MinCount)
            return;

        _currentTime -= deltaTime;

        if (_currentTime <= MinCount)
        {
            _currentTime = MinCount;
            _isRunning = false;
            OnTimerEnded?.Invoke();
        }

        OnTimerChanged?.Invoke();
    }

    public void Start()
    {
        _isRunning = true;
    }

    public void Pause()
    {
        _isRunning = false;
    }

    public void Stop()
    {
        _currentTime = MinCount;
        _isRunning = false;
        OnTimerChanged?.Invoke();
    }

    public void Reset()
    {
        _currentTime = _duration;
        _isRunning = false;
        OnTimerChanged?.Invoke();
    }
}