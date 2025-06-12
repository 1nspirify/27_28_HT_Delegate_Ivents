using UnityEngine;

public class TimerView : MonoBehaviour
{
    protected Timer _timer;
    private void OnTimerChanged()
    {
        UpdateUI();
    }

    public virtual void Initialize(Timer timer)
    {
        _timer = timer;
        _timer.OnTimerChanged += OnTimerChanged;
    }
    
    public void OnDestroy()
    {
        _timer.OnTimerChanged -= OnTimerChanged;
    }

    protected virtual void UpdateUI()
    {
    }

}