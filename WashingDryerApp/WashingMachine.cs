using System;
using System.Timers;

public class WashingMachine
{
    private Timer timer;
    public string Status { get; private set; }
    public int TimeLeft { get; private set; }

    public event Action<string> StatusChanged;
    public event Action<int> TimeLeftChanged;

    public WashingMachine()
    {
        timer = new Timer(1000);
        timer.Elapsed += OnTimedEvent;
        Status = "Idle";
    }

    private void OnTimedEvent(object sender, ElapsedEventArgs e)
    {
        if (TimeLeft > 0)
        {
            TimeLeft--;
            TimeLeftChanged?.Invoke(TimeLeft);
        }
        else
        {
            timer.Stop();
            Status = "Idle";
            StatusChanged?.Invoke(Status);
        }
    }

    public void StartWashing(int duration)
    {
        TimeLeft = duration;
        Status = "Washing";
        StatusChanged?.Invoke(Status);
        timer.Start();
    }

    public void StartDrying(int duration)
    {
        TimeLeft = duration;
        Status = "Drying";
        StatusChanged?.Invoke(Status);
        timer.Start();
    }

    public void Stop()
    {
        timer.Stop();
        Status = "Stopped";
        StatusChanged?.Invoke(Status);
        TimeLeft = 0;
        TimeLeftChanged?.Invoke(TimeLeft);
    }
}
