using UnityEngine;

public class TimerView : MonoBehaviour
{
    protected Timer _timer;

    public virtual void Initialize(Timer timer)
    {
        _timer = timer;
        _timer.CurrentTime.Changed += OnCurrentTimeChanged;
    }
    
    private void OnDestroy()
    {
        if (_timer != null)
            _timer.CurrentTime.Changed -= OnCurrentTimeChanged;
    }
    protected virtual void UpdateUI()
    {
    }
    
    private void OnCurrentTimeChanged(float oldTime, float newTime)
    {
        UpdateUI();
    }
}