using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerHeartView : TimerView
{
    [SerializeField] private List<RawImage> _timerImages;
    
    protected override void UpdateUI()
    {
        float current = _timer.CurrentTime.Value;

        for (int i = 0; i < _timerImages.Count; i++)
        {
            _timerImages[i].enabled = i < Mathf.CeilToInt(current);
        }
    }
}