using System.Timers;
public class GameTimer
{
    public float TimeWatch { get { return timeSec/10; } }
    public bool FlagStopWatch { get { return flagStopWatch; } }
    private Timer aTimer;
    private float timeSec;
    private bool flagStopWatch;
    private float timerBorder;
    public GameTimer(float timeInterval, float timerBorder)
    {
        aTimer = new Timer(timeInterval);
        this.timerBorder = timerBorder;
        aTimer.Elapsed += OnTickEvent;
        aTimer.AutoReset = true;
        aTimer.Enabled = false;
        timeSec = 0;
        flagStopWatch = true;
    }
    public void SetAutoReset(bool reset)
    {
        aTimer.AutoReset = reset;
    }
    public void SetInterval(double interval)
    {
        aTimer.Interval = interval;
    }
    public void StartTimer()
    {
        flagStopWatch = false;
        aTimer.Enabled = true;
    } 
    public void PauseTimer()
    {
        aTimer.Enabled = false;
        flagStopWatch = true;
    }
    public void StopTimer()
    {
        aTimer.Enabled = false;
        flagStopWatch = true;
        timeSec = 0;
    }
    private void OnTickEvent(object sender, ElapsedEventArgs e)
    {
        timeSec++;
        if (timeSec / 10 >= timerBorder)
        {
            StopTimer();
        }
    }
}
