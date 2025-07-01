using System;

public class Timer
{
    private const float MinCount = 0f;

    private ReactiveVariable<float> _currentTime = new(0f);
    public IReadOnlyVariable<float> CurrentTime => _currentTime;

    private float _initialTime;
    private bool _isRunning;
    // public bool IsRunning => _isRunning;

    public Timer(float duration)
    {
        _initialTime = duration;
        _currentTime.Value = duration;
        _isRunning = false;
    }

    public void Update(float deltaTime)
    {
        if (!_isRunning)
            return;

        _currentTime.Value -= deltaTime;

        if (_currentTime.Value <= 0f)
        {
            _currentTime.Value = 0f;
            Stop(); 
        }
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
        _currentTime.Value = MinCount;
        _isRunning = false;
    }

    public void Reset()
    {
        _currentTime.Value = _initialTime;
    }
}