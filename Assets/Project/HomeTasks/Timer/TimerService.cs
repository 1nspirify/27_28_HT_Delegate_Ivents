using UnityEngine;

public class TimerService : MonoBehaviour
{
    public Timer Timer { get; private set; }

    private void Awake()
    {
        Timer = new Timer(10f);
    }

    private void Update()
    {
        Timer.Update(Time.deltaTime);
    }

    public void StartTimer() => Timer.Start();
    public void PauseTimer() => Timer.Pause();
    public void StopTimer() => Timer.Stop();
    public void ResetTimer() => Timer.Reset();
    public void PrintCurrentInfo() => Debug.Log($"{Timer.CurrentTime} seconds left");
}