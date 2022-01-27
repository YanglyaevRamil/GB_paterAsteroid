public class ShipGun : IGun
{
    private const float TIMER_TICK = 100.0f; // 0.1 sec
    private const float GUN_RECOIL_TIME = 0.1f; // sec
    public bool EmptyAmmunition { get => emptyAmmunition; }
    public int Ammunition { get { return ammunition; } set { ammunition = value; } }
    private int ammunition;
    private bool emptyAmmunition;
    private GameTimer gameTimer;
    public ShipGun(int ammunition)
    {
        this.ammunition = ammunition;
        emptyAmmunition = false;
        gameTimer = new GameTimer(TIMER_TICK, GUN_RECOIL_TIME);
    }
    public bool Shot()
    {
        if (gameTimer.FlagStopWatch)
        {
            gameTimer.StartTimer();
            if (ammunition > 0)
            {
                ammunition--;
                emptyAmmunition = false;
            }
            else
            {
                emptyAmmunition = true;
            }

            return !emptyAmmunition;
        }
        else
        {
            return false;
        }
    }
}
