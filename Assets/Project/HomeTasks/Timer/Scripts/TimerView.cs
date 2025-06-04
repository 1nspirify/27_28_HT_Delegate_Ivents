using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private List<RawImage> _timerImages;
    [SerializeField] private Slider _timerSlider;
    [SerializeField] private TimerService _timerService;

    private Timer _timer;
    private const float MaxDuration = 10f;
    private const float MinDuration = 0f;

    private void Awake()
    {
        _timer = _timerService.Timer;
        
        _timerSlider.maxValue = MaxDuration;
        _timerSlider.minValue = MinDuration;

        _timer.OnTimerChanged += OnTimerChanged;
    }

    private void Start()
    {
        UpdateUI();
    }

    private void OnDestroy()
    {
        _timer.OnTimerChanged -= OnTimerChanged;
    }

    private void OnTimerChanged()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        float current = _timer.CurrentTime;
        _timerText.text = Mathf.CeilToInt(current).ToString();
        _timerSlider.value = current;

        for (int i = 0; i < _timerImages.Count; i++)
        {
            _timerImages[i].enabled = i < Mathf.CeilToInt(current);
        }
    }
}