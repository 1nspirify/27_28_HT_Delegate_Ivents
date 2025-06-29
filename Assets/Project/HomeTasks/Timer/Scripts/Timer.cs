using System;

public class Timer
{
    private const float MinCount = 0f;
    public event Action OnTimerChanged;
    public ReactiveVariable<float> CurrentTime { get; } = new (0f);

    private float _duration;
    private float _currentTime;
    private bool _isRunning;
    private float _initialTime;
    public bool IsRunning => _isRunning;

    public Timer(float duration)
    {
        _initialTime = duration;
        CurrentTime.Value = duration;
        _isRunning = false;
    }

    public void Update(float deltaTime)
    {
        if (!_isRunning)
            return;

        CurrentTime.Value -= deltaTime;

        if (CurrentTime.Value <= 0f)
        {
            CurrentTime.Value = 0f;
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
        _currentTime = MinCount;
        _isRunning = false;
        OnTimerChanged?.Invoke();
    }

    public void Reset()
    {
        CurrentTime.Value = _initialTime;
    }
}