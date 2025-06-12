using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerSliderView : TimerView
{
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private Slider _timerSlider;
    
    private const float MaxDuration = 10f;
    private const float MinDuration = 0f;

    public override void Initialize(Timer timer)
    {
        base.Initialize(timer); 

        Debug.Log("Подписались");

        _timerSlider.maxValue = MaxDuration;
        _timerSlider.minValue = MinDuration;

        Debug.Log("Подписались");
    }
    
    protected override void UpdateUI()
    {
        float current = _timer.CurrentTime;
        
        _timerText.text = Mathf.CeilToInt(current).ToString();
        _timerSlider.value = current;
    }
}